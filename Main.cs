using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SortImage
{
    public partial class SortImg : Form
    {
        // Constants
        const int dupFold = 32;

        //Variables used throughout the program
        //TODO Make workingFolders/buttonPictureToggle an array of objects/classes
        private string[] workingFolders = new string[64]; // 0-31 are source folders, 32 is dup folder, 33-63 are destination folders
        private int[] buttonPictureToggle = new int[64];
        private int logline;
        private int deletype = 0;
        private bool deletAll = false;
        private int curfold = 33; // start of destenation folders
        private int nextCount = 0;
        private int firstTag = 0;
        private int renameIteration = 0;
        private string sortval = "NAME";
        private bool isAnimated = false;
        private string fileparth = null;
        private int sourceCount = 0;
        private string bwFold = "";
        private int progress = 0;
        private bool firstImage = false;
        private string currentImageFocus = "";
        private int lastButtonIndex = 999;
        private bool allowMove = true;
        private bool is64bit = false;
        private string currentToolTipText = "N/A";
        private int lastToolTipX;
        private int lastToolTipY;

        private Point selectionStart;
        private Point selectionEnd;
        private Rectangle selection;
        private bool mouseDown;

        //Initalized Classes
        private Utils32 util32;
        private Utils64 util64;
        private ArrayList fileCopyedSource;
        private ArrayList fileCopyedDestination;
        private ArrayList buttonDispose;
        private Dictionary<string, int> files;
        private List<string> checkedTags;
        private Logging logger;
        private Button buttonFlashing = null;
        private FileNameBuilder fileNameCreator;
        private SourceDialog sourceAdd;
        private DynamicButtons buttonbuilder;
        private SortImgSettings storedSettings;
        private ThumbnailController thumbController;
        private ThumbnailBuilder thumbnailBuilder;
        private ImageMatcherSpeed imageMatcher;
        private ImageViewer activeImageViewer;
        private Button activePreviewButton;
        private PreviewLayer previewPanel;
        private ProcessingDialog fmProgress = null;
        private Panel panelinner;
        private Panel panelload;
        private ToolTip imageInfo;
        private List<ImageViewer> selectedImageViewers;

        private event ThumbnailImageEventHandler OnImageSizeChanged;

        //Initalized set variables
        private int deskHeight = Screen.PrimaryScreen.Bounds.Height;
        private int deskWidth = Screen.PrimaryScreen.Bounds.Width;

        private int ImageSize
        {
            get { return (64 * (trackBarSize.Value + 1)); }
        }

        delegate void DelegateAddImage(string imageFilename);
        private DelegateAddImage addImage;
        private void thumbControllerStart(object sender, ThumbnailControllerEventArgs e) { }
        private void SortImg_Load(object sender, EventArgs e) { }

        private void GetSelectedImageViewers()
        {
            //Clear before next selection
            selectedImageViewers.Clear();
            foreach (ImageViewer c in flowLayoutPanelMain.Controls) {
                if (selection.IntersectsWith(c.Bounds)) {
                    selectedImageViewers.Add(c);
                }
            }
            FixActiveSelection();
        }

        private void ThumbControllerAdd(object sender, ThumbnailControllerEventArgs e)
        {
            AddImage(e.ImageFilename);
            Invalidate();

            if (firstImage == false) {
                activeImageViewer = (ImageViewer)flowLayoutPanelMain.Controls[0];
                FixActiveSelection();
                currentImageFocus = activeImageViewer.ImageLocation;
                SetPicture();
                firstImage = true;
            }
        }

        private void ThumbControllerEnd(object sender, ThumbnailControllerEventArgs e)
        {
            if (InvokeRequired) {
                Invoke(new ThumbnailControllerEventHandler(ThumbControllerEnd), sender, e);
            }
        }

        private void AddImage(string imageFilename)
        {
            if (InvokeRequired) {
                Invoke(addImage, imageFilename);
            } else {
                int size = ImageSize;
                ImageViewer imageViewer = new ImageViewer {
                    Dock = DockStyle.Bottom,
                    Width = size,
                    Height = size,
                    IsThumbnail = true
                };
                imageViewer.LoadImage(imageFilename, thumbnailBuilder);
                imageViewer.MouseClick += new MouseEventHandler(ImageViewer_MouseClick);
                imageViewer.MouseDown += new MouseEventHandler(flowLayoutPanelMain_MouseDown);
                imageViewer.MouseMove += new MouseEventHandler(flowLayoutPanelMain_MouseMove);
                imageViewer.MouseUp += new MouseEventHandler(flowLayoutPanelMain_MouseUp);

                OnImageSizeChanged += new ThumbnailImageEventHandler(imageViewer.ImageSizeChanged);
                flowLayoutPanelMain.Controls.Add(imageViewer);
            }
        }

        private void FixActiveSelection()
        {
            foreach (ImageViewer item in flowLayoutPanelMain.Controls) {
                if (selectedImageViewers.Contains(item)) {
                    item.IsActive = true;
                } else if (activeImageViewer == item) {
                    item.IsActive = true;
                } else {
                    item.IsActive = false;
                }
            }
        }

        private void ImageViewer_MouseClick(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) != Keys.None && (e.Button & MouseButtons.Left) == MouseButtons.Left) {
                ImageViewer selectedViewer = (ImageViewer)sender;
                if (selectedImageViewers.Contains(selectedViewer)) {
                    selectedImageViewers.Remove(selectedViewer);
                    if (selectedImageViewers.Count > 0) {
                        activeImageViewer = selectedImageViewers[0];
                    } else {
                        checkController(true);
                    }
                } else {
                    activeImageViewer = selectedViewer;
                    selectedImageViewers.Add(selectedViewer);
                }
                FixActiveSelection();
                SetPicture();
            } else if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                selectedImageViewers.Clear();
                activeImageViewer = (ImageViewer)sender;
                currentImageFocus = activeImageViewer.ImageLocation;
                FixActiveSelection();
                SetPicture();
            } else {
                // Right click, thus is a request to remove the preview image
                selectedImageViewers.Clear();
                ImageViewer oldImageViewer = activeImageViewer;
                activeImageViewer = (ImageViewer)sender;
                if (currentImageFocus == activeImageViewer.ImageLocation) {
                    MessageBox.Show("Can't remove a highlighted image from queue");
                } else {
                    activeImageViewer.Dispose();
                    activeImageViewer = oldImageViewer;
                    Progressupdate(1);
                    FixActiveSelection();
                }
            }
            checkController(false);
        }

        private void TrackBarSize_ValueChanged(object sender, EventArgs e)
        {
            try {
                OnImageSizeChanged(this, new ThumbnailImageEventArgs(ImageSize));
            } catch (Exception) {
            }
        }

        //Main constructor for the form
        public SortImg()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Text = string.Format("SortImg (Ver. {0})", version);

            DoubleBuffered = true;
            is64bit = Utils.Is64BitOperatingSystem(); //Check address space for recycle bin strut construction diffrences.
            if (is64bit) {
                util64 = new Utils64();
            } else {
                util32 = new Utils32();
            }
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            thumbnailBuilder = new ThumbnailBuilder();
            addImage = new DelegateAddImage(this.AddImage);
            thumbController = new ThumbnailController();
            thumbController.OnStart += new ThumbnailControllerEventHandler(thumbControllerStart);
            thumbController.OnAdd += new ThumbnailControllerEventHandler(ThumbControllerAdd);
            thumbController.OnEnd += new ThumbnailControllerEventHandler(ThumbControllerEnd);

            KeyUp += new KeyEventHandler(Key);
            imageInfo = new ToolTip();
            imageMatcher = new ImageMatcherSpeed();
            logger = new Logging();
            buttonbuilder = new DynamicButtons();
            Closing += new CancelEventHandler(SortImg_Closing);
            fileCopyedSource = new ArrayList();
            fileCopyedDestination = new ArrayList();
            buttonDispose = new ArrayList();
            fileNameCreator = new FileNameBuilder(false);
            checkedTags = new List<string>();
            selectedImageViewers = new List<ImageViewer>();
            storedSettings = new SortImgSettings(Application.StartupPath, logger);
            storedSettings.loadSettings(true, true);
            sourceAdd = new SourceDialog(storedSettings);
        }

        private void SortImg_Closing(object sender, CancelEventArgs e)
        {
            try {
                logger.closeLog(logline);
            } catch {
                System.Diagnostics.Debug.WriteLine("Logger not started");
            }
            System.Diagnostics.Debug.WriteLine("Closing");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (deletAll) {
                CopyDelete();
            } else {
                string deleteOp = "INCORRECT";
                DeleteDialog dDialog = new DeleteDialog();
                dDialog.StartPosition = FormStartPosition.CenterParent;
                if (dDialog.ShowDialog() == DialogResult.OK) {
                    deleteOp = dDialog.GetString();
                }
                logger.writeConsole(deleteOp);
                if (deleteOp == "INCORRECT") {
                    logger.writeConsole("No delete type given");
                } else if (deleteOp == "CANCEL") {
                    logger.writeConsole("Delete pick canceled");
                } else if (deleteOp == "ALLBIN") {
                    deletAll = true;
                    deletype = 1; //Bin
                    CopyDelete();
                } else if (deleteOp == "THISBIN") {
                    deletype = 1; //Bin
                    CopyDelete();
                } else if (deleteOp == "ALLMARK") {
                    deletAll = true;
                    deletype = 0; //Bin
                    CopyDelete();
                } else if (deleteOp == "THISMARK") {
                    deletype = 0; //Bin
                    CopyDelete();
                } else {
                    logger.writeConsole("Fall through statment on delete");
                }
            }
        }

        //Copy to dup folder button handler
        private void ToDupButton_Click(object sender, EventArgs e)
        {
            Copy(dupFold, null);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.closeLog(logline);
            Close();
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appreset();
        }

        private void AboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutDialog s = new AboutDialog();
            if (s.ShowDialog() == DialogResult.OK) { }
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Resources.unimplementedString);
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (fileCopyedSource.Count != 0 && fileCopyedSource != null) {
                string undosource = (string)fileCopyedSource[fileCopyedSource.Count - 1];
                string undodest = (string)fileCopyedDestination[fileCopyedDestination.Count - 1];
                Button but = (Button)buttonDispose[buttonDispose.Count - 1];
                Undoer(undodest, undosource, but);
                fileCopyedSource.RemoveAt(fileCopyedSource.Count - 1);
                fileCopyedDestination.RemoveAt(fileCopyedDestination.Count - 1);
                buttonDispose.RemoveAt(buttonDispose.Count - 1);
            } else if (fileCopyedSource.Count == 0 || fileCopyedSource == null) {
                MessageBox.Show("No image moves to undo");
            } else {
                MessageBox.Show("Undo failed");
            }
        }

        // Handler for adding another folder to the list of output folders
        private void FoldAdd_Click(object sender, EventArgs e)
        {
            if (curfold < 63) {
                Pick(curfold);
            } else {
                MessageBox.Show("Sorry, can't add more folders.");
            }
        }

        private void AddFolders_Click(object sender, EventArgs e)
        {
            if (sourceAdd.ShowDialog() == DialogResult.OK) {
                workingFolders = sourceAdd.GetSourceFolders();
                sourceCount = sourceAdd.GetSourceCount();
                sortval = sourceAdd.GetSortVal();
                fileNameCreator.duplicateFolder = workingFolders[dupFold];
                storedSettings.saveSettings();
            }
            DisableButtons(false);
            finalFold();
        }

        private void DisableButtons(bool disable)
        {
            if (disable == true) {
                toDupButton.Enabled = false;
                Delete.Enabled = false;
                buttonLoadMore.Enabled = false;
                skipButton.Enabled = false;
                trackBarSize.Enabled = false;
                Undo.Enabled = false;
                foldAdd.Enabled = false;
                toDupButton.Enabled = false;
                butOrignText.Enabled = false;
                addTag.Enabled = false;
                pictureBox1.Enabled = false;
                tagList.Enabled = false;
            } else if (disable == false) {
                toDupButton.Enabled = true;
                Delete.Enabled = true;
                buttonLoadMore.Enabled = true;
                skipButton.Enabled = true;
                trackBarSize.Enabled = true;
                Undo.Enabled = true;
                foldAdd.Enabled = true;
                toDupButton.Enabled = true;
                butOrignText.Enabled = true;
                addTag.Enabled = true;
                pictureBox1.Enabled = true;
                tagList.Enabled = true;
            }
        }

        /// <summary>
        /// Sets the picture box to the picture that the program is currently pointing to. Also the
        /// way the picture is displayed
        /// </summary>
        private void SetPicture()
        {
            try {
                string imagePath = GetFilePath();

                if (imagePath == "") {
                    pictureBox1.Image = Properties.Resources.fill;
                } else if (!File.Exists(imagePath)) {
                    MessageBox.Show("That image has been moved already!");
                    UpdatePreview(true, null, false);
                    Progressupdate(1);
                } else {
                    Image tmpImage = Image.FromFile(imagePath);
                    isAnimated = ImgUtils.IsAnimated(imagePath, tmpImage);

                    try {
                        name.Text = "...\\" + Path.GetFileName(imagePath);
                        newName.Text = "..." + fileNameCreator.fileNameBuilder(GetFilePath(), "", checkedTags, renameIteration)[0];
                    } catch (InvalidOperationException) { }

                    try {
                        pictureBox1.Image = new Bitmap(tmpImage);
                        tmpImage.Dispose();

                        Invalidate();
                    } catch (Exception ex) {
                        pictureBox1.Image = Properties.Resources.corrupt;
                        logger.writeLogError("Issue setting picture", ex);
                    }
                }
            } catch (IOException e) {
                pictureBox1.Image = Properties.Resources.corrupt;
                logger.writeLog("Picture Likely Corrupt", 0);
                logger.writeConsoleError("Picture likely corrupt", e);
            }
        }

        /// <summary>
        /// Get the file parth of the current focus of the program
        /// </summary>
        /// <returns>String containing the file path</returns>
        private string GetFilePath()
        {
            if (currentImageFocus != "" && currentImageFocus != null) {
                allowMove = true;
                return currentImageFocus;
            } else {
                allowMove = false; //Block moving if no valid image is shown
                return "";
            }
        }

        private void processImageDirectory()
        {
            //  FileCopyedsource = new ArrayList();
            //  FileCopyeddest = new ArrayList();
            //  ButtonDispose = new ArrayList();

            firstImage = false;
            allowMove = true;

            thumbController.SortValue = sortval;
            for (int i = 0; i < sourceCount; i++) {
                if (workingFolders[i] != null) {
                    thumbController.LoadFolder(workingFolders[i]);
                }
            }
            int tempvar = (thumbController.fileCount + progress);
            label1.Text = Convert.ToString(tempvar);
            progressBar1.Maximum = tempvar;
            thumbController.LoadSet();
        }

        private void moveImage(string source, string destination, int iter, Button but)
        {
            string[] tempnames = new string[2];
            tempnames = fileNameCreator.fileNameBuilder(source, destination, checkedTags, iter);
            string dest = tempnames[0];
            string dest2 = tempnames[1];
            try {
                if (!File.Exists(source)) {
                    MessageBox.Show("That image has been moved already!");
                    // UpdatePreview(true, null, false);
                } else if (File.Exists(dest)) {
                    // Duplicate file name check. This is a basic 1 to 1 file check
                    long size1 = imageMatcher.CalcSize(source);
                    long size2 = imageMatcher.CalcSize(dest);
                    if ((size1 == size2) && (iter == 0)) {
                        // There are the same name and same size and it is not currently iterating
                        dupPopup(source, dest, dest2, destination, but, size2, iter, false, "Same File");
                    } else {
                        iter++;
                        moveImage(source, destination, iter, but);
                    }
                } else if (allowMove) {
                    if (storedSettings.DuplicateCheckMode == 1) {
                        if ((imageMatcher.CheckImage(source, dest) == true)) {
                            logger.writeConsole("File " + dest + " is not a duplicate");
                            ioMove(source, dest, but);
                            logger.writeLog("Moving File", logline);
                            logger.writeLog(("Source " + source + "||" + "Dest " + dest), logline);
                        } else {
                            long size2 = imageMatcher.CalcSize(source);
                            string he = imageMatcher.GetLastMatch();
                            dupPopup(source, he, dest2, destination, but, size2, iter, true, "Visual Duplicate");
                        }
                    } else {
                        logger.writeConsole("File " + dest + " is not a duplicate");
                        ioMove(source, dest, but);
                        logger.writeLog("Moving File", logline);
                        logger.writeLog(("Source " + source + "||" + "Dest " + dest), logline);
                    }
                } else {
                    MessageBox.Show("Not allowed to move this file!");
                }
            } catch (Exception e) {
                logger.writeLogError("Issue moving file", e);
            }
        }

        private void dupPopup(string source, string dest, string dest2, string Destination, Button but, long size, int iter, bool noRename, string text)
        {
            DupDialog dupDia = new DupDialog(Path.GetFileName(source), dest, size, noRename, text);
            dupDia.StartPosition = FormStartPosition.CenterParent;
            if (dupDia.ShowDialog() == DialogResult.OK) {
                string selection = dupDia.GetString();
                if (selection == "DELETE") {
                    Deleter(source);
                } else if (selection == "DUP") {
                    moveDup(source, dest2, iter, but);
                    logger.writeLog("Double up file moving to dup directory", logline);
                    logger.writeLog(("Source " + source + "||" + "Dest " + dest2), logline);

                } else if (selection == "RENAME") {
                    iter++;
                    logger.writeConsole("iterating renamer");
                    moveImage(source, Destination, iter, but);
                }
            }
        }

        private void moveDup(string source, string destination, int iter, Button but)
        {
            try {
                if (File.Exists(destination) == false && allowMove) {
                    ioMove(source, destination, but);
                } else if (!allowMove) {
                    MessageBox.Show("Not allowed to move this file!");
                } else {
                    iter++;
                    string tempPath = Path.GetDirectoryName(destination);
                    string tempFileName = Path.GetFileNameWithoutExtension(destination);
                    string tempExt = Path.GetExtension(destination);
                    string newdestination = tempPath + " \\" + tempFileName + "\\" + "_" + iter + tempExt;
                    moveDup(source, newdestination, iter, but);
                }
            } catch (Exception e) {
                logger.writeLogError("Issue moving duplicate", e);
            }
        }

        private void ioMove(string source, string destination, Button but)
        {
            try {
                fileCopyedSource.Add(source);
                fileCopyedDestination.Add(destination);
                buttonDispose.Add(but);
                logline++;
                File.Move(source, destination);
            } catch (IOException e) {
                logger.writeLogError("Issue moving file", e);
                throw;
            }
        }

        /// <summary>
        /// Update call for the thumbnail preview
        /// </summary>
        /// <param name="dispo">dispose the current selected image</param>
        /// <param name="filename">file to insert: Accepts null</param>
        /// <param name="toFront">Load file to front of que or back</param>
        /// <param name="updateProg">Load file to front of que or back</param>
        private void UpdatePreview(bool dispo, string filename, bool toFront)
        {
            // activeImageViewer.IsActive = false;
            FixActiveSelection();
            if (dispo == true) {
                activeImageViewer.Dispose();
            }
            if (filename != null) {
                if (toFront) {
                    thumbController.PushFile(filename);
                } else {
                    thumbController.QueFile(filename);
                }
            }
            checkController(true);
        }

        private void checkController(bool getFront)
        {
            if (this.flowLayoutPanelMain.Controls.Count < (thumbController.ImageLoadAmount / 2)) //Check if to load more images from the queue
            {
                thumbController.LoadSet();
            }
            if (this.flowLayoutPanelMain.Controls.Count > 0) //Check if there are still images to process
            {
                if (getFront == true) {
                    activeImageViewer = (ImageViewer)this.flowLayoutPanelMain.Controls[0];
                    // activeImageViewer.IsActive = true;
                    currentImageFocus = activeImageViewer.ImageLocation;
                    FixActiveSelection();
                    SetPicture();
                }
            } else //No images in the preview panel
              {
                currentImageFocus = ""; //No image, no focus
                SetPicture();
                //  int leftoverfiles = Convert.ToInt16(label1.Text) - progress;
                MessageBox.Show("Out of images");
                DisableButtons(true); //Disable buttons till more folders are added
            }
        }

        /// <summary>
        /// Increment the progress bar
        /// </summary>
        private void Progressupdate(int incdec)
        {
            if (incdec == 1 && allowMove == true) {
                progress++;
                progressBar1.Increment(1);
            } else if (incdec == 2) {
                progress--;
                progressBar1.Increment(-1);
            } else if (incdec == 3) { }//Do nothing
            textBox7.Text = Convert.ToString(progress);
        }


        /// <summary>
        /// This is the main methord called via buttons to copy file. Handles end of file list special case
        /// otherwise just calls mover() and next()
        /// </summary>
        /// <param name="num">Refrence to the place in array of the dest folder</param>
        private void Copy(int num, Button but)
        {
            String fileName = GetFilePath();
            if (fileName == "NULL") {
                MessageBox.Show("Can't move nothing!");
            } else {
                //If there is a mutiselect
                if (selectedImageViewers.Count > 0) {
                    foreach (ImageViewer viewer in selectedImageViewers) {
                        activeImageViewer = viewer;
                        //activeImageViewer.IsActive = true;
                        FixActiveSelection();
                        currentImageFocus = viewer.ImageLocation;
                        moveImage(currentImageFocus, workingFolders[num], 0, but);

                        Progressupdate(1); //Update the progress bar      
                        UpdatePreview(true, null, false);
                    }
                    selectedImageViewers.Clear();
                } else {
                    moveImage(fileName, workingFolders[num], 0, but);
                    Progressupdate(1); //Update the progress bar
                    UpdatePreview(true, null, false);
                }

            }
        }

        /// <summary>
        /// Calls Deleter and the Update
        /// </summary>
        private void CopyDelete()
        {
            String fileName = GetFilePath();
            if (fileName == "NULL") {
                MessageBox.Show("Can't delete nothing!");
            } else {
                Deleter(fileName);
                Progressupdate(1); //Update the progress bar
                UpdatePreview(true, null, false);
            }
        }

        /// <summary>
        /// Pick new folder
        /// </summary>
        /// <param name="num">Folder number</param>
        private void Pick(int num)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (Directory.Exists(folderBrowserDialog1.SelectedPath)) {
                    if (Checkfolder(workingFolders, folderBrowserDialog1.SelectedPath) == false) {
                        MessageBox.Show("The two chosen folders are the same. Please pick different folders");
                    } else {
                        try {
                            workingFolders[num] = folderBrowserDialog1.SelectedPath;
                            fileNameCreator.duplicateFolder = workingFolders[dupFold];
                            buttonPictureToggle[num] = 0;
                            GenerateControl(num);
                            curfold++;
                        } catch (IOException e) {
                            logger.writeLogError("Issue getting folder name from dialog", e);
                            MessageBox.Show("Issue encountered, please re-pick folder");
                        }
                    }
                } else {
                    MessageBox.Show("Directory not created yet, please re-pick folder");
                }
            }
        }

        /// <summary>
        /// Resets the application
        /// </summary>
        private void Appreset()
        {
            try {
                logger.closeLog(logline);
            } catch (Exception e) {
                logger.writeConsoleError("Issue closing log", e);
            }
            Application.Restart();
            return;
        }

        /// <summary>
        /// Compares and array to a string. Used to check folder integrity
        /// </summary>
        /// <param name="a">Array of folders</param>
        /// <param name="b">Folder to check against</param>
        /// <returns></returns>
        private bool Checkfolder(string[] a, String b)
        {
            foreach (String st in a) {
                if (st == b) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Depending on the setting of the combobox
        /// If 0: Copys file to dup folder with the file name taged
        /// If 1: Deletes to recyc bin
        /// </summary>
        /// <param name="fileparth">Parth of file to delete</param>
        private void Deleter(string fileparth)
        {
            if (deletype == 0) {
                string name = Path.GetFileName(fileparth);
                name = "zz_DELETE_" + name;
                string des = workingFolders[dupFold];
                des = des + '\\' + name;
                moveDup(fileparth, des, 0, null);
                logger.writeLog("Marked for deletion", logline);
                logger.writeLog(("Source " + fileparth + "||" + "Dest " + des), logline);
            } else if (deletype == 1) {
                logline++;

                if (is64bit) {
                    util64.moveToRecycle(fileparth);
                } else {
                    util32.moveToRecycle(fileparth);
                }

                logger.writeLog("Sent to recycling bin", logline);
                logger.writeLog(("Source " + fileparth + "||" + "Dest BIN"), logline);
            }
        }

        // Generates the control in this case it is for the output folders    
        private void GenerateControl(int num)
        {
            String path = workingFolders[num];
            int half = pContainer.Width / 2;
            Button dynamicButton = buttonbuilder.DynamicButton(contextMenuStrip1, curfold, half);
            dynamicButton.MouseClick += new MouseEventHandler(Button_Click);
            dynamicButton.MouseEnter += new EventHandler(dynamicButton_MouseEnter);
            Button dynamicPicture = buttonbuilder.DynamicPicture(curfold, Path.GetFileName(path), dynamicButton);
            SetbuttonImage(dynamicPicture, path, num);
            dynamicPicture.MouseDown += new MouseEventHandler(Picturebox_Click);
            pContainer.Controls.Add(dynamicButton);
            pContainer.Controls.Add(dynamicPicture);
        }

        private void dynamicButton_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender; //get the button that was clicked
            lastButtonIndex = Convert.ToInt16(clickedButton.Name.Substring("dynamicButton".Length));
        }

        // Sets the image for the button
        private void SetbuttonImage(Button but, string path, int fold)
        {
            string filepath = Returnfirstimage(path);
            if (filepath != null) {
                FileStream fs;
                fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                but.BackgroundImage = new Bitmap(System.Drawing.Image.FromStream(fs).GetThumbnailImage(but.Size.Width, but.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
                fs.Close();
                buttonPictureToggle[fold] = 1;
            } else {
                but.BackgroundImage = global::SortImage.Properties.Resources.zoom_32x32_32;
                buttonPictureToggle[fold] = 0;
            }
        }

        private void Button_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button) {
                case MouseButtons.Left:
                    Button clickedButton = (Button)sender; //get the button that was clicked
                    string index = clickedButton.Name.Substring("dynamicButton".Length);
                    Button tempbut = (Button)pContainer.Controls.Find("dynamicPictureBox" + index, true)[0];
                    Copy(Convert.ToInt16(index), tempbut);
                    string foldpath = workingFolders[Convert.ToInt16(index)];
                    if (buttonPictureToggle[Convert.ToInt16(index)] == 0) {
                        SetbuttonImage(tempbut, foldpath, Convert.ToInt16(index));
                    }
                    break;
                case MouseButtons.Right:
                    MessageBox.Show("Unimplemented (Folder re-pick)");
                    break;
                case MouseButtons.Middle:
                    break;
                default:
                    break;
            }
        }


        private void Hide_Main(bool show)
        {
            if (show) {
                pContainer.Visible = true;
                progressBar1.Visible = true;
                splitContainer1.Visible = true;
                foldAdd.Visible = true;
                Undo.Visible = true;
            } else {
                pContainer.Visible = false;
                progressBar1.Visible = false;
                splitContainer1.Visible = false;
                foldAdd.Visible = false;
                Undo.Visible = false;
            }
        }


        // Handler for clicking on the preview pick, showing the folder preview 
        private void Picturebox_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button) {
                case MouseButtons.Left:

                    Button clickedButton = (Button)sender;
                    string index = clickedButton.Name.Substring("dynamicPictureBox".Length);
                    fileparth = workingFolders[Convert.ToInt16(index)];
                    PreviewBuild(clickedButton);

                    break;
                case MouseButtons.Right:
                    Button clickeddButton = (Button)sender;
                    if (clickeddButton.ForeColor == Color.White) {
                        clickeddButton.ForeColor = Color.Black;
                    } else {
                        clickeddButton.ForeColor = Color.White;
                    }
                    break;
                case MouseButtons.Middle:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Special case copy for key presses
        /// </summary>
        /// <param name="buttonPos">This is the index of the button starts at "33"</param>
        private void KeyCopy(int buttonPos)
        {
            string index = Convert.ToString(buttonPos);
            Button tempbut = (Button)pContainer.Controls.Find("dynamicPictureBox" + index, true)[0];
            flashButtonOn((Button)pContainer.Controls.Find("dynamicButton" + index, true)[0]);
            Copy(Convert.ToInt16(index), tempbut);
            string foldpath = workingFolders[Convert.ToInt16(index)];
            if (buttonPictureToggle[Convert.ToInt16(index)] == 0) {
                SetbuttonImage(tempbut, foldpath, Convert.ToInt16(index));
            }
        }

        // Handles key presses. These are hardcoded to the first 6 equivlent buttons on form and delete as well as backspace for undo
        private void Key(Object o, KeyEventArgs e)
        {
            List<int> keyBinds = storedSettings.GetKeyBinds();
            if (Convert.ToInt16(keyBinds[0]) == e.KeyValue) {
                Delete_Click(null, null);
                flashButtonOn(Delete);
            } else if (Convert.ToInt16(keyBinds[1]) == e.KeyValue) {
                Delete_Click(null, null);
                flashButtonOn(Delete);
            } else if (Convert.ToInt16(keyBinds[2]) == e.KeyValue) {
                Undo_Click(null, null);
                flashButtonOn(Undo);
            } else if (Convert.ToInt16(keyBinds[3]) == e.KeyValue) // TODO: Should be able to make this somewhat dynamic...
              {
                if (workingFolders[dupFold + 1] != null) {
                    KeyCopy(dupFold + 1);
                }
            } else if (Convert.ToInt16(keyBinds[4]) == e.KeyValue) {
                if (workingFolders[dupFold + 2] != null) {
                    KeyCopy(dupFold + 2);
                }
            } else if (Convert.ToInt16(keyBinds[5]) == e.KeyValue) {
                if (workingFolders[dupFold + 3] != null) {
                    KeyCopy(dupFold + 3);
                }
            } else if (Convert.ToInt16(keyBinds[6]) == e.KeyValue) {
                if (workingFolders[dupFold + 4] != null) {
                    KeyCopy(dupFold + 4);
                }
            } else if (Convert.ToInt16(keyBinds[7]) == e.KeyValue) {
                if (workingFolders[dupFold + 5] != null) {
                    KeyCopy(dupFold + 5);
                }
            } else if (Convert.ToInt16(keyBinds[8]) == e.KeyValue) {
                if (workingFolders[dupFold + 6] != null) {
                    KeyCopy(dupFold + 6);
                }
            } else {
            }
        }

        // Splash image for when the program is loading the preview 
        // Note: This is used due to how slow it is loading the thumbnails
        // should be changed if I can find how to load thumbnails better
        private void Loading()
        {
            panelload = new Panel() {
                Size = mainPanel.Size,
                BackgroundImage = global::SortImage.Properties.Resources.loading,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            mainPanel.Controls.Add(panelload);
            panelload.BringToFront();
        }

        // Handeler for the close button for the preview panel
        private void ClosePanelButton_Click(object sender, EventArgs e)
        {
            panelinner.Dispose();
            Hide_Main(true);
            nextCount = 0;
            fileparth = null;
        }

        private void PreviewBuild(Button clickedButton)
        {
            if (nextCount > 0) {
                panelinner.Dispose();
            }
            activePreviewButton = clickedButton;

            panelinner = new TableLayoutPanel();
            Loading();

            Hide_Main(false);

            previewPanel = new PreviewLayer(mainPanel.Size, fileparth, activePreviewButton, nextCount);
            previewPanel.ClosePanelButton.Text = "Close";
            previewPanel.ClosePanelButton.Click += new EventHandler(ClosePanelButton_Click);
            previewPanel.nextSetButton.Text = "More...";
            previewPanel.nextSetButton.Click += new EventHandler(button1_Click);
            mainPanel.Controls.Add(previewPanel.mainpanel);
            panelinner = previewPanel.mainpanel;
            panelload.Dispose();
            panelinner.Dock = DockStyle.Fill;
            panelinner.BringToFront();
            nextCount++;
        }



        // Loads the preview panel and creates the buttons for it
        private void button1_Click(object sender, EventArgs e)
        {
            PreviewBuild(activePreviewButton);
        }

        // Methord to handle the undo, that is moving a file back to where it came from
        private void Undoer(String source, String Destination, Button but)
        {
            try {
                if (File.Exists(Destination)) {
                    logger.writeLog("Error copying back file for undo (Major issue)", logline);
                } else {
                    System.IO.File.Move(source, Destination);
                    logline++;
                    logger.writeLog("Moving file (Undo)", logline);
                    logger.writeLog(("Source " + source + "||" + "Dest " + Destination), logline);
                    if (but != null) {
                        string index = but.Name.Substring("dynamicPictureBox".Length);
                        SetbuttonImage(but, Path.GetDirectoryName(source), Convert.ToInt16(index));
                    }
                    if ((Path.GetExtension(source) != ".gif") && (but != null) && (storedSettings.DuplicateCheckMode == 1)) {
                        imageMatcher.UndoLastHash();
                    }
                    UpdatePreview(false, Destination, true);
                    Progressupdate(2); //Update the progress bar
                }
            } catch (IOException e) {
                logger.writeLogError("Issue undoing file move", e);
            }
            SetPicture();
        }

        /// <summary>
        /// Returns the first image from a specifyed parth. Used for preview image on buttons
        /// </summary>
        /// <param name="path">Directory to load</param>
        /// <returns></returns>
        private string Returnfirstimage(string path)
        {
            string[] szFiles;
            foreach (string szType in fileNameCreator.makeFileTypes()) {
                szFiles = Directory.GetFiles(path, szType);
                if (szFiles.Length > 0) {
                    return szFiles[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Handler for the skip button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skipbut_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (activeImageViewer != null) {
                filename = activeImageViewer.ImageLocation;
                UpdatePreview(true, filename, false);
                Progressupdate(3); //Update the progress bar
            }
        }

        /// <summary>
        /// Sets the button to be the relivent image
        /// </summary>
        /// <param name="but">Button that is used</param>
        /// <param name="path">Parth to Image that is used</param>
        public static void SetbuttonIm(Button but, string path)
        {
            FileStream fs;
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            but.BackgroundImage = new Bitmap(System.Drawing.Image.FromStream(fs).GetThumbnailImage(but.Size.Width, but.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallbackStatic), IntPtr.Zero));
            fs.Close();
        }

        // Needed to stop exceptions
        public static bool ThumbnailCallbackStatic()
        {
            return true;
        }
        public bool ThumbnailCallback()
        {
            return true;
        }

        // Adds text to the tag list
        private void addTag_Click(object sender, EventArgs e)
        {
            string tagText = tag.Text;
            if (firstTag == 0) //Special case for first tag to remove the example tag
            {
                tagList.Items.RemoveAt(0);
                tagList.Items.Add(tagText);
                firstTag = 1;
            } else {
                tagList.Items.Add(tagText);
            }
            checkedTags = getTags(tagList);
            newName.Text = "..." + fileNameCreator.fileNameBuilder(GetFilePath(), "", checkedTags, renameIteration)[0];
        }

        private void pictureBox1_Info_update(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try {
                if (e.X != lastToolTipX || e.Y != lastToolTipY) {
                    imageInfo.Show(currentToolTipText, mainPanel, splitContainer1.Panel1.Width + e.X + 25, e.Y + 10);
                    lastToolTipX = e.X;
                    lastToolTipY = e.Y;
                }
            } catch (NullReferenceException) { }
        }

        // Creates the info tooltip for the main picture box
        private void pictureBox_Info_create(object sender, EventArgs e)
        {
            int iw = pictureBox1.Image.Width;
            int ih = pictureBox1.Image.Height;
            currentToolTipText = iw + " : " + ih + "\n" + GetFilePath();
            imageInfo.Active = true;
        }

        // Will remove tooltip once mouse is removed from main image
        private void pictureBox_Info_remove(object sender, EventArgs e)
        {
            imageInfo.Active = false;
        }

        // Handler for when a item in the tag list is selected or un-selected
        private void tagList_SelectedValueChanged(object sender, EventArgs e)
        {
            checkedTags = getTags(tagList);
            newName.Text = "..." + fileNameCreator.fileNameBuilder(GetFilePath(), "", checkedTags, renameIteration)[0];
        }

        //Toggle between using orignal file name or not
        private void butOrignText_Click(object sender, EventArgs e)
        {
            if (fileNameCreator.orginalText == false) //Toggle
            {
                fileNameCreator.orginalText = true;
                butOrignText.BackColor = Color.Gray; //Visual cue for toggle
            } else {
                fileNameCreator.orginalText = false;
                butOrignText.BackColor = Color.Transparent; //Visual cue for toggle
            }
            newName.Text = "..." + fileNameCreator.fileNameBuilder(GetFilePath(), "", checkedTags, renameIteration)[0];
        }

        // Handler for clicking on the main picture box. For animating GIFs and showing images in original dimensions
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string focusImagePath = GetFilePath();
            if (focusImagePath == "NULL") {
                MessageBox.Show("Not a valid image");
            } else {
                bool isaGif = false;
                if (Path.GetExtension(focusImagePath) == ".gif") {
                    isaGif = true;
                }
                PreviewImageDialog gifDialog = new PreviewImageDialog(focusImagePath, isaGif);
                gifDialog.StartPosition = FormStartPosition.CenterParent;
                gifDialog.MaximumSize = new Size(deskWidth - 40, deskHeight - 40);
                try {
                    if (gifDialog.ShowDialog() == DialogResult.OK) {
                        gifDialog.Dispose();
                    }
                } catch (Exception ex) {
                    gifDialog.Dispose();
                    logger.writeConsoleError("Gif animation error", ex);
                    MessageBox.Show("'.GIF' closed due to GDI+ error in playback");
                }
            }
        }

        // Draws a "Play" button on main picture box if the image is a .gif
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isAnimated == true) {
                using (Font myFont = new Font("Arial", 12)) {
                    Graphics g = e.Graphics;
                    Point point1 = new Point(((pictureBox1.Width / 2) - 30) + 10, ((pictureBox1.Height / 2) - 30) + 5);
                    Point point2 = new Point(((pictureBox1.Width / 2) - 30) + 10, ((pictureBox1.Height / 2) - 30) + 55);
                    Point point3 = new Point(((pictureBox1.Width / 2) - 30) + 55, ((pictureBox1.Height / 2) - 30) + 30);
                    Point[] playPoints = { point1, point2, point3, };
                    Rectangle r = new Rectangle((pictureBox1.Width / 2) - 30, (pictureBox1.Height / 2) - 30, 60, 60);
                    g.FillEllipse(Brushes.Gray, r);
                    g.FillPolygon(Brushes.Green, playPoints);
                }
            }
        }

        // Toolstrip for Config menu
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> keyBinds = storedSettings.GetKeyBinds();
            List<string> keyNames = storedSettings.GetKeyNames();
            ConfigDialog a = new ConfigDialog(storedSettings);
            if (a.ShowDialog() == DialogResult.OK) {
                // storedSettings.DuplicateCheckMode = a.getDupType();
                //Only Reload keyboinds              
                storedSettings.saveSettings();
                storedSettings.loadSettings(false, false); //Reload Keys
            }
        }

        private void showLastErrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorDialog errorDialog = new ErrorDialog(logger.getLastError());
            errorDialog.StartPosition = FormStartPosition.CenterParent;
            if (errorDialog.ShowDialog() == DialogResult.OK) { }
        }

        // Triggered when picking the duplicate folder thus the finalfold
        private void finalFold()
        {
            try {
                processImageDirectory();
                // Recreate the logger with the new paras
                logger = new Logging(workingFolders[dupFold], storedSettings.LogValue);
                SetPicture();
            } catch (Exception ex) {
                ErrorDialog exp = new ErrorDialog(ex, "ERROR:") {
                    StartPosition = FormStartPosition.CenterParent
                };
                if (exp.ShowDialog() == DialogResult.OK) { }
            }
        }

        private delegate void ChangeProgressBarCallback();

        private void sortByMD5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debugging Tool. MD5 hash groups will be returned on completion" + Environment.NewLine + "This might take a VERY long time with more than 100 files");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (Checkfolder(workingFolders, folderBrowserDialog1.SelectedPath) == false) {
                    MessageBox.Show("Two chosen folders are the same. Please pick different folders");
                } else {
                    string fold = folderBrowserDialog1.SelectedPath;
                    Dictionary<string, int> hashCounts = new Dictionary<string, int>();
                    ImageMatcherSpeed md5Matcher = new ImageMatcherSpeed();
                    ProcessingDialog proDialog = new ProcessingDialog();
                    ThreadStart threadDelegateMD5 = delegate { md5Matcher.CheckMD5s(fold); };
                    ThreadStart threadDelegateDialog = delegate { proDialog.ShowDialog(); };
                    Thread threadMD5 = new Thread(threadDelegateMD5);
                    Thread threadDialog = new Thread(threadDelegateDialog);
                    threadMD5.Start();
                    threadDialog.Start();
                    int once = 1;
                    while (threadMD5.IsAlive) {
                        Thread.Sleep(50);

                        if (proDialog.cancel == true) {
                            threadMD5.Abort();
                            threadDialog.Abort();
                        }


                        if (once == 1 && md5Matcher.getProgressMax() >= 2) {
                            proDialog.SetProgressMax(md5Matcher.getProgressMax());
                            once = 0;
                        }
                        proDialog.UpdateProgress(md5Matcher.getProgress());

                        if (md5Matcher.getProgress() == md5Matcher.getProgressMax()) {
                            threadMD5.Join();
                            threadDialog.Join();
                        }
                    }
                    threadMD5.Abort();
                    threadDialog.Abort();
                    ArrayList fingerprints = md5Matcher.GetFingerprints();
                    int i = 0;
                    foreach (string print in fingerprints) {
                        int incer;
                        if (hashCounts.TryGetValue(print, out incer)) {
                            hashCounts[print] = incer + 1;
                        } else {
                            hashCounts.Add(print, 1);
                        }
                        i++;
                    }
                    ErrorDialog exp = new ErrorDialog(hashCounts);
                    exp.StartPosition = FormStartPosition.CenterParent;
                    if (exp.ShowDialog() == DialogResult.OK) { }
                }
            }
        }

        private void sortFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WARNING!: This operation will reset all current work" + Environment.NewLine + "---" + Environment.NewLine + "This might take a VERY long time if a lot of images are similar" + Environment.NewLine +
                "time taken can be exponental in worst case! test on subsets first");
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (Checkfolder(workingFolders, folderBrowserDialog1.SelectedPath) == false) {
                    MessageBox.Show("Folders is already in use. Please pick different folder");
                } else {
                    bwFold = folderBrowserDialog1.SelectedPath;
                    files = new Dictionary<string, int>();
                    fmProgress = new ProcessingDialog();
                    bwSortImageFolder.RunWorkerAsync();
                    fmProgress.ShowDialog(this);
                    fmProgress = null;
                }
            }
        }

        private void flashButtonOn(Button but)
        {
            buttonFlashing = but;
            buttonFlashing.BackColor = Color.Black;
            timer1.Start();
        }

        private void flashButtonOff(object sender, EventArgs e)
        {
            buttonFlashing.BackColor = Color.Transparent;
            timer1.Stop();
        }

        private List<string> getTags(CheckedListBox tagList)
        {
            List<string> localcheckedTags = new List<string>();
            foreach (string k in tagList.CheckedItems) {
                localcheckedTags.Add(k);
            }
            return localcheckedTags;
        }

        private void folderImageMergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderMergeDialog fmd = new FolderMergeDialog();
            fmd.StartPosition = FormStartPosition.CenterParent;
            if (fmd.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("Folder merge complete");
            }
        }

        private void bwSortImageFolder_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var ex = new ImageMatcherSpeed();
            files = ex.CheckDirDups(bwFold, ReportProgresshandler, e, worker);
        }

        private void bwSortImageFolder_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            fmProgress.UpdateProgress(e.ProgressPercentage);
            System.Diagnostics.Debug.WriteLine("Running" + e.ProgressPercentage);
            if (fmProgress.cancel) {
                bwSortImageFolder.CancelAsync();
            }
        }

        private void ReportProgresshandler(int percent, string state)
        {
            bwSortImageFolder.ReportProgress(percent);
            // also does the Invoke
        }

        private void bwSortImageFolder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fmProgress.cancel) {
                System.Diagnostics.Debug.WriteLine("Done");
                if (fmProgress != null) {
                    fmProgress.Hide();
                    fmProgress = null;
                }
            } else {
                string newpath = "";
                string newpath2 = "";
                int lastvalue = -1;
                List<long> lastsize = new List<long>();
                if (files.Count > 1) {
                    var sortedfiles = (from entry in files orderby entry.Value ascending select entry);
                    newpath = fileNameCreator.createDirctory(bwFold + "\\VisualDups");
                    newpath2 = fileNameCreator.createDirctory(bwFold + "\\Duplicates");
                    if (newpath != null) {
                        foreach (KeyValuePair<string, int> file in sortedfiles) {
                            if (File.Exists(file.Key)) // Duplicate file name check. This is a basic 1 to 1 file check
                            {
                                if ((file.Value == lastvalue) && lastsize.Contains(imageMatcher.CalcSize(file.Key))) {
                                    string path = Path.GetFileName(file.Key);
                                    path = file.Value + "_" + path;
                                    try {
                                        System.IO.File.Move(file.Key, newpath2 + "\\" + path);
                                    } catch (IOException) { }
                                } else {
                                    if (lastvalue == file.Value) {
                                        lastsize.Add(imageMatcher.CalcSize(file.Key));
                                    } else {
                                        lastsize.Clear();
                                        lastsize.Add(imageMatcher.CalcSize(file.Key));
                                        lastvalue = file.Value;
                                    }
                                    string path = Path.GetFileName(file.Key);
                                    path = file.Value + "_" + path;
                                    try {
                                        System.IO.File.Move(file.Key, newpath + "\\" + path);
                                    } catch (IOException) { }
                                }
                            } else {
                                System.Diagnostics.Debug.WriteLine("File already moved");
                            }
                        }
                    }
                }
                if (newpath != "") {
                    string[] tem = new string[64];
                    tem[0] = newpath;
                    tem[dupFold] = newpath2;
                    workingFolders = tem;
                    fileNameCreator.duplicateFolder = workingFolders[dupFold];
                    sourceCount = 1;
                    DisableButtons(false);
                    finalFold();
                }
                System.Diagnostics.Debug.WriteLine("Done");
                if (fmProgress != null) {
                    fmProgress.Hide();
                    fmProgress = null;
                }
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (Checkfolder(workingFolders, folderBrowserDialog1.SelectedPath) == false) {
                    MessageBox.Show("Two folders are the same. Please pick a different folder");
                } else {
                    workingFolders[lastButtonIndex] = folderBrowserDialog1.SelectedPath;
                    pContainer.Controls.Find("dynamicPictureBox" + Convert.ToString(lastButtonIndex), true)[0].Text = Path.GetFileName(workingFolders[lastButtonIndex]);
                    SetbuttonImage((Button)pContainer.Controls.Find("dynamicPictureBox" + Convert.ToString(lastButtonIndex), true)[0], workingFolders[lastButtonIndex], lastButtonIndex);
                }
            }
        }


        private void convertBmpToPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BmpToPngDialog bpd = new BmpToPngDialog();

            bpd.StartPosition = FormStartPosition.CenterParent;
            if (bpd.ShowDialog() == DialogResult.OK) {
                MessageBox.Show("Conversion done. Remember to remove old '.BMP' files!");
            }
        }

        private void buttonLoadMore_Click(object sender, EventArgs e)
        {
            thumbController.LoadSet();
        }

        private void flowLayoutPanelMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            SetSelectionRect();

            if (!isValidSelection()) {
                return;
            }

            Invalidate(); //Might not be needed
            flowLayoutPanelMain.Invalidate();


            GetSelectedImageViewers();

            //Reset selections
            selectionEnd.Y = selectionEnd.X = 0;
            selectionStart.Y = selectionStart.X = 0;
        }

        private bool isValidSelection()
        {
            if ((selection.Width > 15) && (selection.Height > 15)) {
                if (selectionEnd.Y != 0 && selectionEnd.X != 0 && selectionStart.Y != 0 && selectionStart.X != 0) {
                    return true;
                }
            }
            return false;
        }

        private void flowLayoutPanelMain_MouseDown(object sender, MouseEventArgs e)
        {
            selectionStart = flowLayoutPanelMain.PointToClient(MousePosition);
            mouseDown = true;
        }

        private void flowLayoutPanelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) {
                return;
            }

            selectionEnd = flowLayoutPanelMain.PointToClient(MousePosition);
            SetSelectionRect();
            flowLayoutPanelMain.Invalidate();
            //Invalidate();
        }
        private void SetSelectionRect()
        {
            int x, y;
            int width, height;


            x = selectionStart.X > selectionEnd.X ? selectionEnd.X : selectionStart.X;
            y = selectionStart.Y > selectionEnd.Y ? selectionEnd.Y : selectionStart.Y;

            width = selectionStart.X > selectionEnd.X ? selectionStart.X - selectionEnd.X : selectionEnd.X - selectionStart.X;
            height = selectionStart.Y > selectionEnd.Y ? selectionStart.Y - selectionEnd.Y : selectionEnd.Y - selectionStart.Y;

            selection = new Rectangle(x, y, width, height);
        }

        private void flowLayoutPanelMain_Paint(object sender, PaintEventArgs e)
        {
            if (mouseDown) {
                using (Pen pen = new Pen(Color.Black, 1F)) {
                    pen.DashStyle = DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, selection);
                }
            }
        }
    }

    public class ThumbnailImageEventArgs : EventArgs
    {
        public ThumbnailImageEventArgs(int size)
        {
            this.Size = size;
        }
        public int Size;
    }
    public delegate void ThumbnailImageEventHandler(object sender, ThumbnailImageEventArgs e);
}

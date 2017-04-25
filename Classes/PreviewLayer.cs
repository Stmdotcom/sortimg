using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using SortImage;

namespace SortImage
{
    public class PreviewLayer
    {
        public Panel mainpanel;
        public TableLayoutPanel layoutPanel;
        public Button ClosePanelButton;
        public string folder;
        public ArrayList filePaths;
        public Button callerButton;
        public Button nextSetButton;
        public ThumbnailBuilder tb;
        private FileNameBuilder fileNameBuilder;

        const string PREVIEWNAME = "dynaPictureBox";
        const int IMAGECOUNT = 18;

        public PreviewLayer(Size s, string incfolder, Button but, int page)
        {
            folder = incfolder;
            callerButton = but;
            buildLayer(s);
            addImages(s, true, page);
        }
         
        public PreviewLayer(Size s, ArrayList files, Button but, int page)
        {
            filePaths = files;
            callerButton = but;

            buildLayer(s);
            addImages(s, false, page);
        }

        public void buildLayer(Size s)
        {
            fileNameBuilder = new FileNameBuilder(false);
            tb = new ThumbnailBuilder();

            mainpanel = new Panel();
            ClosePanelButton = new Button();
            layoutPanel = new TableLayoutPanel();

            ClosePanelButton.Image = new Bitmap(global::SortImage.Properties.Resources.buttonCancel.GetThumbnailImage(ClosePanelButton.Size.Height, ClosePanelButton.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
            ClosePanelButton.ImageAlign = ContentAlignment.MiddleRight;
            ClosePanelButton.Left = mainpanel.Width - ClosePanelButton.Width + 5;

            nextSetButton = new Button();
            nextSetButton.Text = "More...";
            nextSetButton.Left = 50;
            nextSetButton.Image = new Bitmap(global ::SortImage.Properties.Resources.next.GetThumbnailImage(nextSetButton.Size.Height, nextSetButton.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
            nextSetButton.ImageAlign = ContentAlignment.MiddleRight;
           
            layoutPanel.ColumnCount = 6;
            layoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            layoutPanel.Size = new Size(s.Width, s.Height - ClosePanelButton.Height);
            layoutPanel.Location = new System.Drawing.Point(50, 50);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.AutoScroll = true;

            mainpanel.Size = s;
            mainpanel.BackColor = Color.Silver;
            mainpanel.Controls.Add(layoutPanel);
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(nextSetButton); // New
            mainpanel.Controls.Add(ClosePanelButton);
        }

        private void addImages(Size siz, bool initfolder, int page)
        {
            int i = 0;
            int loopCount = 0;
            PictureBox picbox;
            if (initfolder)
            {
                filePaths = fileNameBuilder.ProcessDirectory(folder);
            }
            int skipstep = (page * IMAGECOUNT);
            foreach (string s in filePaths)
            {
                if (loopCount < skipstep)
                {
                    loopCount++;
                }
                else
                {
                    if (i < IMAGECOUNT)
                    {
                        picbox = new PictureBox();
                        picbox.Size = new Size((int)(siz.Width * .15), (int)(siz.Width * .15));
                        picbox.Name = PREVIEWNAME + (skipstep + i);
                        picbox.Click += new EventHandler(Picturebox_Click);
                        layoutPanel.Controls.Add(picbox);
                        SetImage(picbox, s);
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
            }

            //If there was less than IMAGECOUNT images...
            if (i < IMAGECOUNT) {
                 nextSetButton.Hide();
            }

        }

        public void SetImage(PictureBox picbox, String fileName)
        {
            try
            {
                try
                {
                    picbox.Image = tb.GetThumbnail(fileName);
                }
                catch (Exception e)
                {
                   picbox.Image = global::SortImage.Properties.Resources.thumberror;
                    System.Diagnostics.Debug.WriteLine("Corrupt on transpanel:   " + e);
                }
                picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Can't open file stream to load image for transpanel:   " + ex);
            }
        }

        public static bool ThumbnailCallback()
        {
            return true;
        }

        private void Picturebox_Click(object sender, EventArgs e)
        {
            if (callerButton != null)
            {
                PictureBox clickedButton = (PictureBox)sender; //get the button that was clicked
                string index = clickedButton.Name.Substring(PREVIEWNAME.Length);
                string fileparth = (string)filePaths[Convert.ToInt16(index)];
                SortImg.SetbuttonIm(callerButton, fileparth);
                MessageBox.Show("New image chosen for folder preview");
            }
        }
    }
}
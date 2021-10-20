using System;
using System.Windows.Forms;

namespace SortImage
{
    public partial class SourceDialog : Form
    {
        const int dupFold = 32;
        const string dupFolderName = "_dups";

        private int sourceCount = 0;
        private bool logval = true;
        private string sortval = "NAME";
        private string lastDir = null;
        private int foldercount = 0;
        private string defaultDupFolderPath = null;

        private FileNameBuilder fileNameCreator;
        private SortImgSettings settings;

        private string[] workingFolders = new string[64]; // 0-31 are source folders, 32 is dup folder. 64 for compatablity with copying

        public SourceDialog(SortImgSettings set)
        {
            fileNameCreator = new FileNameBuilder(false);
            string apppath = Application.StartupPath;
            InitializeComponent();
            buildtips();
            settings = set;
            logval = settings.LogValue;
            lastDir = settings.LastDirectory;
        }

        private void buildtips()
        {
            ToolTip toolTip1 = new ToolTip() {
                AutoPopDelay = int.MaxValue,
                InitialDelay = 1,
                ReshowDelay = 50,
                ShowAlways = true
            };
            toolTip1.SetToolTip(this.help3, "Must pick the main folders that are to be sorted");
            toolTip1.SetToolTip(this.help4, "Must pick a folder to handle duplicates and marked deletion if on 'mark' delete mode");
        }

        private void pickImageFolder_Click(object sender, EventArgs e)
        {
            if (sourceCount == 0)//Special for the first folder picked
            {
                SortDialog b = new SortDialog(logval);
                b.StartPosition = FormStartPosition.CenterParent;
                if (b.ShowDialog() == DialogResult.OK) {
                    sortval = b.GetString();
                    logval = b.GetLogChecked();
                    if (logval == true) {
                        settings.LogValue = true;
                    } else {
                        settings.LogValue = false;
                    }

                }
                pickDupFolder.Enabled = true;
            }
            if (sourceCount < 10) {
                addSourceFolder();
                sourceCount++;
            } else {
                MessageBox.Show("At max allowed source folders");
            }
        }

        /// <summary>
        /// Button click for inital folder also sets up alot of things. Starts log file etc
        /// </summary>
        private void addSourceFolder()
        {
            folderBrowserDialog1.SelectedPath = lastDir;
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                string fold = folderBrowserDialog1.SelectedPath;

                if (Array.IndexOf(workingFolders, fold) >= 0) {
                    MessageBox.Show("Don't pick duplicate folders");
                } else {
                    workingFolders[foldercount] = fold;
                    inputFolderTextBox.Lines = workingFolders;
                    foldercount++;
                    settings.LastDirectory = fold;

                    if (foldercount == 1) {
                        if (workingFolders[dupFold] != null) {
                            return;
                        }

                        SourceDialogDone.Enabled = true;
                        defaultDupFolderPath = workingFolders[0] + '\\' + dupFolderName;
                        outputFolderTextBox.Text = defaultDupFolderPath;
                    }
                }
            }
        }

        private void pickDupFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (Array.IndexOf(workingFolders, folderBrowserDialog1.SelectedPath) >= 0) {
                    MessageBox.Show("Two folders are the same. Please pick a diffrent folder to source(s)");
                } else {
                    workingFolders[dupFold] = folderBrowserDialog1.SelectedPath;
                    SourceDialogDone.Enabled = true;
                    outputFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
                    defaultDupFolderPath = null;
                }
            }
        }

        private void SourceDialogDone_Click(object sender, EventArgs e)
        {
            if (defaultDupFolderPath != null) {
                fileNameCreator.createDirectory(defaultDupFolderPath);
                workingFolders[dupFold] = defaultDupFolderPath;
            }
        }

        public string[] GetSourceFolders()
        {
            return workingFolders;
        }

        public int GetSourceCount()
        {
            return sourceCount;
        }

        public bool GetLogVal()
        {
            return logval;
        }

        public string GetSortVal()
        {
            return sortval;
        }

        public string GetlastDir()
        {
            return lastDir;
        }
        public int GetFoldercount()
        {
            return foldercount;
        }
    }
}

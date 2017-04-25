using System;
using System.Windows.Forms;
using SortImage;
using System.IO;

namespace SortImage
{
    public partial class SourceDialog : Form
    {
        const int dupFold = 32;
        private int sourceCount = 0;
        private bool logval = true;
        private string sortval = "NAME";
        private string lastDir = null;
        private int foldercount = 0;

        private SortImgSettings settings;
       // private IniFile INI;

        private string[] workingFolders = new string[64]; // 0-31 are source folders, 32 is dup folder. 64 for compatablity with copying

        public SourceDialog(SortImgSettings set)
        {
            string apppath = Application.StartupPath;
           // INI = new IniFile(apppath + "\\Settings.ini");
            InitializeComponent();
            buildtips();
           // buildINI();
            //lastDir = settings.LastDirectory;
          //  logval = settings.LogValue;
            settings = set;
            logval = settings.LogValue;
            lastDir = settings.LastDirectory;
        }


        private void buildtips()
        {
            ToolTip toolTip1 = new ToolTip()
            {
                AutoPopDelay = int.MaxValue,
                InitialDelay = 1,
                ReshowDelay = 50,
                ShowAlways = true
            };
            toolTip1.SetToolTip(this.help3, "Must pick the main folders that are to be sorted");
            toolTip1.SetToolTip(this.help4, "Must pick a folder to handle duplicates and marked deletion if on 'mark' delete mode");
        }
        /*
        private void buildINI()
        {
            string tmpString = INI.IniReadValue("directories", "lastimage");
            if (tmpString != "null")
            {
                try
                {
                    lastDir = Path.GetFullPath(tmpString);
                }
                catch (IOException)
                {
                    lastDir = null;
                }
            }

            if (INI.IniReadValue("options", "Log") == "true")
            {
                logval = true;
            }
            else
            {
                logval = false;
            }
        }
         */

        private void pickImageFolder_Click(object sender, EventArgs e)
        {
            if (sourceCount == 0)//Special for the first folder picked
            {
                SortDialog b = new SortDialog(logval);
                b.StartPosition = FormStartPosition.CenterParent;
                if (b.ShowDialog() == DialogResult.OK)
                {
                    sortval = b.GetString();
                    logval = b.GetLogChecked();
                    if (logval == true)
                    {
                        settings.LogValue = true;
                        //INI.IniWriteValue("options", "Log", "true");
                    }
                    else
                    {
                        settings.LogValue = false;
                       // INI.IniWriteValue("options", "Log", "false");
                    }
                  
                }
                pickDupFolder.Enabled = true;
            }
            if (sourceCount < 10)
            {
                addSourceFolder();
                sourceCount++;
            }
            else
            {
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
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string fold = folderBrowserDialog1.SelectedPath;

                if (Array.IndexOf(workingFolders, fold) >= 0)
                {
                    MessageBox.Show("Don't pick duplicate folders");
                }
                else
                {
                    workingFolders[foldercount] = fold;
                    inputFolderTextBox.Lines = workingFolders;
                    foldercount++;
                    settings.LastDirectory = fold;
                  //  INI.IniWriteValue("directories", "lastimage", fold);
                }

                //MessageBox.Show(fold);
            }
        }

        private void pickDupFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Array.IndexOf(workingFolders,folderBrowserDialog1.SelectedPath) >= 0)
                {
                    MessageBox.Show("Two folders are the same. Please pick a diffrent folder to source(s)");
                }
                else
                {
                    workingFolders[dupFold] = folderBrowserDialog1.SelectedPath;
                    SourceDialogDone.Enabled = true;
                    outputFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }
        
        private void SourceDialogDone_Click(object sender, EventArgs e)
        {
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

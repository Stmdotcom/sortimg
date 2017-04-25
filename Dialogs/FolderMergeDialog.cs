using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Security.Cryptography;

namespace SortImage
{
    public partial class FolderMergeDialog : Form
    {
        string source;
        string destination;
        int size;
        int copys = 0;
        int selectedMatcher = 0;

        public FolderMergeDialog()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void sourceBut_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                source = folderBrowserDialog1.SelectedPath;
                sourceText.Text = source;
            }
        }

        private void destBut_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                if (folderBrowserDialog1.SelectedPath == source)
                {
                    MessageBox.Show("Destination same as source");
                }
                else
                {
                    destination = folderBrowserDialog1.SelectedPath;
                    destText.Text = destination;
                }                
            }
        }

        private void goBut_Click(object sender, EventArgs e)
        {
            ArrayList FileTypes= new ArrayList();
            ArrayList FileArray = new ArrayList();
            // initialize the image types array
            FileTypes.Add("*.JPG");
            FileTypes.Add("*.JPEG");
            FileTypes.Add("*.GIF");
            FileTypes.Add("*.BMP");
            FileTypes.Add("*.PNG");
            // process current folder
            string[] szFiles;
            foreach (string szType in FileTypes)
            {
                szFiles = Directory.GetFiles(source, szType);
                if (szFiles.Length > 0)
                    FileArray.AddRange(szFiles);
            }
            size = FileArray.Count;
           // string sodir = Path.GetDirectoryName(source);
           // string dedir = Path.GetDirectoryName(destination);
            progressBar1.Maximum = size;
            foreach (string file in FileArray)
            {
                copy(destination , Path.GetFileName(file), file);
            }
            DialogResult = DialogResult.OK;
        }


        private void copy(string destdir, string sourceFile, string sourceDirandFile)
        {
            bool pass = false;
            string destcheck = destdir + '\\' + sourceFile; 
            try
            {
                if (File.Exists(destcheck)) // Duplicate file name check. This is a basic 1 to 1 file check
                {
                    if (selectedMatcher == 1)
                    {
                        System.Diagnostics.Debug.WriteLine("MD5");
                        string size1 = CalcMd5Hash(sourceDirandFile);
                        string size2 = CalcMd5Hash(destcheck);
                        if (size1 == size2)
                        {
                            pass = true;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Size");
                        long size1 = CalcSize(sourceDirandFile);
                        long size2 = CalcSize(destcheck);
                        if (size1 == size2)
                        {
                            pass = true;
                        }
                    }
                    if (pass) //Files share size: Don't move as they are (assumed) same file. (Change check a checksum?)
                    {
                        copys++;
                        progressBar1.Increment(1);
                        System.Diagnostics.Debug.WriteLine("File already exists " + copys + " out of " + size);                     
                    }
                    else // Files are diffrent sizes but share filename, move and rename file.
                    {
                        string tmpname = Path.GetFileNameWithoutExtension(sourceDirandFile);
                        string tmpex = Path.GetExtension(sourceDirandFile);
                        int i = 0;
                        int it = 1;
                        while (i == 0)
                        {
                            string newdestname = tmpname + "_" + it + tmpex;
                            string newdest = destdir + '\\' + newdestname;

                            if (File.Exists(newdest)) //Do nothing and iterate again
                            {
                            }
                            else
                            {
                                copys++;
                                progressBar1.Increment(1);
                                System.Diagnostics.Debug.WriteLine("File moved rename " + copys + " out of " + size);
                                System.Diagnostics.Debug.WriteLine(sourceDirandFile + " TO " + newdest);
                                System.IO.File.Move(sourceDirandFile, newdest);
                                i = 1;
                            }
                            it++;
                        }
                    }
                }
                else //Filename isn't found so move.
                {
                    copys++;
                    progressBar1.Increment(1);
                    System.Diagnostics.Debug.WriteLine("File moved " + copys + " out of " + size);
                    System.Diagnostics.Debug.WriteLine(sourceDirandFile + " TO " + destcheck);
                    System.IO.File.Move(sourceDirandFile, destcheck);
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Crap");
            }
        }


        public long CalcSize(string filename)
        {
            FileInfo f = new FileInfo(filename);
            long s1 = f.Length;
            return s1;
        }

        private string CalcMd5Hash(string filename)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] md5Hash = md5.ComputeHash(fs);
            fs.Close();
            fs.Dispose();
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < md5Hash.Length; i++)
            {
                sBuilder.Append(md5Hash[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
                      
        private void BmpToPngDialog_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           selectedMatcher = comboBox1.SelectedIndex;
        }
    }
}

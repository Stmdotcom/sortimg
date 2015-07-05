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
using System.Drawing.Imaging;

namespace SortImage
{
    public partial class BmpToPngDialog : Form
    {
        string source;
        int size;
        string filetype = "png";
        public BmpToPngDialog()
        {
            InitializeComponent();
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

        private void goBut_Click(object sender, EventArgs e)
        {
            if (radioButtonJpg.Checked == true)
            {
                filetype = "jpg";
            }
            else if (radioButtonPng.Checked == true)
            {
                filetype = "png";
            }
            ArrayList FileTypes= new ArrayList();
            ArrayList FileArray = new ArrayList();
            FileTypes.Add("*.BMP");
            string[] szFiles;
            foreach (string szType in FileTypes)
            {
                szFiles = Directory.GetFiles(source, szType);
                if (szFiles.Length > 0)
                    FileArray.AddRange(szFiles);
            }
            size = FileArray.Count;
            progressBar1.Maximum = size;
            foreach (string file in FileArray)
            {
                convertToPng(source, Path.GetFileNameWithoutExtension(file), file);
            }
            DialogResult = DialogResult.OK;
        }

        private void convertToPng(string sourcedir, string sourceFile, string sourceDirandFile)
        {
            try
            {
                // Load the image.
                System.Drawing.Image image1 = System.Drawing.Image.FromFile(sourceDirandFile);
                if (filetype == "jpg")
                {
                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    // Create an Encoder object based on the GUID
                    // for the Quality parameter category.
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    image1.Save(sourcedir + "\\" + sourceFile + ".jpg", jgpEncoder, myEncoderParameters);

                }
                else if (filetype == "png")
                {
                    // Save the image in PNG format.
                    image1.Save(sourcedir + "\\" + sourceFile + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                progressBar1.Increment(1);
            }
            catch
            {
                Console.WriteLine("Crap");
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public long CalcSize(string filename)
        {
            FileInfo f = new FileInfo(filename);
            long s1 = f.Length;
            return s1;
        }

        private void FolderMergeDialog_Load(object sender, EventArgs e){}
    }
}

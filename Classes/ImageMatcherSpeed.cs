using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SortImage
{
    class ImageMatcherSpeed
    {
        private int thumbwidth = 150;
        private double sensitivity = 2.5;
        private int deviation = 10;
        private ArrayList fingerprint_feild;
        private ArrayList filename_feild;
        private int small_size = 16;
        private int progress = 0;
        private float progressmax = 1;
        private Bitmap image;
        private Bitmap smallimage;
        private Bitmap gsimage;
        private ArrayList FileTypes;
        private ArrayList FileArray;
        private string lastmatch;
        private Dictionary<string, Bitmap> thumbnails;
        private long image1_size;
        private Bitmap image1_small;
        private Bitmap image1_src;
        public delegate void ReportDelegate(int percent, string status);

        public ImageMatcherSpeed()
        {
            thumbnails = new Dictionary<string, Bitmap>();
            fingerprint_feild = new ArrayList();
            filename_feild = new ArrayList();

            FileTypes = new ArrayList();
            FileTypes.Add("*.JPG");
            FileTypes.Add("*.JPEG");
            FileTypes.Add("*.BMP");
            FileTypes.Add("*.PNG");

        }

        public ArrayList GetFingerprints()
        {
            return fingerprint_feild;
        }

        public ArrayList GetFilenames()
        {
            return filename_feild;
        }

        /// <summary>
        /// valid doubles between 0-4
        /// </summary>
        public double Sensertivity
        {
            get
            {
                return sensitivity;
            }
            set
            {
                if ((value > 0) && (value < 4))
                {
                    sensitivity = value;
                }
            }
        }

        public string GetLastMatch()
        {
            return lastmatch;
        }

        public int getProgress()
        {
            return progress;
        }

        public int getProgressMax()
        {
            return (int)progressmax;
        }

        /// <summary>
        /// Calculates size of a file
        /// </summary>
        /// <param name="filename">File path</param>
        /// <returns>Size</returns>
        public long CalcSize(string filename)
        {
            FileInfo f = new FileInfo(filename);
            long s1 = f.Length;
            return s1;
        }

        /// <summary>
        /// Check a single file against the fingerprints or add to list if not duplicate. Assumes copy to "newfilename" if not a dup
        /// </summary>
        /// <param name="filename">Current file name</param>
        /// <param name="newfilename">Potental file name if it is copyed (That is it's not a dup)</param>
        /// <returns>True if not in list, else false</returns>
        public bool CheckImage(string filename, string newfilename)
        {
            string checksum = IsUnique(filename);
            if (checksum != "error")
            {
                Console.WriteLine(filename + ": In not in list, adding " + checksum);
                fingerprint_feild.Add(checksum);
                filename_feild.Add(newfilename);
                return true;
            }
            else
            {
                Console.WriteLine(filename + ": Is a duplicate");
                return false;
            }
        }



        /// <summary>
        /// For insert of NA values into hash table.
        /// </summary>
        public void InsertNull()
        {
            try
            {
                fingerprint_feild.Add("NA");
                filename_feild.Add("NA");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to add nulls");
            }
        }

        /// <summary>
        /// Remove last entry in the hash table
        /// </summary>
        public void UndoLastHash()
        {
            try
            {
                fingerprint_feild.RemoveAt(fingerprint_feild.Count);
                filename_feild.RemoveAt(filename_feild.Count);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to remove finger print");
            }
        }

        
        /// <summary>
        /// Check a directory for duplicates (No GIF at the moment due to animation issues)
        /// </summary>
        /// <param name="parth">path to check for dups in</param>
        public Dictionary<string, int> CheckDirDups(string parth, ReportDelegate report,DoWorkEventArgs ecp, BackgroundWorker worker)
        {
            Dictionary<string, int> files = new Dictionary<string, int>();
            string[] szFiles;
            FileArray = new ArrayList();
            foreach (string szType in FileTypes)
            {
                szFiles = Directory.GetFiles(parth, szType);
                if (szFiles.Length > 0)
                {
                    FileArray.AddRange(szFiles);
                }
            }
            int cur = 0;
            string checksum = "";
            progressmax = FileArray.Count;
            progressmax = (100 / progressmax);
            int magic = 0;
            foreach (string file in FileArray)
            {
                progress = (int)(progressmax * cur);
                if (progress <= 100)
                {
                    report(progress, "Running");
                    if (worker.CancellationPending)
                    {
                        ecp.Cancel = true;
                        break;
                    }
                }
                else
                {
                    report(100, "Running");
                    if (worker.CancellationPending)
                    {
                        ecp.Cancel = true;
                        break;
                    }
                }
                cur++;
                checksum = IsUnique(file);
                if (checksum != "error")
                {
                    Console.WriteLine(file + ": In not in list, adding " + checksum);
                    fingerprint_feild.Add(checksum);
                    filename_feild.Add(file);
                }
                else
                {
                    Console.WriteLine(file + ": Is a duplicate");
                    try
                    {
                        if (files.ContainsKey(lastmatch))
                        {
                            int v = files[lastmatch];
                            files.Add(file, v);
                        }
                        else
                        {
                            files.Add(file, magic);
                            files.Add(lastmatch, magic);
                            magic++;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e);
                    }
                }
            }
            return files;
        }

        /// <summary>
        /// Check the MD5 values of images, used for debuging the match algorthm
        /// </summary>
        /// <param name="parth"></param>
        public void CheckMD5s(string parth)
        {
            // process current folder
            string[] szFiles;
            FileArray = new ArrayList();
            foreach (string szType in FileTypes)
            {
                szFiles = Directory.GetFiles(parth, szType);
                if (szFiles.Length > 0)
                    FileArray.AddRange(szFiles);
            }
            progressmax = FileArray.Count;
            int cur = 0;
            string fingerp;
            foreach (string file in FileArray)
            {
                progress = cur;
                cur++;
                fingerp = FingerPrint(file);
                if (fingerp != "error")
                {
                    fingerprint_feild.Add(fingerp);
                    filename_feild.Add(file);
                }
                else
                {
                    Console.WriteLine("ERROR PROCCESSING FILE.." + file);
                }
            }
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
   
        /// <summary>
        /// Calculates a MD5 hash of a file
        /// </summary>
        /// <param name="filename">File path</param>
        /// <returns>Hash code</returns>
        private static byte[] CalcMd5Hash(string filename)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] md5Hash = md5.ComputeHash(fs);
            fs.Close();
            fs.Dispose();
            return md5Hash;
        }
         
        /// <summary>
        /// Check if the file is unique in the current set of image MD5s
        /// </summary>
        /// <param name="filename">Path of file to check</param>
        /// <returns>MD5 Hash if unique else -1</returns>
        private string IsUnique(string filename)
        {
            string fingerprintval = FingerPrint(filename);
            int matchFound = 0;
            int tempIter = 0;
            int doOnce = 1;
            int done = 0;
            foreach (string temp in fingerprint_feild)
            {
                if ((temp == fingerprintval) && temp != "NA" && done != 1)
                {
                    Console.Out.WriteLine("Found matching MD5");
                    if (doOnce == 1)
                    {
                        BuildCompare(filename);
                        doOnce = 0;
                    }
                    if (CheckDuplicates((string)filename_feild[tempIter]) == 1)
                    {
                        matchFound = 1;
                        Console.Out.WriteLine("Found matching image");
                        done = 1;
                    }
                }
                tempIter++;
            }
            done = 0;
            doOnce = 1;
            if (matchFound == 1)
            {
                return "error";
            }
            else
            {
                return fingerprintval;
            }
        }

        /// <summary>
        /// Gets MD5 hash based on colour histogram data from image
        /// </summary>
        /// <param name="filename">Path of file to check</param>
        /// <returns>MD5 of image histogram</returns>
        private string FingerPrint(string filename)
        {
            try
            {
                image = new Bitmap(filename);
            }
            catch (Exception)
            {
                return "error";
            }
            int width = image.Width;
            int height = image.Height;
            double ratio = (double)thumbwidth / (double)width;
            int newwidth = thumbwidth;
            int newheight = (int)Math.Round(height * ratio);

            if (!thumbnails.ContainsKey(filename))
            {
                thumbnails.Add(filename,   customThumb(image, small_size, small_size));
            }
            smallimage = customThumb(image, newwidth, newheight);
            gsimage = new Bitmap(newwidth, newheight);
            int numpixels = newwidth * newheight;
            Dictionary<double, double> histogram = new Dictionary<double, double>();
            int i;
            int j;
            Color pos = new Color();
            int r = 0;
            int g = 0;
            int b = 0;
            for (i = 0; i < newwidth; i++)
            {
                for (j = 0; j < newheight; j++)
                {
                    pos = smallimage.GetPixel(i, j);
                    r = pos.R;
                    g = pos.G;
                    b = pos.B;
                    // NOTE: Text varys on the colour ratios, g and b might be swapped.
                    double greyscale = Math.Round((r * 0.3) + (g * 0.59) + (b * 0.11));
                    greyscale++;
                    double value = (Math.Round(greyscale / 16) * 16) - 1;
                    double incer;
                    if (histogram.TryGetValue(value, out incer))
                    {
                        histogram[value] = incer + 1;
                    }
                    else
                    {
                        histogram.Add(value, 1);
                    }
                }
            }
            Console.WriteLine(histogram.Count);
            int tr = 0;
            Dictionary<double, double> normhist = new Dictionary<double, double>();
            double max = 0;
            foreach (KeyValuePair<double, double> kvp in histogram)
            {
                normhist[kvp.Key] = kvp.Value / numpixels;
                tr++;
                if ((kvp.Value / numpixels) > max)
                {
                    max = kvp.Value / numpixels;
                }
            }
            string histsrting = "";
            double h = 0;
            double height2;
            for (i = -1; i <= 255; i = i + 16)
            {
                double incer;
                if (normhist.TryGetValue(i, out incer))
                {

                    h = ((incer / max) * sensitivity);
                }
                height2 = Math.Round(h);
                histsrting = histsrting + Convert.ToString(height2);
            }
            image.Dispose();
            smallimage.Dispose();
            gsimage.Dispose();
            return CalculateMD5Hash(histsrting);
        }

        /// <summary>
        /// Build image for compare.
        /// </summary>
        /// <param name="file">Path of file to compare</param>
        private void BuildCompare(string file)
        {
            image1_size = CalcSize(file);
            if (thumbnails.ContainsKey(file))
            {
                image1_small = thumbnails[file];
            }
            else
            {
                image1_src = new Bitmap(file);
                image1_small = customThumb(image1_src, small_size, small_size);
                thumbnails.Add(file, image1_small);
                image1_src.Dispose();
            }   
        }

        /// <summary>
        /// Direct compare of two files. Compared file is created by BuildCompare
        /// </summary>
        /// <param name="file">Path of file to check</param>
        /// <returns>1 match: 0 not match</returns>
        private int CheckDuplicates(string file)
        {
            // If images share MD5 and are the same size they are considered duplicates
            if (CalcSize(file) == image1_size)
            {
                lastmatch = file;
                return 1;
            }
            //Otherwise compare in detail
            try
            {
                Bitmap image2_src;
                Bitmap image2_small;
                if (thumbnails.ContainsKey(file))
                {
                    image2_small = thumbnails[file];
                }
                else
                {
                    image2_src = new Bitmap(file);
                    image2_small = customThumb(image2_src, small_size, small_size);
                    thumbnails.Add(file, image2_small);
                    image2_src.Dispose();
                }
                int x;
                int y;
                double diffrence = 0;
                for (x = 0; x < 16; x++)
                {
                    for (y = 0; y < 16; y++)
                    {
                        Color image1_color = image1_small.GetPixel(x, y);
                        int r1 = image1_color.R;
                        int g1 = image1_color.G;
                        int b1 = image1_color.B;
                        Color image2_color = image2_small.GetPixel(x, y);
                        int r2 = image2_color.R;
                        int g2 = image2_color.G;
                        int b2 = image2_color.B;
                        diffrence += Math.Abs(r1 - r2) + Math.Abs(g1 - g2) + Math.Abs(b1 - b2);
                    }
                }
                diffrence = diffrence / 256;
                if (diffrence <= deviation)
                {
                    lastmatch = file;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR:" + e);
                return 0;
            }
        }

        private Bitmap customThumb(Bitmap img, int x, int y)
        {
            Bitmap thumb = new Bitmap(x, y);
            using (Graphics graphics = Graphics.FromImage(thumb))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(img, 0, 0, x, y);
            }
            Console.Out.WriteLine("Custom created thumb");
            return thumb;
        }
    }
}

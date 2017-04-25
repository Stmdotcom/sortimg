using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace SortImage
{
    class FileNameBuilder
    {
        private string dupFolder;
        private bool orgnText;

        public FileNameBuilder(bool set)
        {
            dupFolder = "null";
            orgnText = set;
        }

        public string duplicateFolder
        {
            get
            {
                return dupFolder;
            }
            set
            {
                dupFolder = value;
            }
        }

        public bool orginalText
        {
            get
            {
                return orgnText;
            }
            set
            {
                orgnText = value;
            }
        }

        /// <summary>
        /// Safely create a directory
        /// </summary>
        /// <param name="dir">Name of directory to create</param>
        /// <returns>Path if created else NULL</returns>
        public string createDirctory(string path)
        {
            //string path = dir;
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }
                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return null;
            }
            finally { }
        }

        /// <summary>
        /// Builds new name for use on a file copy
        /// </summary>
        /// <param name="source">Source of the file (Full path)</param>
        /// <param name="Destination">Destination folder</param>
        /// <returns>Array containing copy locations [0] = user location [1] = Duplicate location</returns>
        public string[] fileNameBuilder(string source, string Destination, List<string> tagList, int renameIteration)
        {
            string dest;
            string dest2 = dupFolder + '\\' + Path.GetFileName(source);
            string newFileName = "";
            foreach (string tag in tagList)
            {
                newFileName += tag + "_";
            }
            if ((newFileName != "") && (renameIteration == 0) && (orgnText == false))
            {
                dest = Destination + '\\' + newFileName + Path.GetExtension(source);
            }
            else if ((newFileName != "") && (renameIteration == 0) && (orgnText == true))
            {
                dest = Destination + '\\' + newFileName + Path.GetFileName(source);
            }
            else if ((newFileName != "") && (renameIteration != 0) && (orgnText == false))
            {
                dest = Destination + '\\' + newFileName + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            }
            else if ((newFileName != "") && (renameIteration != 0) && (orgnText == true))
            {
                dest = Destination + '\\' + newFileName + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            }
            else if (renameIteration != 0)
            {
                dest = Destination + '\\' + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            }
            else
            {
                dest = Destination + '\\' + Path.GetFileName(source);
            }
            string check = System.IO.Path.GetFileName(dest);
            if (check.Length > 200) //Reset file name if to large to avoid error on unable to write file name. This is not acurate. There are diffrences between the full path name and the file name depending on the file system in use.
            {
                MessageBox.Show("File name is over or close to char limit, file name reset");
                if (renameIteration != 0)
                {
                    dest = Destination + '\\' + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
                }
                else
                {
                    dest = Destination + '\\' + Path.GetFileName(source);
                }
            }
            string[] pictureNames = new string[2];
            pictureNames[0] = dest;
            pictureNames[1] = dest2;
            return pictureNames;
        }

        // Tells what file types are images
        public ArrayList makeFileTypes()
        {
            ArrayList FileTypes = new ArrayList();
            FileTypes.Add("*.JPG");
            FileTypes.Add("*.JPEG");
            FileTypes.Add("*.GIF");
            FileTypes.Add("*.BMP");
            FileTypes.Add("*.PNG");
            FileTypes.Add("*.TIF");
            FileTypes.Add("*.TIFF");
            return FileTypes;
        }

        public List<string> ProcessDirectoryList(string filepath)
        {
            string[] szFiles;
            List<string> fileArray = new List<string>();
            foreach (string szType in makeFileTypes())
            {
                szFiles = Directory.GetFiles(filepath, szType);
                if (szFiles.Length > 0)
                    fileArray.AddRange(szFiles);
            }
            return fileArray;
        }

        public ArrayList ProcessDirectory(string filepath)
        {
            string[] szFiles;
            ArrayList fileArray = new ArrayList();
            foreach (string szType in makeFileTypes())
            {
                szFiles = Directory.GetFiles(filepath, szType);
                if (szFiles.Length > 0)
                    fileArray.AddRange(szFiles);
            }
            return fileArray;
        }
    }
}

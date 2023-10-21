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
        private bool orignalFileName;

        public FileNameBuilder(bool keepOrignalFilename)
        {
            dupFolder = "null";
            orignalFileName = keepOrignalFilename;
        }

        public string duplicateFolder
        {
            get { return dupFolder; }
            set { dupFolder = value; }
        }

        public bool keepOrignalFileName
        {
            get { return orignalFileName; }
            set { orignalFileName = value;}
        }

        /// <summary>
        /// Safely create a directory
        /// </summary>
        /// <param name="dir">Name of directory to create</param>
        /// <returns>Path if created else NULL</returns>
        public string createDirectory(string path)
        {
            //string path = dir;
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    System.Diagnostics.Debug.WriteLine("That path exists already.");
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    System.Diagnostics.Debug.WriteLine("The directory was created successfully at " + Directory.GetCreationTime(path));
                }
                return path;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("The process failed: {0}", e.ToString());
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
            string targetPath;
            string duplicatePath = dupFolder + '\\' + Path.GetFileName(source);
            string newFileName = "";
            foreach (string tag in tagList) {
                newFileName += tag + "_";
            }
            if ((newFileName != "") && (renameIteration == 0) && (keepOrignalFileName == false)) {
                targetPath = Destination + '\\' + newFileName + Path.GetExtension(source);
            } else if ((newFileName != "") && (renameIteration == 0) && (keepOrignalFileName == true)) {
                targetPath = Destination + '\\' + newFileName + Path.GetFileName(source);
            } else if ((newFileName != "") && (renameIteration != 0) && (keepOrignalFileName == false)) {
                targetPath = Destination + '\\' + newFileName + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            } else if ((newFileName != "") && (renameIteration != 0) && (keepOrignalFileName == true)) {
                targetPath = Destination + '\\' + newFileName + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            } else if (renameIteration != 0) {
                targetPath = Destination + '\\' + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
            } else {
                targetPath = Destination + '\\' + Path.GetFileName(source);
            }

            string check = System.IO.Path.GetFileName(targetPath);
            if (check.Length > 200) { // Reset file name if to large to avoid error on unable to write file name. This is not acurate. There are diffrences between the full path name and the file name depending on the file system in use.
                MessageBox.Show("File name is over or close to char limit, file name reset");
                if (renameIteration != 0)
                {
                    targetPath = Destination + '\\' + Path.GetFileNameWithoutExtension(source) + "_(" + renameIteration + ")_" + Path.GetExtension(source);
                }
                else
                {
                    targetPath = Destination + '\\' + Path.GetFileName(source);
                }
            }
            return new string[2] { targetPath, duplicatePath };
        }

        // Tells what file types are images
        public ArrayList makeFileTypes()
        {
            ArrayList FileTypes = new ArrayList
            {
                "*.JPG",
                "*.JPEG",
                "*.GIF",
                "*.BMP",
                "*.PNG",
                "*.TIF",
                "*.TIFF"
            };
            return FileTypes;
        }

        public List<string> ProcessDirectoryList(string filepath)
        {
            string[] szFiles;
            List<string> fileArray = new List<string>();
            foreach (string szType in makeFileTypes()) {
                szFiles = Directory.GetFiles(filepath, szType);
                if (szFiles.Length > 0) {
                    fileArray.AddRange(szFiles);
                }
            }
            return fileArray;
        }

        public ArrayList ProcessDirectory(string filepath)
        {
            string[] szFiles;
            ArrayList fileArray = new ArrayList();
            foreach (string szType in makeFileTypes()) {
                szFiles = Directory.GetFiles(filepath, szType);
                if (szFiles.Length > 0) {
                    fileArray.AddRange(szFiles);
                }
            }
            return fileArray;
        }
    }
}

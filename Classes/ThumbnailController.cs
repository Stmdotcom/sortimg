using System;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace SortImage
{
    public class ThumbnailControllerEventArgs : EventArgs
    {
        public ThumbnailControllerEventArgs(string imageFilename)
        {
            this.ImageFilename = imageFilename;
        }
        public string ImageFilename;
    }

    public delegate void ThumbnailControllerEventHandler(object sender, ThumbnailControllerEventArgs e);

    public class ThumbnailController
    {
        private bool cancelScanning;
        static readonly object cancelScanningLock = new object();
        private int orderBy = 0;
        private List<string> fileList;
        private int loadAmount = 20;
        private FileNameBuilder fnb = new FileNameBuilder(false);

        public int ImageLoadAmount
        {
            set { loadAmount = value; }
            get { return loadAmount; }
        }

        public int OrderBy
        {
            set { orderBy = value; }
            get { return orderBy; }
        }

        public int fileCount
        {
            get { return fileList.Count; }
        }

        public bool CancelScanning
        {
            get
            {
                lock (cancelScanningLock)
                {
                    return cancelScanning;
                }
            }
            set
            {
                lock (cancelScanningLock)
                {
                    cancelScanning = value;
                }
            }
        }

        public event ThumbnailControllerEventHandler OnStart;
        public event ThumbnailControllerEventHandler OnAdd;
        public event ThumbnailControllerEventHandler OnEnd;

        public ThumbnailController()
        {
            fileList = new List<string>();
        }


        public void QueFile(string fileName)
        {
            fileList.Add(fileName);
        }

        public void PushFile(string fileName)
        {
            CancelScanning = false;
            Image img = null;

            try
            {
                img = Image.FromFile(fileName);
            }
            catch {
                System.Diagnostics.Debug.WriteLine("Thumb cntr error");
            }

            if (img != null)
            {
                this.OnAdd(this, new ThumbnailControllerEventArgs(fileName));
                img.Dispose();
            }

        }


        public void LoadFolder(string folderPath)
        {
            List<string> files = fnb.ProcessDirectoryList(folderPath);

            if (orderBy == 1)
            {
                var sort = from image in files
                           orderby new FileInfo(image).Length descending
                           select image;

                foreach (string n in sort)
                {
                    fileList.Add(n);
                }

            }
            else if (orderBy == 2)
            {
                var sort = from image in files
                           orderby new FileInfo(image).LastWriteTime descending
                           select image;

                foreach (string n in sort)
                {
                    fileList.Add(n);
                }    
            }else{ //Fall through for NAME
            
                var sort = from image in files
                           orderby new FileInfo(image).Name ascending
                           select image;

                foreach (string n in sort)
                {
                    fileList.Add(n);
                }

            }   
        }


        public void LoadSet()
        {
            if (fileList.Count != 0)
            {
                CancelScanning = false;
                Thread thread = new Thread(new ThreadStart(BuildSet));
                thread.IsBackground = true;
                thread.Start();
            }
        }


        private void BuildSet()
        {
            if (this.OnStart != null)
            {
                this.OnStart(this, new ThumbnailControllerEventArgs(null));
            }

            this.AddSetIntern();

            if (this.OnEnd != null)
            {
                this.OnEnd(this, new ThumbnailControllerEventArgs(null));
            }

            CancelScanning = false;
        }


        private void AddSetIntern(){
            if (CancelScanning) {
                return;
            }
            for (int i = 0; i < loadAmount; i++) {
                if (CancelScanning || fileList.Count == 0){
                    break;
                }

                string file = fileList[0];
                Image img = null;
                try {
                    img = Image.FromFile(file);
                }
                catch {
                    System.Diagnostics.Debug.WriteLine("Thumb cntr error 2");
                }

                if (img != null) {
                    this.OnAdd(this, new ThumbnailControllerEventArgs(file));
                    img.Dispose();
                }
                fileList.RemoveAt(0);
            }     
        }



        public void AddFolder(string folderPath) {
            CancelScanning = false;
            Thread thread = new Thread(new ParameterizedThreadStart(AddFolder));
            thread.IsBackground = true;
            thread.Start(folderPath);
        }

        private void AddFolder(object folderPath) {
            string path = (string)folderPath;

            if (this.OnStart != null) {
                this.OnStart(this, new ThumbnailControllerEventArgs(null));
            }
            this.AddFolderIntern(path);
            if (this.OnEnd != null) {
                this.OnEnd(this, new ThumbnailControllerEventArgs(null));
            }
            CancelScanning = false;
        }

        private void AddFolderIntern(string folderPath) {
            if (CancelScanning) {
                return;
            }
            string[] files = Directory.GetFiles(folderPath);     
            foreach(string file in files) {
                if (CancelScanning) {
                    break;
                }

                Image img = null;

                try {
                    img = Image.FromFile(file);
                }
                catch{
                    System.Diagnostics.Debug.WriteLine("Thumb cntr error 3");
                }

                if (img != null) {
                    this.OnAdd(this, new ThumbnailControllerEventArgs(file));
                   
                    img.Dispose();
                }
            }
            string[] directories = Directory.GetDirectories(folderPath); 
            foreach(string dir in directories)  {
                if (CancelScanning) {
                    break;
                }

                AddFolderIntern(dir);
            }
        }
    }
}

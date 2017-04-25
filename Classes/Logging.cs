using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SortImage
{
    public class Logging
    {
        private static string fileName = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        private static StreamWriter writ;
        private static  StreamReader read;
        private static FileInfo log;
        private static string logfile;
        private static bool Logvar = false;
        private static string lasterror = "No errors encounted during this session";
        private static int errorcount = 0;

        public Logging(){}

        /// <summary>
        /// Logging
        /// </summary>
        /// <param name="fold">Folder to place log file in</param>
        /// <param name="offon">If log file is on or off</param>
        public Logging(string fold, bool offon)
        {
            Logvar = offon;
            if (Logvar == true)
            {
                fileName = fileName.Replace("/", "-");
                fileName = fileName.Replace(":", "");
                fileName = fileName.Replace(" ", "_");
                fileName = fileName.Replace(".", "");
                fileName = "SImgLOG_" + fileName;
                logfile = fold + "/" + fileName + ".txt";
                bool loop = true;
                int loopcount = 0;
                while (loop == true)
                {
                    if (File.Exists(logfile))
                    {
                        logfile = fold + "/" + fileName + loopcount + ".txt";
                        loopcount++;
                    }
                    else
                    {
                        log = new FileInfo(logfile);
                        writ = log.CreateText();
                        loop = false;
                    }
                }
                System.Diagnostics.Debug.WriteLine("Log file created at " + logfile);
                writ.WriteLine("---LOG START---");
                writ.WriteLine("Starting log at: " + DateTime.Now.ToShortTimeString());
                writ.WriteLine("---");
            }
            else
            {
                writeConsole("Session logging disabled");
            }
        }

        public void writeLog(string text, int logline)
        {
            if (Logvar == true)
            {
                writ.WriteLine(logline + " " + text);
            }
            writeConsole(text);
        }

        public void writeLog(string text)
        {
            if (Logvar == true)
            {
                writ.WriteLine(text);
            }
            writeConsole(text);
        }

        public string getLastError()
        {
            return lasterror;
        }

        public void writeLogError(string text, Exception ex)
        {
            if (Logvar == true)
            {
                writ.WriteLine("----");
                writ.WriteLine("ERROR: " + text);
                writ.WriteLine("EXCEPTION : " + ex);
                writ.WriteLine("----");
            }
            writeConsoleError(text, ex);
        }

        public string logLoad()
        {
            string text = "";
            try
            {
                writ.Flush();
                writ.Close();
                read = log.OpenText();
                text = read.ReadToEnd();
                read.Close();
                writ = log.AppendText();
            }
            catch (IOException ex)
            {
                writeConsoleError("Issue loading log", ex);
            }
            return text;
        }

        public void writeConsole(string text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }

        public void writeConsoleError(string text, Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("ERROR: " + text);
            System.Diagnostics.Debug.WriteLine("EXCEPTION: " + exception);
            lasterror = "ERROR: " + text + "\n" + "EXCEPTION: " + exception;
            errorcount++;
        }

        public void closeLog(int logline)
        {
            if (Logvar == true)
            {
                try
                {
                    writ.WriteLine("---");
                    writ.WriteLine("Number of files moved: " + logline);
                    writ.WriteLine("Number for errors in this session: " + errorcount);
                    writ.WriteLine("Ending log at: " + DateTime.Now.ToShortTimeString());
                    writ.WriteLine("---LOG END---");
                    writ.Flush();
                    writ.Close();
                    Logvar = false;
                }
                catch (Exception ex)
                {
                    writeConsoleError("Log failed to close", ex);
                }
            }
            else
            {
            }
        }
    }
}

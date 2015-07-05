using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SortImage;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace SortImage
{
    public class SortImgSettings
    {

        private static IniFile INI;
        //private static bool onceTry = true;
        private static string apppath;
        private static Logging logger;
        private static List<string> keyNames;
        private static List<int> keyBinds;
        private static string lastDir = null;
        private static bool logval = true;
        private static int dupCheckMode = 0; // 0 = off, 1 = on

        public SortImgSettings( string ap, Logging log)
        {
            apppath = ap;
            logger = log;
            INI = new IniFile(apppath + "\\Settings.ini");


        }

        public List<string> GetKeyNames()
        {
            return keyNames;
        }
        public List<int> GetKeyBinds()
        {
            return keyBinds;
        }


        public void SaveKey(string keyname ,string keybind)
        {
              INI.IniWriteValue("keybindings", keyname, keybind);
        }


        public string LastDirectory
        {
            get
            {
                return lastDir;
            }
            set
            {
                lastDir = value;
            }
        }

        public bool LogValue
        {
            get
            {
                return logval;
            }
            set
            {
                logval = value;
            }
        }
        public int DuplicateCheckMode
        {
            get
            {
                return dupCheckMode;
            }
            set
            {
                dupCheckMode = value;
            }
        }

        public void saveSettings()
        {
            try
            {
                INI.IniWriteValue("directories", "lastimage", lastDir);
                INI.IniWriteValue("options", "Log", Convert.ToString(logval));
                INI.IniWriteValue("options", "DupMode", Convert.ToString(dupCheckMode));
            }
            catch(Exception)
            {
                logger.writeLog("Failed to save settings correctly");
            }
        }


        /// <summary>
        ///   Open ini settings file
        /// </summary>
        /// <param name="fully">true = load all INI, false = only load keybinds</param>
        public void loadSettings(bool fully, bool firstcheck)
        {
            logger.writeLog("Loading INI...");

            keyNames = new List<string>();
            keyBinds = new List<int>();

          //  INI = new IniFile(apppath + "\\Settings.ini");

            keyNames.Add("Delete");
            keyNames.Add("Delete Alt");
            keyNames.Add("Undo");
            keyNames.Add("Dir 1");
            keyNames.Add("Dir 2");
            keyNames.Add("Dir 3");
            keyNames.Add("Dir 4");
            keyNames.Add("Dir 5");
            keyNames.Add("Dir 6");

            try
            {
                if (fully == true)
                {
                    string tmpString = INI.IniReadValue("directories", "lastimage");
                    if (tmpString != "null")
                    {
                        try
                        {
                            lastDir = Path.GetFullPath(tmpString);
                        }
                        catch (Exception)
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

                    int var2 = Convert.ToInt16(INI.IniReadValue("options", "DupMode"));
                    if (var2 >= 0 && var2 < 2) //Value must be between 0 and 3 or will stay on default. Check incase of manual edit.
                    {
                        dupCheckMode = var2;
                        logger.writeConsole("Dupmode loaded from INI");
                    }
                }

                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Delete")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Delete Alt")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Undo")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 1")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 2")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 3")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 4")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 5")));
                keyBinds.Add(Convert.ToInt16(INI.IniReadValue("keybindings", "Dir 6")));
                logger.writeLog("Loaded INI");
            }
            catch (Exception e)
            {
                logger.writeLog("Failed to load INI");
                logger.writeConsoleError("Error with INI loading", e);
                MessageBox.Show("Valid configuration file not found, creating a new one");
                logger.writeLog("Creating new INI");
                if (firstcheck == true)
                {
                    saveNewSettings(apppath, logger);
                    loadSettings(true, false);
                }
                else
                {
                    logger.writeLogError("Failed to make new INI", e);
                    MessageBox.Show("Failed to make new configuration file");
                }
            }

        }

        // Build new ini settings file
        private void saveNewSettings(string apppath, Logging logger)
        {
          //  INI = new IniFile(apppath + "\\Settings.ini");
            INI.IniWriteValue("directories", "lastimage", "null");
            INI.IniWriteValue("keybindings", "Delete", "110");
            INI.IniWriteValue("keybindings", "Delete Alt", "46");
            INI.IniWriteValue("keybindings", "Undo", "109");
            INI.IniWriteValue("keybindings", "Dir 1", "103");
            INI.IniWriteValue("keybindings", "Dir 2", "104");
            INI.IniWriteValue("keybindings", "Dir 3", "100");
            INI.IniWriteValue("keybindings", "Dir 4", "101");
            INI.IniWriteValue("keybindings", "Dir 5", "97");
            INI.IniWriteValue("keybindings", "Dir 6", "98");
            INI.IniWriteValue("options", "Log", "true");
            INI.IniWriteValue("options", "DupMode", "0");
        }
    }
}

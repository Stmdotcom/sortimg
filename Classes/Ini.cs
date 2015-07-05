using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SortImage
{
	public class IniFile
	{
		public string path;

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section,string key,string val,string filePath);
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section,string key,string def,StringBuilder retVal,int size,string filePath);

		/// <summary>
		/// INIFile Constructor.
		/// </summary>
		/// <param name="INIPath">Path of INI</param>
		public IniFile(string iniPath)
		{
			path = iniPath;
		}
		/// <summary>
		/// Write Data to the INI File
		/// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key Name</param>
        /// <param name="Value">Value Name</param>
		public void IniWriteValue(string Section,string Key,string Value)
		{
			WritePrivateProfileString(Section,Key,Value,this.path);
		}
		
		/// <summary>
		/// Read Data Value From the Ini File
		/// </summary>
		/// <param name="Section">Section name</param>
		/// <param name="Key">Key name</param>
		/// <param name="Path">Value Name</param>
		/// <returns>Value of key from INI</returns>
		public string IniReadValue(string section,string key)
		{
			StringBuilder temp = new StringBuilder(255);
			GetPrivateProfileString(section,key,"",temp,255,this.path);
			return temp.ToString();
		}
	}
}

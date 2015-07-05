﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SortImage
{
    class Utils64
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEOPSTRUCT64
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int SHFileOperation(ref SHFILEOPSTRUCT64 FileOp);

        public const int FO_DELETE = 3;
        public const int FOF_ALLOWUNDO = 0x40;
        public const int FOF_NOCONFIRMATION = 0x10; 

        public void moveToRecycle(string path)
        {
             SHFILEOPSTRUCT64 fileop = new SHFILEOPSTRUCT64();
             fileop.wFunc = FO_DELETE;
             fileop.pFrom = path + '\0' + '\0';
             fileop.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION;
             SHFileOperation(ref fileop);
         }
    }
}

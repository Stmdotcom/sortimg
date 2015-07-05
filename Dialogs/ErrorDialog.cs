using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SortImage
{
    public partial class ErrorDialog : Form
    {
        Exception ex;
        public ErrorDialog(Exception excep, string info)
        {
            InitializeComponent();
            ex = excep;
            statusBarPanelStatus.Text = info + " " + ex.ToString();
        }
        public ErrorDialog(string info)
        {
            InitializeComponent();
            statusBarPanelStatus.Text = info;
        }
        public ErrorDialog(Dictionary<string,int> dic)
        {
            InitializeComponent();
            string[] lines = new string[dic.Count];
            int i = 0;      
            foreach (KeyValuePair<string, int> kvp in dic)
                   {
                       lines[i] = "Hash" + kvp.Key + "=" + kvp.Value;
                       i++;
                  }
            statusBarPanelStatus.Lines = lines;
        }

        private void loadLastError_Click(object sender, EventArgs e)
        {
        }
    }
}

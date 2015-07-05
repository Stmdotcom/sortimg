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
    public partial class SortDialog : Form
    {

        string sortSelect = "NAME";
        bool logticked = true;
        public SortDialog(bool log)
        {
            InitializeComponent();
            logticked = log;
            if (log == true)
            {
                logCheckBox.Checked = true;
            }
            else
            {
                logCheckBox.Checked = false;
            }
        }

        private void sortNAME_Click(object sender, EventArgs e)
        {
            logticked = logCheckBox.Checked;
        }

        private void sortDATE_Click(object sender, EventArgs e)
        {
            sortSelect = "DATE";
            logticked = logCheckBox.Checked;
        }

        private void sortSize_Click(object sender, EventArgs e)
        {
            sortSelect = "SIZE";
            logticked = logCheckBox.Checked;
        }
        public string GetString()
        {
            return sortSelect;
        }
         public bool GetLogChecked()
        {
            return logticked;
        }

         private void SortDialog_Load(object sender, EventArgs e){}
    }
}

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
    public partial class ProcceingDialog2 : Form
    {
        public bool cancel = false;
		public ProcceingDialog2()
		{
			InitializeComponent();
		}

        private void ProcceingDialog2_Load(object sender, EventArgs e)
        {

        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Canceling before completion will result in no result, Are you sure?", "Confirm cancel", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cancel = true;
                
                // a 'DialogResult.Yes' value was returned from the MessageBox
                // proceed with your deletion
            }
        }
    }
}

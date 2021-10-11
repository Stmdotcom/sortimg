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
    public partial class ProcessingDialog : Form
    {
        //private int max = 1;
        public bool cancel = false;
        public ProcessingDialog()
        {
            InitializeComponent();
        }

        private void Procceing_Load(object sender, EventArgs e)
        {

        }

        private delegate void UpdateProgressBarCallback(int barValue);
        public void UpdateProgress(int barValue)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.BeginInvoke(new UpdateProgressBarCallback(this.UpdateProgress), new object[] { barValue });
            }
            else
            {
                // change your bar
                this.progressBar1.Value = barValue;
                if(this.progressBar1.Maximum == barValue)
                {
                    this.Close();
                }
            }
        }

        private delegate void setProgressMaxCallback(int barValue);
        public void SetProgressMax(int barValue)
        {
            if (this.progressBar1.InvokeRequired)
            {
                this.BeginInvoke(new setProgressMaxCallback(this.SetProgressMax), new object[] { barValue });
            }
            else
            {
                // change your bar
                this.progressBar1.Maximum = barValue;
            
            }
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

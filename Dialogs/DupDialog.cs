using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SortImage
{
    public partial class DupDialog : Form
    {
        string desta;
        string fname;
        string size;
        string dupSelect;
        private Image holder;
        //private bool renametog = true;

        public DupDialog(string filename, string dest, long ll, bool noRename, string text)
        {
            InitializeComponent();
            if (text == null || text == "")
            {
                label1.Text = "No text passed";
            }
            else
            {
                label1.Text = text;
            }   
            desta = dest;
         
            fname = filename;
            size = ll.ToString();
          //  renametog = renameTog;
            try
            {
                try
                {
                    holder = Bitmap.FromFile(dest);
                }
                catch
                {
                    //pictureBox1.Image = new Bitmap("corrupt.jpg");
                    pictureBox1.Image  = global::SortImage.Properties.Resources.corrupt;
                }
                pictureBox1.Image = new Bitmap(holder);
                holder.Dispose();
                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                this.Invalidate();
            }
            catch (Exception)
            {
            }

            if (noRename == true)
            {
                dupDialogRename.Enabled = false;
                    dupDialogRename.Visible = false;
            }

        }


        public string GetString()
        {
            return dupSelect;
        }

        private void DupDialog_Load(object sender, EventArgs e)
        {
            label2.Text = fname;
            label5.Text = size;
        }

        private void dupDialogDelete_Click(object sender, EventArgs e)
        {
            dupSelect = "DELETE";
        }

        private void dupDialogRename_Click(object sender, EventArgs e)
        {
            dupSelect = "RENAME";
        }

        /*
        private void dupDialogCancel_Click(object sender, EventArgs e)
        {

        }
         */

        private void dupDialogDupFold_Click(object sender, EventArgs e)
        {
            dupSelect = "DUP";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            bool isaGif = false;
            if (Path.GetExtension(desta) == ".gif")
            {
                isaGif = true;
            }
            GifDialog a = new GifDialog(desta, isaGif);
            a.StartPosition = FormStartPosition.CenterParent;
            a.MaximumSize = new Size(300, 300);
            try
            {
                if (a.ShowDialog() == DialogResult.OK)
                {
                    a.Dispose();
                }
            }
            catch (Exception)
            {
                a.Dispose();
              //  logger.writeConsoleError("Gif animation error", ex);
                MessageBox.Show("Gif closed due to GDI+ error in playback \n Gif may be corrupt");
            }
        }
    }
}

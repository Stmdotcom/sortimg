using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SortImage
{
    public partial class DupDialog : Form
    {
        string desta;
        string fname;
        string size;
        string dupSelect;
        private Image holder;

        public DupDialog(string filename, string dest, long size, bool noRename, string text)
        {
            InitializeComponent();
            if (text == null || text == "") {
                label1.Text = "No text passed";
            } else {
                label1.Text = text;
            }
            desta = dest;

            fname = filename;
            this.size = size.ToString();
            try {
                try {
                    holder = Image.FromFile(dest);
                } catch {
                    pictureBox1.Image = Properties.Resources.corrupt;
                }
                pictureBox1.Image = new Bitmap(holder);
                holder.Dispose();
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.Invalidate();
            } catch (Exception) {
            }

            if (noRename == true) {
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

        private void dupDialogDupFold_Click(object sender, EventArgs e)
        {
            dupSelect = "DUP";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PreviewImageDialog previewImageDialog = new PreviewImageDialog(desta, Path.GetExtension(desta) == ".gif");
            previewImageDialog.StartPosition = FormStartPosition.CenterParent;
            previewImageDialog.MaximumSize = new Size(300, 300);
            try {
                if (previewImageDialog.ShowDialog() == DialogResult.OK) {
                    previewImageDialog.Dispose();
                }
            } catch (Exception) {
                previewImageDialog.Dispose();
                MessageBox.Show("Image closed due to GDI+ error\n Image may be corrupt");
            }
        }
    }
}

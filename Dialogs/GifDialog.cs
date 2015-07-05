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
    public partial class GifDialog : Form
    {
        Image holder;
        public GifDialog(string parth, bool isaGif)
        {
                InitializeComponent();
                if (isaGif == true)
                {
                    pictureBoxGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBoxGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                }
                try
                {
                    holder = Image.FromFile(parth);
                }
                catch
                {
                 //   holder = new Bitmap("thumberror.jpg");
                    holder = global::SortImage.Properties.Resources.thumberror; 
                }
                pictureBoxGif.Image = holder;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            holder.Dispose();
            pictureBoxGif.Dispose();
        }

        private void pictureBoxGif_Click(object sender, EventArgs e)
        {
            holder.Dispose();
            pictureBoxGif.Dispose();
           this.DialogResult = DialogResult.OK;
        }

    }
}

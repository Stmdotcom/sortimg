using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SortImage
{
    public partial class ImageViewer : UserControl
    {
        private Image image;
        private string imageLocation;

        private bool isThumbnail;
        private bool isActive;

        public ImageViewer()
        {
            isThumbnail = false;
            isActive = false;
            InitializeComponent();
        }

        public Image Image
        {
            set { image = value; }
            get { return image; }
        }

        public string ImageLocation
        {
            set { imageLocation = value; }
            get { return imageLocation; }
        }

        public bool IsActive
        {
            set 
            { 
                isActive = value;
                this.Invalidate();
            }
            get { return isActive; }
        }

        public bool IsThumbnail
        {
            set { isThumbnail = value; }
            get { return isThumbnail; }
        }

        public void ImageSizeChanged(object sender, ThumbnailImageEventArgs e)
        {
            this.Width = e.Size;
            this.Height = e.Size;
            this.Invalidate();
        }

        public void LoadImage(string imageFilename, ThumbnailBuilder tnb)
        {

            image = tnb.GetThumbnail(imageFilename);
            imageLocation = imageFilename;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (g == null) return;
            if (image == null) return;

            int dw = image.Width;
            int dh = image.Height;
            int tw = this.Width - 8; // remove border, 4*4 
            int th = this.Height - 8; // remove border, 4*4 
            double zw = (tw / (double)dw);
            double zh = (th / (double)dh);
            double z = (zw <= zh) ? zw : zh;

            dw = (int)(dw * z);
            dh = (int)(dh * z);
            int dl = 4 + (tw - dw) / 2; // add border 2*2
            int dt = 4 + (th - dh) / 2; // add border 2*2

            g.DrawRectangle(new Pen(Color.Gray), dl, dt, dw, dh);

            if (isThumbnail)
            for (int j = 0; j < 3; j++)
            {
                g.DrawLine(new Pen(Color.DarkGray),
                    new Point(dl + 3, dt + dh + 1 + j),
                    new Point(dl + dw + 3, dt + dh + 1 + j));
                g.DrawLine(new Pen(Color.DarkGray),
                    new Point(dl + dw + 1 + j, dt + 3),
                    new Point(dl + dw + 1 + j, dt + dh + 3));
            }

            g.DrawImage(image, dl, dt, dw, dh);

            if (isActive)
            {
                g.DrawRectangle(new Pen(Color.White, 1), dl, dt, dw, dh);
                g.DrawRectangle(new Pen(Color.Blue, 2), dl-2, dt-2, dw+4, dh+4);
            }
        }

        /*
        private void OnResize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
         */
    }
}

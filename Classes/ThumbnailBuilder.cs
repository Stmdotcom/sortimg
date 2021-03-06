﻿using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace SortImage
{
    public class ThumbnailBuilder
    {
        private const int THUMBNAIL_DATA = 0x501B;
        public ThumbnailBuilder() { }

        public Image GetThumbnail(string path)
        {
            FileStream fs = File.OpenRead(path);
            Bitmap img = (Bitmap)Bitmap.FromStream(fs, false, false);
            try
            {
                if (Array.IndexOf(img.PropertyIdList, THUMBNAIL_DATA) > 0)
                {
                    byte[] imageBytes = img.GetPropertyItem(THUMBNAIL_DATA).Value;
                    fs.Close();
                    img.Dispose();
                    using (MemoryStream stream = new MemoryStream(imageBytes.Length))
                    {
                        stream.Write(imageBytes, 0, imageBytes.Length);
                        System.Diagnostics.Debug.WriteLine("Exif thumb");
                        return Image.FromStream(stream);
                    }
                }
            }
            catch{
                System.Diagnostics.Debug.WriteLine("Thumb build error");
            }
            Int32 ImgW = img.Width;
            Int32 ImgH = img.Height;
            Int32 imgHeight = ScaleImage(ImgW, ImgH);
            // Make this get defualt thumbnail instead or fallback to another methord
            Image.GetThumbnailImageAbort thumbAbort = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            try
            {
                Image pp = img.GetThumbnailImage(100, imgHeight, thumbAbort, IntPtr.Zero);
                fs.Close();
                img.Dispose();
                System.Diagnostics.Debug.WriteLine("System created thumb");
                return pp;
            }
            catch (Exception) //Custom thumbnail, set at high quality.
            {
                System.Diagnostics.Debug.WriteLine("Thumb build error 2");
                return customThumb(img, 100, 100);
            }
            finally
            {
                fs.Close();
                img.Dispose();
            }
        }

        private bool ThumbnailCallback()
        {
            return true;
        }

        protected Int32 ScaleImage(Int32 imgWidth, Int32 imgHeight)
        {
            double imgW = (double)imgWidth;
            double imgH = (double)imgHeight;
            imgH = imgH * (100 / imgW);
            imgHeight = Convert.ToInt32(imgH);
            return imgHeight;
        }

        public Bitmap customThumb(Bitmap img, int x, int y)
        {
            Bitmap thumb = new Bitmap(x, y);
            using (Graphics graphics = Graphics.FromImage(thumb))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(img, 0, 0, x, y);
            }
            System.Diagnostics.Debug.WriteLine("Custom created thumb");
            return thumb;
        }
    }
}

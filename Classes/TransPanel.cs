using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SortImage
{
    public class TransPanel : System.Windows.Forms.TableLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        public void InvalidateEx()
        {
            if (Parent == null)
            {
                return;
            }
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            AlphaBlend(e.Graphics);
        }
        
        /// <summary>
        /// Required to paint over controlls that are under this
        /// </summary>
        /// <param name="graphics"></param>
        private void AlphaBlend(Graphics graphics)
        {
            //the fill color
            Brush B = new SolidBrush(Color.FromArgb(100, Color.Silver));
            graphics.FillRectangle(B, 0, 0, this.Width, this.Height);
        }
    }
    
    public class TransGridPannel : System.Windows.Forms.TableLayoutPanel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Dont draw anything for this pannel - it needs to be completly transparent
        }
    }

    public class TransparentPicBox : System.Windows.Forms.PictureBox
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Dont draw anything for this pannel - it needs to be completly transparent
        }
    }
}
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using SortImage;

namespace SortImage
{
    public class PreviewLayer
    {
        public Panel panel4;
        public TableLayoutPanel layoutPanel;
        public Button ClosePanelButton;
        public string folder;
        public ArrayList filePaths;
        public Button butt;
        public Button nextSetButton;
        public int prePage;
        public ThumbnailBuilder tb;
        private FileNameBuilder fb;

        const int IMAGECOUNT = 18;

        public PreviewLayer(Size s, string folderr, Button but, int preP)
        {
            folder = folderr;
            buildLayer(s, but, preP);
            addImages(s, 1);
        }
         
        public PreviewLayer(Size s, ArrayList files, Button but, int preP)
        {
            filePaths = files;
            buildLayer(s, but, preP);
            addImages(s, 0);
        }

        public void buildLayer(Size s, Button but, int preP)
        {
            fb = new FileNameBuilder(false);
            tb = new ThumbnailBuilder();
            butt = but;
            prePage = preP;
            layoutPanel = new TableLayoutPanel();
            ClosePanelButton = new Button();
            nextSetButton = new Button();
            nextSetButton.Text = "More...";
            panel4 = new Panel();
            this.panel4.Controls.Add(nextSetButton); // New
            this.panel4.Controls.Add(ClosePanelButton);
            this.panel4.Dock = DockStyle.Fill;
            ClosePanelButton.Image = new Bitmap(global ::SortImage.Properties.Resources.buttonCancel.GetThumbnailImage(ClosePanelButton.Size.Height, ClosePanelButton.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
            ClosePanelButton.ImageAlign = ContentAlignment.MiddleRight;
            nextSetButton.Image = new Bitmap(global ::SortImage.Properties.Resources.next.GetThumbnailImage(nextSetButton.Size.Height, nextSetButton.Size.Height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero));
            nextSetButton.ImageAlign = ContentAlignment.MiddleRight;
            this.panel4.Controls.Add(layoutPanel);
            panel4.Size = s;
            panel4.BackColor = Color.Silver;
            this.layoutPanel.ColumnCount = 6;
            this.layoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            this.layoutPanel.Size = new Size(s.Width, s.Height - ClosePanelButton.Height);
            this.layoutPanel.Location = new System.Drawing.Point(50, 50);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.AutoScroll = true;
            nextSetButton.Left = 50;
            ClosePanelButton.Left = panel4.Width - ClosePanelButton.Width + 5;
        }

        public void addImages(Size siz, int flag)
        {
            int i = 0;
            int loopCount = 0;
            PictureBox picbox;
            if (flag == 1)
            {
                filePaths = fb.ProcessDirectory(folder);
            }
            int loop = (prePage * IMAGECOUNT);
            foreach (string s in filePaths)
            {
                if (loopCount < loop)
                {
                    loopCount++;
                }
                else
                {
                    if (i < IMAGECOUNT)
                    {
                        picbox = new PictureBox();
                        picbox.Size = new Size((int)(siz.Width * .15), (int)(siz.Width * .15));
                        picbox.Name = "dynaPictureBox" + i;
                        picbox.Click += new EventHandler(Picturebox_Click);
                        layoutPanel.Controls.Add(picbox);
                        SetImage(picbox, s);
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
            }

            //If there was less than IMAGECOUNT images...
            if (i < IMAGECOUNT) {
                 nextSetButton.Hide();
            }

        }

        public void SetImage(PictureBox picbox, String fileName)
        {
            try
            {
                try
                {
                    picbox.Image = tb.GetThumbnail(fileName);
                }
                catch (Exception e)
                {
                   picbox.Image = global::SortImage.Properties.Resources.thumberror;
                    Console.WriteLine("Corrupt on transpanel:   " + e);
                }
                picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't open file stream to load image for transpanel:   " + ex);
            }
        }

        public static bool ThumbnailCallback()
        {
            return true;
        }

        private void Picturebox_Click(object sender, EventArgs e)
        {
            if (butt != null)
            {
                PictureBox clickedButton = (PictureBox)sender; //get the button that was clicked
                string index = clickedButton.Name.Substring("dynaPictureBox".Length);
                string fileparth = (string)filePaths[Convert.ToInt16(index)];
                SortImg.SetbuttonIm(butt, fileparth);
                MessageBox.Show("New image chosen for folder preview");
            }
        }
    }
}
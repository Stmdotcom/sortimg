using System.Windows.Forms;
using System.Drawing;

namespace SortImage
{
    class DynamicButtons
    {
        private static int depth = 0;
        private static int alternate = 0;

        public DynamicButtons(){}
      
        public Button DynamicPicture(int currentFolder, string fileName, Button dynamicButton)
        {
            Button dynamicPicture = new Button();
            dynamicPicture.Name = "dynamicPictureBox" + currentFolder.ToString();
            dynamicPicture.Width = dynamicButton.Height;
            dynamicPicture.Height = dynamicButton.Height;
            dynamicPicture.Left = dynamicButton.Left + dynamicButton.Width + 5;
            dynamicPicture.Top = dynamicButton.Top; //Center the button vertically to textbox
            dynamicPicture.BackgroundImageLayout = ImageLayout.Stretch;
            dynamicPicture.ForeColor = Color.White;
            dynamicPicture.Text = fileName;
            dynamicPicture.TextAlign = ContentAlignment.TopRight;

            return dynamicPicture;
        }

        public Button DynamicButton(ContextMenuStrip contextMenuStrip, int currentFolder, int half)
        {
            Button dynamicButton = new Button();
            dynamicButton.ContextMenuStrip = contextMenuStrip;
            dynamicButton.Name = "dynamicButton" + currentFolder.ToString();
            dynamicButton.Width = half / 4 + 20;
            dynamicButton.Height = half / 6 * 3;
            if (alternate == 1)
            {
                dynamicButton.Left = half;
                dynamicButton.Top = 10 + (dynamicButton.Height * (depth)) + (10 * (depth)); //initial + height + padding
                alternate = 0;
                depth++;
            }
            else
            {
                dynamicButton.Left = 10;
                dynamicButton.Top = 10 + (dynamicButton.Height * depth) + (10 * depth); //initial + height + padding
                alternate = 1;
            }
            dynamicButton.Text = "Move";       
            dynamicButton.BackgroundImage = Properties.Resources.add;
            dynamicButton.BackgroundImageLayout = ImageLayout.Stretch;
            dynamicButton.BackColor = Color.Transparent;
            dynamicButton.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);

            return dynamicButton;
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SortImage
{
    internal class FormHelpers
    {
        /// <summary>
        /// Sets the button to be the relivent image
        /// </summary>
        /// <param name="calllerButton">Button that is used</param>
        /// <param name="path">Parth to Image that is used</param>
        public static void ApplyButtonImage(Button calllerButton, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            calllerButton.BackgroundImage = new Bitmap(
                System.Drawing.Image.FromStream(fileStream).GetThumbnailImage(
                    calllerButton.Size.Width,
                    calllerButton.Size.Height,
                    new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallbackStatic),
                    IntPtr.Zero
                )
            );
            fileStream.Close();
        }

        private static bool ThumbnailCallbackStatic()
        {
            return true;
        }
    }
}

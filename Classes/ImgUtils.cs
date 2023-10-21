using System.IO;
using System.Drawing;

namespace SortImage
{
    class ImgUtils
    {
        public static bool IsGif(string imagePath)
        {
            return Path.GetExtension(imagePath) == ".gif";
        }

        public static bool IsAnimated(string imagePath, Image image = null)
        {
            // Nothing other than a gif can be animated
            if (!IsGif(imagePath)) {
                return false;
            }

            try {
                if (image == null) {
                    image = Image.FromFile(imagePath);
                }

                return ImageAnimator.CanAnimate(image);
            } catch {
                return false;
            }
        }
    }
}

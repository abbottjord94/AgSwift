using System.Drawing;

namespace AgSwift_GUI
{
    public class ImageClickable
    {
        private SwiftAg_CS.Point topLeftCorner;
        private Image image;
        private string image_dir;

        public ImageClickable(Image _image, SwiftAg_CS.Point _topLeftCorner, string _image_dir)
        {
            image = _image;
            topLeftCorner = _topLeftCorner;
            image_dir = _image_dir;
        }

        public Image getImage()
        {
            return image;
        }

        public SwiftAg_CS.Point getTopLeftCorner()
        {
            return topLeftCorner;
        }

        public void setTopLeftCorner(SwiftAg_CS.Point _point)
        {
            topLeftCorner = _point;
        }

        public string getImageDir()
        {
            return image_dir;
        }
    }
}

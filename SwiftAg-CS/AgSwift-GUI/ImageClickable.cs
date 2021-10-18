using System.Drawing;

namespace AgSwift_GUI
{
    public class ImageClickable
    {
        private SwiftAg_CS.Point topLeftCorner;
        private Image image;

        public ImageClickable(Image _image, SwiftAg_CS.Point _topLeftCorner)
        {
            image = _image;
            topLeftCorner = _topLeftCorner;
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
    }
}

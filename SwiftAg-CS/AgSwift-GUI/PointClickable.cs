using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftAg_CS;

namespace AgSwift_GUI
{
    public class PointClickable : SwiftAg_CS.Point
    {
        private bool selected = false;
        public PointClickable(double _x, double _y, double _elevation) : base(_x, _y, _elevation)
        {

        }

        public bool getSelected()
        {
            return selected;
        }

        public void setSelected(bool _s)
        {
            selected = _s;
        }
    }
}

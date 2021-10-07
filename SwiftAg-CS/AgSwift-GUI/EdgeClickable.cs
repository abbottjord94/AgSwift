using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftAg_CS;

namespace AgSwift_GUI
{
    public class EdgeClickable : SwiftAg_CS.Edge
    {
        private bool selected = false;
        public EdgeClickable(SwiftAg_CS.Point _a, SwiftAg_CS.Point _b) : base(_a, _b)
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

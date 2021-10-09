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
        PointClickable _a, _b;
        private bool selected = false;
        public EdgeClickable(PointClickable _a, PointClickable _b) : base(_a, _b)
        {
            _a.addConnection(_b);
            _b.addConnection(_a);
        }

        ~EdgeClickable()
        {
            _a.removeConnection(_b);
            _b.removeConnection(_a);
        }

        public bool getSelected()
        {
            return selected;
        }

        public void setSelected(bool _s)
        {
            selected = _s;
        }

        public void deleteEdge()
        {
            _a.removeConnection(_b);
            _b.removeConnection(_a);
        }

        //Source: https://stackoverflow.com/questions/30559799/function-for-finding-the-distance-between-a-point-and-an-edge-in-java
        public double distanceFromEdge(Point _p)
        {
            double a = _p.get_x() - _a.get_x();
            double b = _p.get_y() - _a.get_y();
            double c = _b.get_x() - _a.get_x();
            double d = _b.get_y() - _a.get_y();

            double dot = a * (-d) + b * c;
            double len_sq = d * d + c * c;
            return Math.Abs(dot) / Math.Sqrt(len_sq);
        }
    }
}

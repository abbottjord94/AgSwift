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
        PointClickable _pc_a, _pc_b;
        private bool selected = false;
        public EdgeClickable(PointClickable _a, PointClickable _b) : base(_a, _b)
        {
            _pc_a = _a;
            _pc_b = _b;
            _a.addConnection(_b);
            _b.addConnection(_a);
        }

        ~EdgeClickable()
        {
            _pc_a.removeConnection(_pc_b);
            _pc_b.removeConnection(_pc_a);
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
            _pc_a.removeConnection(_pc_b);
            _pc_b.removeConnection(_pc_a);
        }

        //Source: https://stackoverflow.com/questions/30559799/function-for-finding-the-distance-between-a-point-and-an-edge-in-java
/*        public double distanceFromEdge(Point _p)
        {
            double a = _p.get_x() - _pc_a.get_x();
            double b = _p.get_y() - _pc_a.get_y();
            double c = _pc_b.get_x() - _pc_a.get_x();
            double d = _pc_b.get_y() - _pc_a.get_y();
            double e = -d;
            double f = c;

            double dot = (a * e) + (b * f);
            double len_sq = (e * e) + (f * f);
            return (dot * dot) / len_sq;
        }*/
    }
}

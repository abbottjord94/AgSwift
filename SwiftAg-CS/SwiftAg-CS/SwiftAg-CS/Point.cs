using System;

namespace SwiftAg_CS
{
    public class Point : Vertex
    {
        private double elevation;

        public Point(double _x, double _y, double _elevation) : base(_x, _y)
        {
            x = _x;
            y = _y;
            elevation = _elevation;
        }

        public void set_x(double _x)
        {
            x = _x;
        }

        public void set_y(double _y)
        {
            y = _y;
        }

        public void set_elevation(double _elevation)
        {
            elevation = _elevation;
        }

        public double get_x()
        {
            return x;
        }

        public double get_y()
        {
            return y;
        }

        public double get_elevation()
        {
            return elevation;
        }

        public double distance(Point _p)
        {
            return Math.Sqrt(Math.Pow(_p.get_x() - x, 2) + Math.Pow(_p.get_y() - y, 2));
        }

        public static bool operator==(Point _a, Point _b)
        {
            if (_a.get_x() == _b.get_x() && _a.get_y() == _b.get_y()) return true;
            else return false;
        }

        public static bool operator!=(Point _a, Point _b)
        {
            if (_a.get_x() == _b.get_x() && _a.get_y() == _b.get_y()) return false;
            else return true;
        }
        public override int GetHashCode()
        {
            int prime_a = 37;
            int prime_b = 97;
            unchecked
            {
                int hash = prime_a;
                hash = hash * prime_b + x.GetHashCode();
                hash = hash * prime_b + y.GetHashCode();
                return hash;
            }
        }
    }
}

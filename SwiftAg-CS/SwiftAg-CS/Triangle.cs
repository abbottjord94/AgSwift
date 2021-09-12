using System;

namespace SwiftAg_CS
{
    public class Triangle
    {
        private Point a;
        private Point b;
        private Point c;

        private Edge ab;
        private Edge bc;
        private Edge ca;

        public Triangle(Point _a, Point _b, Point _c)
        {
            a = _a;
            b = _b;
            c = _c;

            ab = new Edge(a, b);
            bc = new Edge(b, c);
            ca = new Edge(c, a);
        }

        public Triangle(Point _a, Edge _bc)
        {
            a = _a;
            b = _bc.get_a();
            c = _bc.get_b();

            ab = new Edge(a, b);
            bc = new Edge(b, c);
            ca = new Edge(c, a);
        }

        public bool containsPoint(Point _p)
        {
            if (a == _p || b == _p || c == _p) return true;
            else return false;
        }

        public bool containsEdge(Edge _e)
        {
            if (ab == _e || bc == _e || ca == _e) return true;
            else return false;
        }

        public Point get_a()
        {
            return a;
        }

        public Point get_b()
        {
            return b;
        }

        public Point get_c()
        {
            return c;
        }

        public Edge get_ab()
        {
            return ab;
        }

        public Edge get_bc()
        {
            return bc;
        }

        public Edge get_ca()
        {
            return ca;
        }

        public Edge getSharedEdge(Triangle _t)
        {
            if (ab == _t.get_ab()) return ab;
            else if (bc == _t.get_ab()) return bc;
            else if (ca == _t.get_ab()) return ca;

            else if (ab == _t.get_bc()) return ab;
            else if (bc == _t.get_bc()) return bc;
            else if (ca == _t.get_bc()) return ca;

            else if (ab == _t.get_ca()) return ab;
            else if (bc == _t.get_ca()) return bc;
            else if (ca == _t.get_ca()) return ca;

            else return null;
        }

        public bool hasSharedEdge(Triangle _t)
        {
            if (getSharedEdge(_t) != null) return true;
            else return false;
        }

        public Tuple<Point, double> circumcircle()
        {
            double D = ((a.get_x() - c.get_x()) * (b.get_y() - c.get_y()) - (b.get_x() - c.get_x()) * (a.get_y() - c.get_y()));
            double center_x = (((a.get_x() - c.get_x()) * (a.get_x() + c.get_x()) + (a.get_y() - c.get_y()) * (a.get_y() + c.get_y())) / 2 * (b.get_y() - c.get_y()) - ((b.get_x() - c.get_x()) * (b.get_x() + c.get_x()) + (b.get_y() - c.get_y()) * (b.get_y() + c.get_y())) / 2 * (a.get_y() - c.get_y())) / D;
            double center_y = (((b.get_x() - c.get_x()) * (b.get_x() + c.get_x()) + (b.get_y() - c.get_y()) * (b.get_y() + c.get_y())) / 2 * (a.get_x() - c.get_x()) - ((a.get_x() - c.get_x()) * (a.get_x() + c.get_x()) + (a.get_y() - c.get_y()) * (a.get_y() + c.get_y())) / 2 * (b.get_x() - c.get_x())) / D;
            double radius = Math.Sqrt(Math.Pow(c.get_x() - center_x, 2) + Math.Pow(c.get_y() - center_y, 2));

            Tuple<Point, double> cc = new Tuple<Point, double>(new Point(center_x, center_y, 0), radius);
            return cc;
        }

        public double sign()
        {
            return (a.get_x() - c.get_x()) * (b.get_y() - c.get_y()) - (b.get_x() - c.get_x()) * (a.get_y() - c.get_y());
        }
        public bool pointInTriangle(Point _p)
        {
            double d1, d2, d3;
            bool neg, pos;

            Triangle t1 = new Triangle(_p, ab);
            Triangle t2 = new Triangle(_p, bc);
            Triangle t3 = new Triangle(_p, ca);

            d1 = t1.sign();
            d2 = t2.sign();
            d3 = t3.sign();

            neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(neg && pos);
        }

        double getHeightAtPoint(Point _p)
        {
            if (!pointInTriangle(_p)) return 0;
            else
            {

                double d1 = _p.distance(a);
                double d2 = _p.distance(b);
                double d3 = _p.distance(c);
                double total_dist = d1 + d2 + d3;

                double h = ((d1 / total_dist) * a.get_elevation()) + ((d2 / total_dist) * b.get_elevation()) + ((d3 / total_dist) * c.get_elevation());
                return h;
            }
        }

    }
}

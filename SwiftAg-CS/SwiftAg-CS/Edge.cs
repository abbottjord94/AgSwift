using System;

namespace SwiftAg_CS
{
    public class Edge
    {
        private Point a;
        private Point b;
        public Edge(Point _a, Point _b)
        {
            if (_a == _b) throw new ArgumentException("Points on an edge can not be equivalent.");
            a = _a;
            a.addConnection(this);
            b = _b;
            b.addConnection(this);
        }

        public Point get_a()
        {
            return a;
        }

        public Point get_b()
        {
            return b;
        }

        public bool containsPoint(Point _p)
        {
            if (a == _p || b == _p)
            {
                return true;
            }
            else return false;
        }

        public double length()
        {
            return a.distance(b);
        }

        public bool intersects(Edge _e)
        {
            double x1 = a.get_x();
            double x2 = b.get_x();
            double y1 = a.get_y();
            double y2 = b.get_y();

            double x3 = _e.get_a().get_x();
            double x4 = _e.get_b().get_x();
            double y3 = _e.get_a().get_y();
            double y4 = _e.get_b().get_y();

            double t = (((x1 - x3) * (y3 - y4)) - ((y1 - y3) * (x3 - x4))) / (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)));
            double u = (((x2 - x1) * (y1 - y3)) - ((y2 - y1) * (x1 - x3))) / (((x1 - x2) * (y3 - y4)) - ((y1 - y2) * (x3 - x4)));

            if ((t >= 0 && t <= 1) && (u >= 0 && u <= 1))
            {
                double x_int = x1 + t * (x2 - x1);
                double y_int = y1 + t * (y2 - y1);
                Point int_point = new Point(x_int, y_int, 0);
                if (containsPoint(int_point))
                {
                    return false;
                }
                else return true;
            }
            else return false;
        }

        public static bool operator==(Edge _a, Edge _b)
        {
            if((_a.get_a() == _b.get_a()) && (_a.get_b() == _b.get_b()))
            {
                return true;
            }
            if ((_a.get_a() == _b.get_b()) && (_a.get_b() == _b.get_a()))
            {
                return true;
            }
            else return false;
        }
        public static bool operator !=(Edge _a, Edge _b)
        {
            if ((_a.get_a() == _b.get_a() || _a.get_b() == _b.get_a()) && (_a.get_b() == _b.get_a() || _a.get_b() == _b.get_b())) return false;
            else return true;
        }
    }


}

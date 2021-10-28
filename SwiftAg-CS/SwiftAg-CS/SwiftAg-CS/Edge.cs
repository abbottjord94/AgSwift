using System;

namespace SwiftAg_CS
{
    public class Edge
    {
        private Point a;
        private Point b;
        public Edge(Point _a, Point _b)
        {
            a = _a;
            b = _b;
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

        public Point getIntersectionPoint(Edge _e)
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
                return int_point;
            }
            else return null;
        }

        public double distanceFromEdge(Point _p)
        {
            bool dx_dominate = false;
            bool dy_dominate = false;

            if (Math.Abs(a.get_x() - b.get_x()) > Math.Abs(a.get_y() - b.get_y()))
            {
                dx_dominate = true;
            }
            else
            {
                dy_dominate = true;
            }

            if (dx_dominate)
            {

                double[] xs = new double[2];
                xs[0] = a.get_x();
                xs[1] = b.get_x();
                Array.Sort(xs);
                if (xs[0] < _p.get_x() && xs[1] > _p.get_x())
                {
                    double d_a = _p.distance(a);
                    double a_d = _p.get_x() - a.get_x();

                    return Math.Sqrt(Math.Pow(d_a,2) - Math.Pow(a_d, 2));

                    
                }
                else
                {
                    if(_p.distance(a) < _p.distance(b))
                    {
                        return _p.distance(a);
                    }
                    else
                    {
                        return _p.distance(b);
                    }
                }

            }

            else if (dy_dominate)
            {
                double[] ys = new double[2];
                ys[0] = a.get_y();
                ys[1] = b.get_y();
                Array.Sort(ys);
                if (ys[0] < _p.get_y() && ys[1] > _p.get_y())
                {
                    double d_a = _p.distance(a);
                    double a_d = _p.get_y() - a.get_y();

                    return Math.Sqrt(Math.Pow(d_a, 2) - Math.Pow(a_d, 2));
                }
                else
                {
                    if (_p.distance(a) < _p.distance(b))
                    {
                        return _p.distance(a);
                    }
                    else
                    {
                        return _p.distance(b);
                    }
                }
            }
            else
            {
                return 9999999;
            }
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
            if ((_a.get_a() == _b.get_a()) && (_a.get_b() == _b.get_b()))
            {
                return false;
            }
            if ((_a.get_a() == _b.get_b()) && (_a.get_b() == _b.get_a()))
            {
                return false;
            }
            else return true;
        }
        public override int GetHashCode()
        {
            int prime_a = 37;
            int prime_b = 97;
            unchecked
            {
                int hash = prime_a;
                hash = hash * prime_b + a.GetHashCode();
                hash = hash * prime_b + b.GetHashCode();
                return hash;
            }
        }
    }


}

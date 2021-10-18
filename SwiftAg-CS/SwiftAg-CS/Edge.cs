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

        //Source: https://stackoverflow.com/questions/30559799/function-for-finding-the-distance-between-a-point-and-an-edge-in-java
        public double distanceFromEdge(Point _p)
        {
            double A = _p.get_x() - a.get_x();
            double B = _p.get_y() - a.get_y();
            double C = b.get_x() - a.get_x();
            double D = b.get_y() - a.get_y();
            double E = -D;
            double F = C;

            double dot = (A * E) + (B * F);
            double len_sq = (E * E) + (F * F);
            return (dot * dot) / len_sq;
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

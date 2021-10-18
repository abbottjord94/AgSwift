using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftAg_CS
{
    public class Vertex
    {
        public double x, y;

        protected Vertex() { }

        public Vertex(double x, double y)
        {
            this.x = x; this.y = y;
        }

        public double distance2To(Vertex other)
        {
            double dx = x - other.x;
            double dy = y - other.y;
            return dx * dx + dy * dy;
        }

        public float distanceTo(Vertex other)
        {
            return (float)Math.Sqrt(distance2To(other));
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}

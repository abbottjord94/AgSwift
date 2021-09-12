using SwiftAg_CS;
using NUnit.Framework;

namespace SwiftAg_CS_Tests
{
    public class TriangleTests
    {
        Triangle t1, t2;
        Point p1, p2, p3, e1a, e1b;
        Edge e1;

        [SetUp]
        public void Setup()
        {
            p1 = new Point(0, 0, 0);
            p2 = new Point(10, 0, 0);
            p3 = new Point(0, 10, 0);

            e1a = new Point(3, 3, 0);
            e1b = new Point(6, 3, 0);

            e1 = new Edge(e1a, e1b);

            t1 = new Triangle(p1, p2, p3);
            t2 = new Triangle(p3, e1);
        }

        [Test]
        public void CreateTriangleTest()
        {
            if(t1.get_a() == p1 && t1.get_b() == p2 && t1.get_c() == p3)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TriangleContainsPointTest()
        {
            if(t1.containsPoint(p1))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TriangleContainsEdgeTest()
        {
            if(t2.containsEdge(e1))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void PointInsideTriangleTest()
        {
            if(t1.pointInTriangle(e1a))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

    }
}

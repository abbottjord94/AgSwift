using SwiftAg_CS;
using NUnit.Framework;

namespace SwiftAg_CS_Tests
{
    public class GraphTests
    {
        private Graph g1;
        private Point p1, p2, p3;
        private Edge e1, e2;
        [SetUp]
        public void Setup()
        {
            g1 = new Graph();
            p1 = new Point(1, 2, 0);
            p2 = new Point(2, 3, 0);
            p3 = new Point(3, 1, 0);
            e1 = new Edge(p1, p2);
            e2 = new Edge(p2, p3);
        }

        [Test]
        public void AddPointTest()
        {

            g1.addPoint(p1);
            g1.addPoint(p2);
            g1.addPoint(p3);
            if(g1.containsPoint(p1) && g1.containsPoint(p2) && g1.containsPoint(p3))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void AddEdgeTest()
        {

            g1.addEdge(e1);
            g1.addEdge(e2);

            if(g1.containsEdge(e1) && g1.containsEdge(e2))
            {
                Assert.Pass();
            } 
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void AddTriangleTest()
        {
            Triangle t1 = new Triangle(p1, e2);
            g1.addTriangle(t1);
            if(g1.containsTriangle(t1))
            {
                Assert.Pass();
            } 
            else
            {
                Assert.Fail();
            }
        }
    }
}

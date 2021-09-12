using SwiftAg_CS;
using NUnit.Framework;

namespace SwiftAg_CS_Tests
{
    public class EdgeTests
    {
        private Point a;
        private Point b;
        private Point c;
        private Point d;

        private Edge ab;
        private Edge cd;
        [SetUp]
        public void Setup()
        {
            a = new Point(0, 5, 0);
            b = new Point(10, 5, 0);
            c = new Point(3, 0, 0);
            d = new Point(3, 10, 0);

            ab = new Edge(a, b);
            cd = new Edge(c, d);
        }

        [Test]
        public void EdgeCreateTest()
        {
            if (ab.get_a() == a && ab.get_b() == b)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EdgeGetATest()
        {
            if (ab.get_a() == a)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EdgeGetBTest()
        {
            if (ab.get_b() == b)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EdgeContainsPointTest()
        {
            if(ab.containsPoint(a))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EdgeIntersectionTest()
        {
            if(ab.intersects(cd))
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void EdgeEqualityTest()
        {
            if(ab != cd)
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }
    }
}

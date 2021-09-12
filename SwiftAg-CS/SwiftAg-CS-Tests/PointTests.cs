using SwiftAg_CS;
using NUnit.Framework;

namespace SwiftAg_CS_Tests
{
    public class PointTests
    {
        private Point p;
        private Point a;
        private Point b;

        [SetUp]
        public void Setup()
        {
            p = new Point(10, 10, 10);
            a = new Point(1, 1, 1);
            b = new Point(1, 1, 1);
        }

        [Test]
        public void TestCreatePoint()
        {
            if (p.get_x() == 10 && p.get_y() == 10 && p.get_elevation() == 10)
            {
                Assert.Pass();
            }
            else
            {
                if(p.get_x() != 10)
                {
                    Assert.Fail("X coordinate not correctly set");
                }
                if (p.get_y() != 10)
                {
                    Assert.Fail("Y coordinate not correctly set");
                }
                if (p.get_elevation() != 10)
                {
                    Assert.Fail("Elevation not correctly set");
                }

            }
        }

        [Test]
        public void TestGetPointX()
        {
            if(p.get_x() == 10)
            {
                Assert.Pass();
            } else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestGetPointY()
        {
            if (p.get_y() == 10)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestGetPointElevation()
        {
            if (p.get_elevation() == 10)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestSetPointX()
        {
            p.set_x(5);
            if (p.get_x() == 5)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestSetPointY()
        {
            p.set_y(5);
            if (p.get_y() == 5)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void TestSetPointElevation()
        {
            p.set_elevation(5);
            if (p.get_elevation() == 5)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        public void TestPointEquality()
        {
            if (a == b)
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
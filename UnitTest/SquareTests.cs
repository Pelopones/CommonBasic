using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonBasic;

namespace UnitTest
{
    [TestClass]
    public class SquareTests
    {
        // unit test code
        [TestMethod]
        public void RectangularTriangle()
        {
            // angle
            double a = 2, b = 3, SValid = 3;

            // assert
            Assert.AreEqual(SValid, Square.RectangularTriangle(a, b), "Square rectangular triangle not correctly");
        }

        [TestMethod]
        public void RectangularTriangleOutOfRange()
        {
            // angle
            double a = -6, b = 3, SValid = 0;

            // assert
            Assert.AreEqual(SValid, Square.RectangularTriangle(a, b), "Square rectangular triangle not correctly");
        }
    }
}

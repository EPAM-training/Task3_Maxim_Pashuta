using EPAM_Task3.Figures.SkinFigures;
using NUnit.Framework;
using System;

namespace EPAM_Task3_NUnitTest.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinCircle.
    /// </summary>
    public class SkinCircleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="resultRadius">Result Radius</param>
        /// <param name="sides">Sides of Skin Rectangle</param>
        [TestCase(5, 12, 14)]
        public void Test_SkinCircle(double resultRadius, params double[] sides)
        {
            var skinRectangle = new SkinRectangle(sides);
            var result = new SkinCircle(resultRadius, skinRectangle);
            var actualResult = new SkinCircle(resultRadius);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor throws Exception.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="radius">Radius</param>
        /// <param name="sides">Sides</param>
        [TestCase(typeof(ArgumentException), "You cannot create a shape because the original shape is smaller.", 5, 4, 6)]
        [TestCase(typeof(ArgumentException), "The argument less or equal a zero.", -5, 4, 6)]
        [TestCase(typeof(ArgumentException), "The argument less or equal a zero.", 0, 4, 6)]
        public void Test_SkinCircle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides)
        {
            var skinRectangle = new SkinRectangle(sides);

            Assert.That(() => new SkinCircle(radius, skinRectangle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="actualResult">Result Area</param>
        [TestCase(5, 78.5398163)]
        public void Test_GetArea(double radius, double actualResult)
        {
            var skinCircle = new SkinCircle(radius);
            double result = skinCircle.GetArea();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="actualResult">Result Perimeter</param>
        [TestCase(5, 31.4159265)]
        public void Test_GetPerimeter(double radius, double actualResult)
        {
            var skinCircle = new SkinCircle(radius);
            double result = skinCircle.GetPerimeter();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

using EPAM_Task3.Figures.SkinFigures;
using NUnit.Framework;
using System;

namespace EPAM_Task3_NUnitTest.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinRectangle.
    /// </summary>
    public class SkinRectangleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="resultSides">Result Sides</param>
        [TestCase(5, 2, 4)]
        public void Test_SkinRectangle(double radius, params double[] resultSides)
        {
            var skinCircle = new SkinCircle(radius);
            var result = new SkinRectangle(resultSides, skinCircle);
            var actualResult = new SkinRectangle(resultSides);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor throws Exception.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="radius">Radius</param>
        /// <param name="sides">Sides</param>
        [TestCase(typeof(ArgumentException), "You cannot create a shape because the original shape is smaller.", 5, 12, 14)]
        [TestCase(typeof(ArgumentException), "The count of sides is not equal to two or four.", 5, 12)]
        [TestCase(typeof(ArgumentException), "The count of sides is not equal to two or four.", 5, 12, 14, 15)]
        public void Test_SkinRectangle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides)
        {
            var skinCircle = new SkinCircle(radius);

            Assert.That(() => new SkinRectangle(sides, skinCircle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="actualResult">Result Area</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(48, 6, 8)]
        public void Test_GetArea(double actualResult, params double[] sides)
        {
            var skinRectangle = new SkinRectangle(sides);
            double result = skinRectangle.GetArea();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        /// <param name="actualResult">Result Perimeter</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(14, 6, 8)]
        public void Test_GetPerimeter(double actualResult, params double[] sides)
        {
            var skinRectangle = new SkinRectangle(sides);
            double result = skinRectangle.GetPerimeter();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

using EPAM_Task3.Figures.SkinFigures;
using NUnit.Framework;
using System;

namespace EPAM_Task3_NUnitTest.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinTriangle.
    /// </summary>
    public class SkinTriangleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="resultSides">Result Sides</param>
        [TestCase(5, 3, 4, 5)]
        public void Test_SkinTriangle(double radius, params double[] resultSides)
        {
            var skinCircle = new SkinCircle(radius);
            var result = new SkinTriangle(resultSides, skinCircle);
            var actualResult = new SkinTriangle(resultSides);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor throws Exception.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="radius">Radius</param>
        /// <param name="sides">Sides</param>
        [TestCase(typeof(ArgumentException), "You cannot create a shape because the original shape is smaller.", 5, 13, 14, 15)]
        [TestCase(typeof(ArgumentException), "The count of sides is not equal to three.", 5, 13, 14)]
        public void Test_SkinTriangle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides)
        {
            var skinCircle = new SkinCircle(radius);

            Assert.That(() => new SkinTriangle(sides, skinCircle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="actualResult">Result Area</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(17.888543, 6, 8, 6)]
        public void Test_GetArea(double actualResult, params double[] sides)
        {
            var skinTriangle = new SkinTriangle(sides);
            double result = skinTriangle.GetArea();

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        /// <param name="actualResult">Result Perimeter</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(20, 6, 8, 6)]
        public void Test_GetPerimeter(double actualResult, params double[] sides)
        {
            var skinTriangle = new SkinTriangle(sides);
            double result = skinTriangle.GetPerimeter();

            Assert.AreEqual(result, actualResult, 0.000001);
        }
    }
}

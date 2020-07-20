using EPAM_Task3.Figures.SkinFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinRectangle.
    /// </summary>
    [TestClass]
    public class SkinRectangleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void SkinRectangle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var skinCircle = new SkinCircle(5);
            var result = new SkinRectangle(new List<double> { 2, 4 }, skinCircle);
            var actualResult = new SkinRectangle(new List<double> { 2, 4 });

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinRectangle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var skinCircle = new SkinCircle(5);
            var result = new SkinRectangle(new List<double> { 12, 14 }, skinCircle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var sidesList = new List<double> { 6, 8, 6, 8 };
            var rectangle = new SkinRectangle(sidesList);
            double result = rectangle.GetArea();
            double actualResult = 48;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var sidesList = new List<double> { 6, 8 };
            var rectangle = new SkinRectangle(sidesList);
            double result = rectangle.GetPerimeter();
            double actualResult = 14;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

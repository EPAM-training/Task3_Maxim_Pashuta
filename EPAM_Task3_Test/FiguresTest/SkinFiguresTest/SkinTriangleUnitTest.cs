using EPAM_Task3.Figures.SkinFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinTriangle.
    /// </summary>
    [TestClass]
    public class SkinTriangleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void SkinTriangle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var skinCircle = new SkinCircle(5);
            var result = new SkinTriangle(new List<double> { 3, 4, 5 }, skinCircle);
            var actualResult = new SkinTriangle(new List<double> { 3, 4, 5 });

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var paperCircle = new SkinCircle(5);
            var result = new SkinTriangle(new List<double> { 13, 14, 15 }, paperCircle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var sidesList = new List<double> { 6, 8, 6 };
            var rectangle = new SkinTriangle(sidesList);
            double result = rectangle.GetArea();
            double actualResult = 17.888543;
            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var sidesList = new List<double> { 6, 8, 6 };
            var rectangle = new SkinTriangle(sidesList);
            double result = rectangle.GetPerimeter();
            double actualResult = 20;
            Assert.AreEqual(result, actualResult, 0.000001);
        }
    }
}

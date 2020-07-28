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
            var sidesSkinRectangle = new List<double> { 2, 4 };
            var radiusSkinCircle = 5;

            var skinCircle = new SkinCircle(radiusSkinCircle);
            var result = new SkinRectangle(sidesSkinRectangle, skinCircle);
            var actualResult = new SkinRectangle(sidesSkinRectangle);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinRectangle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var sidesSkinRectangle = new List<double> { 12, 14 };
            var radiusSkinCircle = 5;

            var skinCircle = new SkinCircle(radiusSkinCircle);
            var result = new SkinRectangle(sidesSkinRectangle, skinCircle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var sidesSkinRectangle = new List<double> { 6, 8, 6, 8 };

            var skinRectangle = new SkinRectangle(sidesSkinRectangle);
            double result = skinRectangle.GetArea();
            double actualResult = 48;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var sidesSkinRectangle = new List<double> { 6, 8 };

            var skinRectangle = new SkinRectangle(sidesSkinRectangle);
            double result = skinRectangle.GetPerimeter();
            double actualResult = 14;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

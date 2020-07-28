using EPAM_Task3.Figures.SkinFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.SkinFiguresTest
{
    /// <summary>
    /// Class for testing the class SkinCircle.
    /// </summary>
    [TestClass]
    public class SkinCircleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void SkinCircle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var sidesSkinRectangle = new List<double> { 12, 14 };
            var radiusSkinCircle = 5;

            var skinRectangle = new SkinRectangle(sidesSkinRectangle);
            var result = new SkinCircle(radiusSkinCircle, skinRectangle);
            var actualResult = new SkinCircle(radiusSkinCircle);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var sidesSkinRectangle = new List<double> { 4, 6 };
            var radiusSkinCircle = 5;

            var skinRectangle = new SkinRectangle(sidesSkinRectangle);
            var result = new SkinCircle(radiusSkinCircle, skinRectangle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var radiusSkinCircle = 5;

            var skinCircle = new SkinCircle(radiusSkinCircle);
            double result = skinCircle.GetArea();
            var actualResult = 78.5398163;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var radiusSkinCircle = 5;

            var skinCircle = new SkinCircle(radiusSkinCircle);
            double result = skinCircle.GetPerimeter();
            var actualResult = 31.4159265;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

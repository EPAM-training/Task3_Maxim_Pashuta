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
            var paperRectangle = new SkinRectangle(new List<double> { 12, 14 });
            var result = new SkinCircle(5, paperRectangle);
            var actualResult = new SkinCircle(5);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var paperRectangle = new SkinRectangle(new List<double> { 4, 6 });
            var result = new SkinCircle(5, paperRectangle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var circle = new SkinCircle(5);
            double result = circle.GetArea();
            double actualResult = 78.5398163;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var circle = new SkinCircle(5);
            double result = circle.GetPerimeter();
            double actualResult = 31.4159265;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}

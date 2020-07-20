using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperCircle.
    /// </summary>
    [TestClass]
    public class PaperCircleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void PaperCircle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var paperRectangle = new PaperRectangle(new List<double> { 12, 14 }, Color.Black);
            var result = new PaperCircle(5, paperRectangle);
            var actualResult = new PaperCircle(5, Color.Black);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var paperRectangle = new PaperRectangle(new List<double> { 4, 6 }, Color.Black);
            var result = new PaperCircle(5, paperRectangle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var circle = new PaperCircle(5, Color.Blue);
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
            var circle = new PaperCircle(5, Color.Blue);
            double result = circle.GetPerimeter();
            double actualResult = 31.4159265;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure when figure is recolor fr first time.
        /// </summary>
        [TestMethod]
        public void RecolorFigure_WhenFigureIsRecolorForFirstTime_NewColor()
        {
            var circle = new PaperCircle(5, Color.Blue);
            circle.RecolorFigure(Color.Green);
            Color result = circle.Color;
            Color actualResult = Color.Green;
            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method RecolorFigure when figure is recolor fr first time.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecolorFigure_WhenFigureIsRecolorNotForFirstTime_GetArgumentException()
        {
            var circle = new PaperCircle(5, Color.Blue);
            circle.RecolorFigure(Color.Green);
            circle.RecolorFigure(Color.Red);
        }
    }
}

using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperRectangle.
    /// </summary>
    [TestClass]
    public class PaperRectangleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void PaperRectangle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var sidesPaperRectangle = new List<double> { 2, 4 };
            var radiusPaperCircle = 5;

            var paperCircle = new PaperCircle(radiusPaperCircle, Color.Red);
            var result = new PaperRectangle(sidesPaperRectangle, paperCircle);
            var actualResult = new PaperRectangle(sidesPaperRectangle, Color.Red);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var sidesPaperRectangle = new List<double> { 12, 14 };
            var radiusPaperCircle = 5;

            var paperCircle = new PaperCircle(radiusPaperCircle, Color.Red);
            var result = new PaperRectangle(sidesPaperRectangle, paperCircle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var sidesPaperRectangle = new List<double> { 6, 8, 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Red);
            double result = paperRectangle.GetArea();
            double actualResult = 48;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var sidesPaperRectangle = new List<double> { 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Red);
            double result = paperRectangle.GetPerimeter();
            double actualResult = 14;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure when figure is recolor fr first time.
        /// </summary>
        [TestMethod]
        public void RecolorFigure_WhenFigureIsRecolorForFirstTime_NewColor()
        {
            var sidesPaperRectangle = new List<double> { 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Red);
            paperRectangle.RecolorFigure(Color.Green);
            Color result = paperRectangle.Color;
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
            var sidesPaperRectangle = new List<double> { 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Red);
            paperRectangle.RecolorFigure(Color.Green);
            paperRectangle.RecolorFigure(Color.Black);
        }
    }
}

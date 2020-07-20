using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperTriangle.
    /// </summary>
    [TestClass]
    public class PaperTriangleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestMethod]
        public void PaperTriangle_WhenOldAreaMoreNewArea_CreatePaperCircle()
        {
            var paperCircle = new PaperCircle(5, Color.Red);
            var result = new PaperTriangle(new List<double> { 3, 4, 5 }, paperCircle);
            var actualResult = new PaperTriangle(new List<double> { 3, 4, 5 }, Color.Red);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var paperCircle = new PaperCircle(5, Color.Red);
            var result = new PaperTriangle(new List<double> { 13, 14, 15 }, paperCircle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var sidesList = new List<double> { 6, 8, 6 };
            var rectangle = new PaperTriangle(sidesList, Color.Red);
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
            var rectangle = new PaperTriangle(sidesList, Color.Red);
            double result = rectangle.GetPerimeter();
            double actualResult = 20;
            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure when figure is recolor fr first time.
        /// </summary>
        [TestMethod]
        public void RecolorFigure_WhenFigureIsRecolorForFirstTime_NewColor()
        {
            var sidesList = new List<double> { 6, 8, 6 };
            var rectangle = new PaperTriangle(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            Color result = rectangle.Color;
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
            var sidesList = new List<double> { 6, 8, 6 };
            var rectangle = new PaperTriangle(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            rectangle.RecolorFigure(Color.Black);
        }
    }
}

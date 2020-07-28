using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperCircle.
    /// </summary>
    public class PaperCircleUnitTest
    {
        /// <summary>
        /// The method tests constructor when old area more new area.
        /// </summary>
        [TestCase(12, 14, ExpectedResult = 5)]
        public void PaperCircle_WhenOldAreaMoreNewArea_CreatePaperCircle(params double[] sidesPaperRectangle)
        {
            var radiusPaperCircle = 5;

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Black);
            var result = new PaperCircle(radiusPaperCircle, paperRectangle);
            var actualResult = new PaperCircle(radiusPaperCircle, Color.Black);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor when old area less new area.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircle_WhenOldAreaLessNewArea_GetArgumentException()
        {
            var sidesPaperRectangle = new List<double> { 4, 6 };
            var radiusPaperCircle = 5;

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, Color.Black);
            var result = new PaperCircle(radiusPaperCircle, paperRectangle);
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        [TestMethod]
        public void Test_GetArea()
        {
            var radiusPaperCircle = 5;

            var circle = new PaperCircle(radiusPaperCircle, Color.Blue);
            double result = circle.GetArea();
            var actualResult = 78.5398163;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetPerimeter()
        {
            var radiusPaperCircle = 5;

            var circle = new PaperCircle(radiusPaperCircle, Color.Blue);
            double result = circle.GetPerimeter();
            var actualResult = 31.4159265;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure when figure is recolor fr first time.
        /// </summary>
        [TestMethod]
        public void RecolorFigure_WhenFigureIsRecolorForFirstTime_NewColor()
        {
            var radiusPaperCircle = 5;

            var circle = new PaperCircle(radiusPaperCircle, Color.Blue);
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
            var radiusPaperCircle = 5;

            var circle = new PaperCircle(radiusPaperCircle, Color.Blue);
            circle.RecolorFigure(Color.Green);
            circle.RecolorFigure(Color.Red);
        }
    }
}

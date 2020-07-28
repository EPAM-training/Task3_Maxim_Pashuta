using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task3_NUnitTest.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperTriangle.
    /// </summary>
    public class PaperTriangleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="resultSides">Result Sides</param>
        [TestCase(5, 3, 4, 5)]
        public void Test_PaperTriangle(double radius, params double[] resultSides)
        {
            var paperCircle = new PaperCircle(radius, Color.Red);
            var result = new PaperTriangle(resultSides, paperCircle);
            var actualResult = new PaperTriangle(resultSides, Color.Red);

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
        public void Test_PaperTriangle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides)
        {
            var paperCircle = new PaperCircle(radius, Color.Red);

            Assert.That(() => new PaperTriangle(sides, paperCircle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="actualResult">Result Area</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(17.888543, 6, 8, 6)]
        public void Test_GetArea(double actualResult, params double[] sides)
        {
            var paperTriangle = new PaperTriangle(sides, Color.Red);
            double result = paperTriangle.GetArea();

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
            var paperTriangle = new PaperTriangle(sides, Color.Red);
            double result = paperTriangle.GetPerimeter();

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure.
        /// </summary>
        /// <param name="colorBlue">Color Blue</param>
        /// <param name="actualResult">Result Color Green</param>
        [TestCase(Color.Blue, Color.Green)]
        public void Test_RecolorFigure(Color colorBlue, Color actualResult)
        {
            var sides = new List<double> { 6, 8, 8 };

            var paperTriangle = new PaperTriangle(sides, colorBlue);
            paperTriangle.RecolorFigure(actualResult);
            Color result = paperTriangle.Color;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method RecolorFigure throws ArgumentException.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="colorBlue">Color Blue</param>
        /// <param name="colorGreen">Color Green</param>
        /// <param name="colorRed">Color Red</param>
        [TestCase(typeof(ArgumentException), "You can only recolor a shape once.", Color.Blue, Color.Green, Color.Red)]
        public void Test_RecolorFigure_ThrowsArgumentException(Type typeException, string exceptionMessage, Color colorBlue, Color colorGreen, Color colorRed)
        {
            var sidesPaperRectangle = new List<double> { 6, 8, 6 };

            var paperTriangle = new PaperTriangle(sidesPaperRectangle, colorBlue);
            paperTriangle.RecolorFigure(colorGreen);

            Assert.That(() => paperTriangle.RecolorFigure(colorRed), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }
    }
}

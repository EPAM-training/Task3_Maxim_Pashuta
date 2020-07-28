using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_NUnitTest.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperRectangle.
    /// </summary>
    public class PaperRectangleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="resultSides">Result Sides</param>
        [TestCase(5, 2, 4)]
        public void Test_PaperRectangle(double radius, params double[] resultSides)
        {
            var paperCircle = new PaperCircle(radius, Color.Red);
            var result = new PaperRectangle(resultSides, paperCircle);
            var actualResult = new PaperRectangle(resultSides, Color.Red);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor throws Exception.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="radius">Radius</param>
        /// <param name="sides">Sides</param>
        [TestCase(typeof(ArgumentException), "You cannot create a shape because the original shape is smaller.", 5, 12, 14)]
        [TestCase(typeof(ArgumentException), "The count of sides is not equal to two or four.", 5, 12)]
        [TestCase(typeof(ArgumentException), "The count of sides is not equal to two or four.", 5, 12, 14, 15)]
        public void Test_PaperRectangle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides)
        {
            var paperCircle = new PaperCircle(radius, Color.Red);

            Assert.That(() => new PaperRectangle(sides, paperCircle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="actualResult">Result Area</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(48, 6, 8)]
        public void Test_GetArea(double actualResult, params double[] sides)
        {
            var paperRectangle = new PaperRectangle(sides, Color.Red);
            double result = paperRectangle.GetArea();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        /// <param name="actualResult">Result Perimeter</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(14, 6, 8)]
        public void Test_GetPerimeter(double actualResult, params double[] sides)
        {
            var paperRectangle = new PaperRectangle(sides, Color.Red);
            double result = paperRectangle.GetPerimeter();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests the method RecolorFigure.
        /// </summary>
        /// <param name="colorBlue">Color Blue</param>
        /// <param name="actualResult">Result Color Green</param>
        [TestCase(Color.Blue, Color.Green)]
        public void Test_RecolorFigure(Color colorBlue, Color actualResult)
        {
            var sidesPaperRectangle = new List<double> { 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, colorBlue);
            paperRectangle.RecolorFigure(actualResult);
            Color result = paperRectangle.Color;

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
            var sidesPaperRectangle = new List<double> { 6, 8 };

            var paperRectangle = new PaperRectangle(sidesPaperRectangle, colorBlue);
            paperRectangle.RecolorFigure(colorGreen);

            Assert.That(() => paperRectangle.RecolorFigure(colorRed), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }
    }
}

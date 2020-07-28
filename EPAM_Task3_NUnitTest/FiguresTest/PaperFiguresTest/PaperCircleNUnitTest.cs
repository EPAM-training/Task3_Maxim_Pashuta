using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using NUnit.Framework;
using System;

namespace EPAM_Task3_NUnitTest.FiguresTest.PaperFiguresTest
{
    /// <summary>
    /// Class for testing the class PaperCircle.
    /// </summary>
    public class PaperCircleNUnitTest
    {
        /// <summary>
        /// The method tests constructor.
        /// </summary>
        /// <param name="resultRadius">Result Radius</param>
        /// <param name="sides">Sides of Paper Rectangle</param>
        [TestCase(5, 12, 14)]
        public void Test_PaperCircle(double resultRadius, params double[] sides)
        {
            var paperRectangle = new PaperRectangle(sides, Color.Black);
            var result = new PaperCircle(resultRadius, paperRectangle);
            var actualResult = new PaperCircle(resultRadius, Color.Black);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests constructor throws Exception.
        /// </summary>
        /// <param name="typeException">Type Exception</param>
        /// <param name="exceptionMessage">Exception Message</param>
        /// <param name="radius">Radius</param>
        /// <param name="sides">Sides</param>
        [TestCase(typeof(ArgumentException), "You cannot create a shape because the original shape is smaller.", 5, 4, 6)]
        [TestCase(typeof(ArgumentException), "The argument less or equal a zero.", -5, 4, 6)]
        [TestCase(typeof(ArgumentException), "The argument less or equal a zero.", 0, 4, 6)]
        public void Test_PaperCircle_ThrowsArgumentException(Type typeException, string exceptionMessage, double radius, params double[] sides) 
        {
            var paperRectangle = new PaperRectangle(sides, Color.Black);

            Assert.That(() => new PaperCircle(radius, paperRectangle), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }

        /// <summary>
        /// The method tests method GetArea.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="actualResult">Result Area</param>
        [TestCase(5, 78.5398163)]
        public void Test_GetArea(double radius, double actualResult)
        {
            var paperCircle = new PaperCircle(radius, Color.Blue);
            double result = paperCircle.GetArea();

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetPerimeter.
        /// </summary>
        /// <param name="radius">Radius</param>
        /// <param name="actualResult">Result Perimeter</param>
        [TestCase(5, 31.4159265)]
        public void Test_GetPerimeter(double radius, double actualResult)
        {
            var paperCircle = new PaperCircle(radius, Color.Blue);
            double result = paperCircle.GetPerimeter();

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
            var radiusPaperCircle = 5;

            var circle = new PaperCircle(radiusPaperCircle, colorBlue);
            circle.RecolorFigure(actualResult);
            Color result = circle.Color;

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
            var radius = 5;

            var circle = new PaperCircle(radius, Color.Blue);
            circle.RecolorFigure(Color.Green);

            Assert.That(() => circle.RecolorFigure(Color.Red), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }
    }
}

using EPAM_Task3;
using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task3_NUnitTest
{
    /// <summary>
    /// Class for testing the class Box.
    /// </summary>
    public class BoxNUnitTest
    {
        private Box _box;

        /// <summary>
        /// Initializes Box test object.
        /// </summary>
        [SetUp]
        protected void Setup()
        {
            var sidesPaperRectangle = new List<double> { 2, 4 };
            var sidesPaperTriangle = new List<double> { 2, 4, 5 };
            var radiusPaperCircle = 4;
            var radiusSkinCircle = 3;
            var sidesSkinRectangle = new List<double> { 3, 6 };

            var figures = new IFigure[]
            {
                new PaperRectangle(sidesPaperRectangle, Color.Black),
                new PaperTriangle(sidesPaperTriangle, Color.Blue),
                new PaperCircle(radiusPaperCircle, Color.Red),
                new SkinCircle(radiusSkinCircle),
                new SkinRectangle(sidesSkinRectangle)
            };

            _box = new Box(figures);
        }

        /// <summary>
        /// The method tests method AddFigure.
        /// </summary>
        /// <param name="radius">Radius</param>
        [TestCase(7)]
        public void Test_AddFigure(double radius)
        {
            var figure = new SkinCircle(radius);

            _box.AddFigure(figure);

            IFigure result = _box.Figures[5];
            IFigure actualResult = figure;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method AddFigure throws ArgumentException.
        /// </summary>
        /// <param name="sides">Sides of Paper Triangle</param>
        [TestCase(2, 4, 5)]
        public void Test_AddFigure_ThrowsArgumentException(params double[] sides)
        {
            var figure = new PaperTriangle(sides, Color.Blue);

            Assert.That(() => _box.AddFigure(figure), Throws.ArgumentException);
        }

        /// <summary>
        /// The method tests method ShowFigure.
        /// </summary>
        /// <param name="index">Index</param>
        [TestCase(1)]
        [TestCase(10)]
        public void Test_ShowFigure(int index)
        {
            IFigure result = _box.ShowFigure(index);
            IFigure actualResult = _box.Figures[index];

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ShowFigure throws IndexOutOfRangeException.
        /// </summary>
        /// <param name="index">Index</param>
        [TestCase(25)]
        [TestCase(-3)]
        public void Test_ShowFigure_ThrowsIndexOutOfRangeException(int index)
        {
            Assert.That(() => _box.ShowFigure(index), Throws.TypeOf<IndexOutOfRangeException>());
        }

        /// <summary>
        /// The method tests method GetFigure.
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="resultCount">Count Figures</param>
        [TestCase(1, 4)]
        [TestCase(11, 5)]
        public void Test_GetFigure(int index, int resultCount)
        {
            _box.GetFigure(index);

            int result = _box.GetCountFigures();
            var actualResult = resultCount;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetFigure throws IndexOutOfRangeException.
        /// </summary>
        /// <param name="index">Index</param>
        [TestCase(25)]
        [TestCase(-6)]
        public void Test_GetFigure_ThrowsIndexOutOfRangeException(int index)
        {
            Assert.That(() => _box.GetFigure(index), Throws.TypeOf<IndexOutOfRangeException>());
        }

        /// <summary>
        /// The method tests method SetFigure.
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="radius">Radius</param>
        [TestCase(0, 15)]
        [TestCase(5, 10)]
        public void Test_SetFigure(int index, double radius)
        {
            var figure = new SkinCircle(radius);
            _box.SetFigure(index, figure);

            IFigure result = _box.Figures[index];
            IFigure actualResult = figure;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method SetFigure throws IndexOutOfRangeException.
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="radius">Radius</param>
        [TestCase(23, 6)]
        [TestCase(-1, 10)]
        public void Test_SetFigure_ThrowsIndexOutOfRangeException(int index, double radius)
        {
            var figure = new SkinCircle(radius);
            Assert.That(() => _box.SetFigure(index, figure), Throws.TypeOf<IndexOutOfRangeException>());
        }

        /// <summary>
        /// The method tests method SearchFigure.
        /// </summary>
        /// <param name="color">Figure Color</param>
        /// <param name="sidesTriangle">Sides of Triangle</param>
        [TestCase(Color.Blue, 2, 4, 5)]
        public void Test_SearchFigure(Color color, params double[] sidesTriangle)
        {
            var figure = new PaperTriangle(sidesTriangle, color);

            IFigure result = _box.SearchFigure(figure);
            IFigure actualResult = figure;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetCountFigures.
        /// </summary>
        /// <param name="resultCountFigures">Result count figures</param>
        [TestCase(5)]
        public void Test_GetCountFigures(int resultCountFigures)
        {
            int result = _box.GetCountFigures();
            var actualResult = resultCountFigures;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetTotalPerimeter.
        /// </summary>
        /// <param name="totalPerimeter">Total Perimeter</param>
        [TestCase(69.982297)]
        public void Test_GetTotalPerimeter(double totalPerimeter)
        {
            double result = _box.GetTotalPerimeter();
            double actualResult = totalPerimeter;

            Assert.AreEqual(result, actualResult, 0.000001);
        }

        /// <summary>
        /// The method tests method GetTotalArea.
        /// </summary>
        /// <param name="totalArea">Total Area</param>
        [TestCase(108.33948)]
        public void Test_GetTotalArea(double totalArea)
        {
            double result = _box.GetTotalArea();
            double actualResult = totalArea;

            Assert.AreEqual(result, actualResult, 0.00001);
        }

        /// <summary>
        /// The method tests method GetCircles.
        /// </summary>
        [TestCase(4, 3)]
        public void Test_GetCircles(double radiusPaperCircle, double radiusSkinCircle)
        {
            var result = _box.GetCircles();
            var actualResult = new List<Circle>()
            {
                new PaperCircle(radiusPaperCircle, Color.Red),
                new SkinCircle(radiusSkinCircle)
            };

            CollectionAssert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetSkinFigures.
        /// </summary>
        [TestCase(3, 3, 6)]
        public void Test_GetSkinFigures(double radiusSkinCircle, params double[] sidesSkinRectangle)
        {
            List<ISkinFigure> result = _box.GetSkinFigures();
            var actualResult = new List<ISkinFigure>()
            {
                new SkinCircle(radiusSkinCircle),
                new SkinRectangle(sidesSkinRectangle)
            };

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}

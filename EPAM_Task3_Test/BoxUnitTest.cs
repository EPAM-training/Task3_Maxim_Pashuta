using EPAM_Task3;
using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAM_Task3_Test
{
    /// <summary>
    /// Class for testing the class Box.
    /// </summary>
    [TestClass]
    public class BoxUnitTest
    {
        /// <summary>
        /// The method tests method AddFigure when figure is in box.
        /// </summary>
        [TestMethod]
        public void AddFigure_WhenFigureIsInBox_AddNewFigure()
        {

            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new SkinCircle(7);

            box.AddFigure(figure);

            IFigure[] result = box.Figures;
            var actualResult = new IFigure[20];

            for (var i = 0; i < actualResult.Length; i++)
            {
                if (i == figures.Count)
                {
                    actualResult[i] = figure;
                    break;
                }

                actualResult[i] = figures[i];
            }

            CollectionAssert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method AddFigure when figure is not in box.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddFigure_WhenFigureIsNotInBox_GetArgumentException()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue);

            box.AddFigure(figure);
        }

        /// <summary>
        /// The method tests method ShowFigure when index is not outside array.
        /// </summary>
        [TestMethod]
        public void ShowFigure_WhenIndexIsNotOutsideArray_GetFigure()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            IFigure result = box.ShowFigure(1);
            var actualResult = new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ShowFigure when index is outside array.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShowFigure_WhenIndexIsOutsideArray_GetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            box.ShowFigure(21);
        }

        /// <summary>
        /// The method tests method GetFigure when index is not outside array.
        /// </summary>
        [TestMethod]
        public void GetFigure_WhenIndexIsNotOutsideArray_GetFigureAndDeleteThisFigure()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            box.GetFigure(0);

            int result = box.GetCountFigures();
            int actualResult = 1;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetFigure when index is outside array.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetFigure_WhenIndexIsOutsideArray_GetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue),
            };

            var box = new Box(figures);

            box.GetFigure(21);
        }

        /// <summary>
        /// The method tests method SetFigure when index is not outside array.
        /// </summary>
        [TestMethod]
        public void SetFigure_WhenIndexIsNotOutsideArray_ChangeChosenFigure()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new SkinCircle(7);
            box.SetFigure(0, figure);

            IFigure result = box.ShowFigure(0);
            var actualResult = new SkinCircle(7);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method SetFigure when index is outside array.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetFigure_WhenIndexIsOutsideArray_GetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue),
            };

            var box = new Box(figures);
            var figure = new SkinCircle(7);
            box.SetFigure(-10, figure);
        }

        /// <summary>
        /// The method tests method SearchFigure when figure is in box.
        /// </summary>
        [TestMethod]
        public void SearchFigure_WhenFigureIsInBox_GetFigure()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue);

            IFigure result = box.SearchFigure(figure);
            var actualResult = new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method SearchFigure when figure is not in box.
        /// </summary>
        [TestMethod]
        public void SearchFigure_WhenFigureIsNotInBox_GetNull()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new SkinCircle(7);

            IFigure result = box.SearchFigure(figure);
            IFigure actualResult = null;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetCountFigures.
        /// </summary>
        [TestMethod]
        public void Test_GetCountFigures()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            int result = box.GetCountFigures();
            int actualResult = 2;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetTotalPerimeter.
        /// </summary>
        [TestMethod]
        public void Test_GetTotalPerimeter()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            double result = box.GetTotalPerimeter();
            double actualResult = 19;

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetTotalArea.
        /// </summary>
        [TestMethod]
        public void Test_GetTotalArea()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue)
            };

            var box = new Box(figures);

            double result = box.GetTotalArea();
            double actualResult = 11.799671;

            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        /// <summary>
        /// The method tests method GetCircles.
        /// </summary>
        [TestMethod]
        public void Test_GetCircles()
        {
            var figures = new IFigure[]
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue),
                new PaperCircle(4, Color.Red),
                new SkinCircle(3),
                new SkinRectangle(new List<double> { 3, 6 })
            };

            var box = new Box(figures);

            var result = box.GetCircles();
            var actualResult = new List<Circle>()
            {
                new PaperCircle(4, Color.Red),
                new SkinCircle(3)
            };

            CollectionAssert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method GetSkinFigures.
        /// </summary>
        [TestMethod]
        public void Test_GetSkinFigures()
        {
            var figures = new IFigure[]
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 7 }, Color.Blue),
                new PaperCircle(4, Color.Red),
                new SkinCircle(3),
                new SkinRectangle(new List<double> { 3, 6 })
            };

            var box = new Box(figures);

            var result = box.GetSkinFigures();
            var actualResult = new List<ISkinFigure>()
            {
                new SkinCircle(3),
                new SkinRectangle(new List<double> { 3, 6 })
            };

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}

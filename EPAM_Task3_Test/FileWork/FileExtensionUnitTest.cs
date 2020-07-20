using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using EPAM_Task3.FileWork;
using EPAM_Task3.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task3_Test.FileWork
{
    /// <summary>
    /// Class for testing the class FileExtension.
    /// </summary>
    [TestClass]
    public class FileExtensionUnitTest
    {
        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is skin.
        /// </summary>
        [TestMethod]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsSkin_WriteSkinFigures()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(figures, filePath, typeof(ISkinFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "  <SkinCircle>\r\n" +
                               "    <Radius>7</Radius>\r\n" +
                               "  </SkinCircle>\r\n" +
                               "  <SkinRectangle>\r\n" +
                               "    <Sides>3 7</Sides>\r\n" +
                               "  </SkinRectangle>\r\n" +
                               "</Figures>";
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is paper.
        /// </summary>
        [TestMethod]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsPaper_WritePaperFigures()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(figures, filePath, typeof(IPaperFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "  <PaperRectangle>\r\n" +
                               "    <Sides>2 4</Sides>\r\n" +
                               "    <Color>Black</Color>\r\n" +
                               "  </PaperRectangle>\r\n" +
                               "  <PaperTriangle>\r\n" +
                               "    <Sides>2 4 5</Sides>\r\n" +
                               "    <Color>Blue</Color>\r\n" +
                               "  </PaperTriangle>\r\n" +
                               "</Figures>";
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is figure.
        /// </summary>
        [TestMethod]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsFigure_WriteAllFigures()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(figures, filePath, typeof(IFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "  <PaperRectangle>\r\n" +
                               "    <Sides>2 4</Sides>\r\n" +
                               "    <Color>Black</Color>\r\n" +
                               "  </PaperRectangle>\r\n" +
                               "  <PaperTriangle>\r\n" +
                               "    <Sides>2 4 5</Sides>\r\n" +
                               "    <Color>Blue</Color>\r\n" +
                               "  </PaperTriangle>\r\n" +
                               "  <SkinCircle>\r\n" +
                               "    <Radius>7</Radius>\r\n" +
                               "  </SkinCircle>\r\n" +
                               "  <SkinRectangle>\r\n" +
                               "    <Sides>3 7</Sides>\r\n" +
                               "  </SkinRectangle>\r\n" +
                               "</Figures>";
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ReadFiguresXmlReader.
        /// </summary>
        [TestMethod]
        public void Test_ReadFiguresXmlReader()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\Figures.xml";
            List<IFigure> result = FileExtension.ReadFiguresXmlReader(filePath);
            List<IFigure> actualResult = figures;

            CollectionAssert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresStreamWriter when material is figure.
        /// </summary>
        [TestMethod]
        public void WriteFiguresStreamWriter_WhenTypeMaterialIsFigure_WriteAllFigures()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresStreamWriter(figures, filePath, typeof(IFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "\t<PaperRectangle>\r\n" +
                               "\t\t<Sides>2 4</Sides>\r\n" +
                               "\t\t<Color>Black</Color>\r\n" +
                               "\t</PaperRectangle>\r\n" +
                               "\t<PaperTriangle>\r\n" +
                               "\t\t<Sides>2 4 5</Sides>\r\n" +
                               "\t\t<Color>Blue</Color>\r\n" +
                               "\t</PaperTriangle>\r\n" +
                               "\t<SkinCircle>\r\n" +
                               "\t\t<Radius>7</Radius>\r\n" +
                               "\t</SkinCircle>\r\n" +
                               "\t<SkinRectangle>\r\n" +
                               "\t\t<Sides>3 7</Sides>\r\n" +
                               "\t</SkinRectangle>\r\n" +
                               "</Figures>\r\n";
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ReadFiguresStreamReader.
        /// </summary>
        [TestMethod]
        public void Test_ReadFiguresStreamReader()
        {
            var figures = new List<IFigure>
            {
                new PaperRectangle(new List<double> { 2, 4 }, Color.Black),
                new PaperTriangle(new List<double> { 2, 4, 5 }, Color.Blue),
                new SkinCircle(7),
                new SkinRectangle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\Resources\Figures.xml";
            List<IFigure> result = FileExtension.ReadFiguresStreamReader(filePath);
            List<IFigure> actualResult = figures;

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}

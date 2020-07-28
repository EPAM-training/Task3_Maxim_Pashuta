using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using EPAM_Task3.FileWork;
using EPAM_Task3.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EPAM_Task3_NUnitTest.FileWorkTest
{
    /// <summary>
    /// Class for testing the class FileExtension.
    /// </summary>
    public class FileExtensionNUnitTest
    {
        private List<IFigure> _figures;
        private string _xmlFileContentWithPaperFigures;
        private string _xmlFileContentWithSkinFigures;
        private string _xmlFileContentWithAllFigures;
        private string _streamFileContentWithAllFigures;

        /// <summary>
		/// Initializes FileExtensionNUnitTest test objects.
		/// </summary>
		[SetUp]
        protected void SetUp()
        {
            var sidesPaperRectangle = new List<double> { 2, 4 };
            var sidesPaperTriangle = new List<double> { 2, 4, 5 };
            var radiusSkinCircle = 7;
            var sidesSkinRectangle = new List<double> { 3, 7 };

            _figures = new List<IFigure>
            {
                new PaperRectangle(sidesPaperRectangle, Color.Black),
                new PaperTriangle(sidesPaperTriangle, Color.Blue),
                new SkinCircle(radiusSkinCircle),
                new SkinRectangle(sidesSkinRectangle)
            };

            _xmlFileContentWithSkinFigures = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                                          "<Figures>\r\n" +
                                          "  <SkinCircle>\r\n" +
                                          "    <Radius>7</Radius>\r\n" +
                                          "  </SkinCircle>\r\n" +
                                          "  <SkinRectangle>\r\n" +
                                          "    <Sides>3 7</Sides>\r\n" +
                                          "  </SkinRectangle>\r\n" +
                                          "</Figures>";

            _xmlFileContentWithPaperFigures = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
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

            _xmlFileContentWithAllFigures = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
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

            _streamFileContentWithAllFigures = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
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

        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is skin.
        /// </summary>
        [Test]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsSkin_WriteSkinFigures()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(_figures, filePath, typeof(ISkinFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = _xmlFileContentWithSkinFigures;
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is paper.
        /// </summary>
        [Test]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsPaper_WritePaperFigures()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(_figures, filePath, typeof(IPaperFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = _xmlFileContentWithPaperFigures;
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresXmlWriter when type material is figure.
        /// </summary>
        [Test]
        public void WriteFiguresXmlWriter_WhenTypeMaterialIsFigure_WriteAllFigures()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresXmlWriter(_figures, filePath, typeof(IFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = _xmlFileContentWithAllFigures;
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ReadFiguresXmlReader.
        /// </summary>
        [Test]
        public void Test_ReadFiguresXmlReader()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\Figures.xml";
            List<IFigure> result = FileExtension.ReadFiguresXmlReader(filePath);
            List<IFigure> actualResult = _figures;

            CollectionAssert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method WriteFiguresStreamWriter when material is figure.
        /// </summary>
        [Test]
        public void WriteFiguresStreamWriter_WhenTypeMaterialIsFigure_WriteAllFigures()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\NewFigures.xml";
            FileExtension.WriteFiguresStreamWriter(_figures, filePath, typeof(IFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = _streamFileContentWithAllFigures;
            }

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests method ReadFiguresStreamReader.
        /// </summary>
        [Test]
        public void Test_ReadFiguresStreamReader()
        {
            var filePath = @"..\..\..\..\EPAM_Task3\Resources\Figures.xml";
            List<IFigure> result = FileExtension.ReadFiguresStreamReader(filePath);
            List<IFigure> actualResult = _figures;

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}

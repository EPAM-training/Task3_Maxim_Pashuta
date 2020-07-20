using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using EPAM_Task3.Interfaces;
using EPAM_Task3.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace EPAM_Task3.FileWork
{
    /// <summary>
    /// Class for wirking with file.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// The method reads data from a file using XmlReader and returns a list of figures.
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Figure list</returns>
        public static List<IFigure> ReadFiguresXmlReader(string filePath)
        {
            using (var xmlReader = new XmlTextReader(filePath))
            {
                var figures = new List<IFigure>();

                while (xmlReader.Read())
                {
                    if (!Enum.TryParse(typeof(TypeFigure), xmlReader.Name, out object typeFigure))
                    {
                        continue;
                    }

                    switch (typeFigure)
                    {
                        case TypeFigure.PaperCircle:
                            PaperCircle paperCircle = ParserFigureUsingXML.ParseToPaperCircleFromXmlElement(xmlReader);
                            figures.Add(paperCircle);
                            break;
                        case TypeFigure.PaperRectangle:
                            PaperRectangle paperRectangle = ParserFigureUsingXML.ParseToPaperRectangleFromXmlElement(xmlReader);
                            figures.Add(paperRectangle);
                            break;
                        case TypeFigure.PaperTriangle:
                            PaperTriangle paperTriangle = ParserFigureUsingXML.ParseToPaperTriangleFromXmlElement(xmlReader);
                            figures.Add(paperTriangle);
                            break;
                        case TypeFigure.SkinCircle:
                            SkinCircle skinCircle = ParserFigureUsingXML.ParseToSkinCircleFromXmlElement(xmlReader);
                            figures.Add(skinCircle);
                            break;
                        case TypeFigure.SkinRectangle:
                            SkinRectangle skinRectangle = ParserFigureUsingXML.ParseToSkinRectangleFromXmlElement(xmlReader);
                            figures.Add(skinRectangle);
                            break;
                        case TypeFigure.SkinTriangle:
                            SkinTriangle skinTriangle = ParserFigureUsingXML.ParseToSkinTriangleFromXmlElement(xmlReader);
                            figures.Add(skinTriangle);
                            break;
                    }

                    xmlReader.Read();
                }

                return figures;
            }
        }

        /// <summary>
        /// The method writes data to the file using XmlWriter.
        /// </summary>
        /// <param name="figuresCollection">Figures collection</param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeMaterialFigure">Type material</param>
        public static void WriteFiguresXmlWriter(IEnumerable<IFigure> figuresCollection, string filePath, Type typeMaterialFigure)
        {
            using (var xmlWriter = new XmlTextWriter(filePath, System.Text.Encoding.UTF8))
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Figures");

                foreach (IFigure figure in figuresCollection)
                {
                    Type materialFigure = figure.GetType().GetInterface(typeMaterialFigure.Name);

                    if (materialFigure != typeMaterialFigure)
                    {
                        continue;
                    }

                    var typeFigure = Enum.Parse(typeof(TypeFigure), figure.GetType().Name);

                    switch (typeFigure)
                    {
                        case TypeFigure.PaperCircle:
                            var paperCircle = (PaperCircle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromPaperCircle(xmlWriter, paperCircle);
                            break;
                        case TypeFigure.PaperRectangle:
                            var paperRectangle = (PaperRectangle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromPaperRectangle(xmlWriter, paperRectangle);
                            break;
                        case TypeFigure.PaperTriangle:
                            var paperTriangle = (PaperTriangle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromPaperTriangle(xmlWriter, paperTriangle);
                            break;
                        case TypeFigure.SkinCircle:
                            var skinCircle = (SkinCircle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromSkinCircle(xmlWriter, skinCircle);
                            break;
                        case TypeFigure.SkinRectangle:
                            var skinRectangle = (SkinRectangle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromSkinRectangle(xmlWriter, skinRectangle);
                            break;
                        case TypeFigure.SkinTriangle:
                            var skinTriangle = (SkinTriangle)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromSkinTriangle(xmlWriter, skinTriangle);
                            break;
                    }
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
            }
        }

        /// <summary>
        /// The method reads data from a file using StreamReader and returns a list of figures.
        /// </summary>
        /// <returns>Figure list</returns>
        public static List<IFigure> ReadFiguresStreamReader(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                var figures = new List<IFigure>();
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string elementContent = line.Trim('<', '>', '/', '\t', ' ');

                    if (!Enum.TryParse(typeof(TypeFigure), elementContent, out object typeFigure))
                    {
                        continue;
                    }

                    switch (typeFigure)
                    {
                        case TypeFigure.PaperCircle:
                            PaperCircle paperCircle = ParserFiguresUsingStream.ParseToPaperCircleFromXmlElement(streamReader);
                            figures.Add(paperCircle);
                            break;
                        case TypeFigure.PaperRectangle:
                            PaperRectangle paperRectangle = ParserFiguresUsingStream.ParseToPaperRectangleFromXmlElement(streamReader);
                            figures.Add(paperRectangle);
                            break;
                        case TypeFigure.PaperTriangle:
                            PaperTriangle paperTriangle = ParserFiguresUsingStream.ParseToPaperTriangleFromXmlElement(streamReader);
                            figures.Add(paperTriangle);
                            break;
                        case TypeFigure.SkinCircle:
                            SkinCircle skinCircle = ParserFiguresUsingStream.ParseToSkinCircleFromXmlElement(streamReader);
                            figures.Add(skinCircle);
                            break;
                        case TypeFigure.SkinRectangle:
                            SkinRectangle skinRectangle = ParserFiguresUsingStream.ParseToSkinRectangleFromXmlElement(streamReader);
                            figures.Add(skinRectangle);
                            break;
                        case TypeFigure.SkinTriangle:
                            SkinTriangle skinTriangle = ParserFiguresUsingStream.ParseToSkinTriangleFromXmlElement(streamReader);
                            figures.Add(skinTriangle);
                            break;
                    }

                    streamReader.ReadLine();
                }

                return figures;
            }
        }

        /// <summary>
        /// The method writes data to the file using StreamWriter.
        /// </summary>
        /// <param name="figuresCollection">Figures collection</param>
        /// <param name="filePath">Path to the file</param>
        /// <param name="typeMaterialFigure">Type material</param>
        public static void WriteFiguresStreamWriter(IEnumerable<IFigure> figuresCollection, string filePath, Type typeMaterialFigure)
        {
            using (var streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                streamWriter.WriteLine("<Figures>");

                foreach (IFigure figure in figuresCollection)
                {
                    Type materialFigure = figure.GetType().GetInterface(typeMaterialFigure.Name);

                    if (materialFigure != typeMaterialFigure)
                    {
                        continue;
                    }

                    var typeFigure = Enum.Parse(typeof(TypeFigure), figure.GetType().Name);

                    switch (typeFigure)
                    {
                        case TypeFigure.PaperCircle:
                            var paperCircle = (PaperCircle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromPaperCircle(streamWriter, paperCircle);
                            break;
                        case TypeFigure.PaperRectangle:
                            var paperRectangle = (PaperRectangle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromPaperRectangle(streamWriter, paperRectangle);
                            break;
                        case TypeFigure.PaperTriangle:
                            var paperTriangle = (PaperTriangle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromPaperTriangle(streamWriter, paperTriangle);
                            break;
                        case TypeFigure.SkinCircle:
                            var skinCircle = (SkinCircle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromSkinCircle(streamWriter, skinCircle);
                            break;
                        case TypeFigure.SkinRectangle:
                            var skinRectangle = (SkinRectangle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromSkinRectangle(streamWriter, skinRectangle);
                            break;
                        case TypeFigure.SkinTriangle:
                            var skinTriangle = (SkinTriangle)figure;
                            ParserXmlElementUsingStream.ParseToXmlElementFromSkinTriangle(streamWriter, skinTriangle);
                            break;
                    }
                }

                streamWriter.WriteLine("</Figures>");
            }
        }
    }
}

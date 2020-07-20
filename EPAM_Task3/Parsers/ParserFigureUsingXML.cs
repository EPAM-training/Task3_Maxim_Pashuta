using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace EPAM_Task3.Parsers
{
    /// <summary>
    /// Class for parsing figures using XmlReader.
    /// </summary>
    public static class ParserFigureUsingXML
    {
        /// <summary>
        /// The method parses the xml element into a paper circle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper circle</returns>
        public static PaperCircle ParseToPaperCircleFromXmlElement(XmlTextReader xmlReader)
        {
            double radius = 0;
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperCircle.Radius)))
                {
                    radius = double.Parse(xmlReader.ReadElementString());
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperCircle.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new PaperCircle(radius, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a paper rectangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper rectangle</returns>
        public static PaperRectangle ParseToPaperRectangleFromXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperRectangle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperRectangle.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new PaperRectangle(sides, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a paper triangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper triangle</returns>
        public static PaperTriangle ParseToPaperTriangleFromXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperTriangle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(PaperTriangle.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new PaperTriangle(sides, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a skin circle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Skin circle</returns>
        public static SkinCircle ParseToSkinCircleFromXmlElement(XmlTextReader xmlReader)
        {
            double radius = 0;
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(SkinCircle.Radius)))
                {
                    radius = double.Parse(xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new SkinCircle(radius));
        }

        /// <summary>
        /// The method parses the xml element into a skin rectangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Skin rectangle</returns>
        public static SkinRectangle ParseToSkinRectangleFromXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(SkinRectangle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }
            }

            return (new SkinRectangle(sides));
        }

        /// <summary>
        /// The method parses the xml element into a skin triangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Skin triangle</returns>
        public static SkinTriangle ParseToSkinTriangleFromXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(SkinTriangle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }
            }

            return (new SkinTriangle(sides));
        }
    }
}

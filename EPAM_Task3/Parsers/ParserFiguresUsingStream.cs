using EPAM_Task3.Enums;
using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EPAM_Task3.Parsers
{
    /// <summary>
    /// Class for parsing figures using StreamReader.
    /// </summary>
    public static class ParserFiguresUsingStream
    {
        /// <summary>
        /// The method parses the xml element into a paper circle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper circle</returns>
        public static PaperCircle ParseToPaperCircleFromXmlElement(StreamReader streamReader)
        {
            double radius = 0;
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(PaperCircle.Radius)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperCircle.Radius));
                    radius = double.Parse(xmlElementContent);
                    count++;
                }

                if (line.Contains(nameof(PaperCircle.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperCircle.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new PaperCircle(radius, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a paper rectangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper rectangle</returns>
        public static PaperRectangle ParseToPaperRectangleFromXmlElement(StreamReader streamReader)
        {
            var sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(PaperRectangle.Sides)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperRectangle.Sides));
                    sides = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if (line.Contains(nameof(PaperRectangle.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperRectangle.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new PaperRectangle(sides, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a paper triangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper triangle</returns>
        public static PaperTriangle ParseToPaperTriangleFromXmlElement(StreamReader streamReader)
        {
            var sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(PaperTriangle.Sides)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperTriangle.Sides));
                    sides = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if (line.Contains(nameof(PaperTriangle.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(PaperTriangle.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new PaperTriangle(sides, (Color)color));
        }

        /// <summary>
        /// The method parses the xml element into a skin circle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Skin circle</returns>
        public static SkinCircle ParseToSkinCircleFromXmlElement(StreamReader streamReader)
        {
            double radius = 0;

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(SkinCircle.Radius)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(SkinCircle.Radius));
                radius = double.Parse(xmlElementContent);
            }

            return (new SkinCircle(radius));
        }

        /// <summary>
        /// The method parses the xml element into a skin rectangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Skin rectangle</returns>
        public static SkinRectangle ParseToSkinRectangleFromXmlElement(StreamReader streamReader)
        {
            var sides = new List<double>();

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(SkinRectangle.Sides)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(SkinRectangle.Sides));
                sides = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
            }

            return (new SkinRectangle(sides));
        }

        /// <summary>
        /// The method parses the xml element into a skin triangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Skin triangle</returns>
        public static SkinTriangle ParseToSkinTriangleFromXmlElement(StreamReader streamReader)
        {
            var sides = new List<double>();

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(SkinTriangle.Sides)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(SkinTriangle.Sides));
                sides = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
            }

            return (new SkinTriangle(sides));
        }

        /// <summary>
        /// The method returning xml element content.
        /// </summary>
        /// <param name="line">Xml string element</param>
        /// <param name="tagContent">Tag content</param>
        /// <returns>Xml element content</returns>
        private static string GetXmlElementContent(string line, string tagContent)
        {
            int startIndex = 0;
            int newCount = tagContent.Length + 2;
            string xmlElementContent = line.Remove(startIndex, newCount);
            startIndex = xmlElementContent.Length - tagContent.Length - 3;
            newCount = tagContent.Length + 3;
            xmlElementContent = xmlElementContent.Remove(startIndex, newCount);
            return xmlElementContent;
        }
    }
}

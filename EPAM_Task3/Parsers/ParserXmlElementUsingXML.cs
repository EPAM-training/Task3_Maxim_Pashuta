using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using System.Xml;

namespace EPAM_Task3.Parsers
{
    /// <summary>
    /// Class for parsing xml element using XmlWriter.
    /// </summary>
    public static class ParserXmlElementUsingXML
    {
        /// <summary>
        /// The method parses the paper circle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperCircle">Paper circle</param>
        public static void ParseToXmlElementFromPaperCircle(XmlTextWriter xmlWriter, PaperCircle paperCircle)
        {
            xmlWriter.WriteStartElement(nameof(PaperCircle));
            xmlWriter.WriteElementString(nameof(PaperCircle.Radius), paperCircle.Radius.ToString());
            xmlWriter.WriteElementString(nameof(PaperCircle.Color), paperCircle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// The method parses the paper rectangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperRectangle">Paper rectangle</param>
        public static void ParseToXmlElementFromPaperRectangle(XmlTextWriter xmlWriter, PaperRectangle paperRectangle)
        {
            xmlWriter.WriteStartElement(nameof(PaperRectangle));
            xmlWriter.WriteElementString(nameof(PaperRectangle.Sides), string.Join(' ', paperRectangle.Sides));
            xmlWriter.WriteElementString(nameof(PaperRectangle.Color), paperRectangle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// The method parses the paper triangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperTriangle">Paper triangle</param>
        public static void ParseToXmlElementFromPaperTriangle(XmlTextWriter xmlWriter, PaperTriangle paperTriangle)
        {
            xmlWriter.WriteStartElement(nameof(PaperTriangle));
            xmlWriter.WriteElementString(nameof(PaperTriangle.Sides), string.Join(' ', paperTriangle.Sides));
            xmlWriter.WriteElementString(nameof(PaperTriangle.Color), paperTriangle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// The method parses the skin circle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinCircle">Skin circle</param>
        public static void ParseToXmlElementFromSkinCircle(XmlTextWriter xmlWriter, SkinCircle skinCircle)
        {
            xmlWriter.WriteStartElement(nameof(SkinCircle));
            xmlWriter.WriteElementString(nameof(SkinCircle.Radius), skinCircle.Radius.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// The method parses the skin rectangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinRectangle">Skin rectangle</param>
        public static void ParseToXmlElementFromSkinRectangle(XmlTextWriter xmlWriter, SkinRectangle skinRectangle)
        {
            xmlWriter.WriteStartElement(nameof(SkinRectangle));
            xmlWriter.WriteElementString(nameof(SkinRectangle.Sides), string.Join(' ', skinRectangle.Sides));
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// The method parses the skin triangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinTriangle">Skin triangle</param>
        public static void ParseToXmlElementFromSkinTriangle(XmlTextWriter xmlWriter, SkinTriangle skinTriangle)
        {
            xmlWriter.WriteStartElement(nameof(SkinTriangle));
            xmlWriter.WriteElementString(nameof(SkinTriangle.Sides), string.Join(' ', skinTriangle.Sides));
            xmlWriter.WriteEndElement();
        }
    }
}

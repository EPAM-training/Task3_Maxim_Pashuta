using EPAM_Task3.Figures.PaperFigures;
using EPAM_Task3.Figures.SkinFigures;
using System.IO;

namespace EPAM_Task3.Parsers
{
    /// <summary>
    /// Class for parsing xml element using StreamWriter.
    /// </summary>
    public static class ParserXmlElementUsingStream
    {
        /// <summary>
        /// The method parses the paper circle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperCircle">Paper circle</param>
        public static void ParseToXmlElementFromPaperCircle(StreamWriter streamWriter, PaperCircle paperCircle)
        {
            streamWriter.WriteLine($"\t<{nameof(PaperCircle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperCircle.Radius)}>{paperCircle.Radius}</{nameof(PaperCircle.Radius)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperCircle.Color)}>{paperCircle.Color}</{nameof(PaperCircle.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(PaperCircle)}>");
        }

        /// <summary>
        /// The method parses the paper rectangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperRectangle">Paper rectangle</param>
        public static void ParseToXmlElementFromPaperRectangle(StreamWriter streamWriter, PaperRectangle paperRectangle)
        {
            streamWriter.WriteLine($"\t<{nameof(PaperRectangle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperRectangle.Sides)}>{string.Join(' ', paperRectangle.Sides)}</{nameof(PaperRectangle.Sides)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperRectangle.Color)}>{paperRectangle.Color}</{nameof(PaperRectangle.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(PaperRectangle)}>");
        }

        /// <summary>
        /// The method parses the paper triangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperTriangle">Paper triangle</param>
        public static void ParseToXmlElementFromPaperTriangle(StreamWriter streamWriter, PaperTriangle paperTriangle)
        {
            streamWriter.WriteLine($"\t<{nameof(PaperTriangle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperTriangle.Sides)}>{string.Join(' ', paperTriangle.Sides)}</{nameof(PaperTriangle.Sides)}>");
            streamWriter.WriteLine($"\t\t<{nameof(PaperTriangle.Color)}>{paperTriangle.Color}</{nameof(PaperTriangle.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(PaperTriangle)}>");
        }

        /// <summary>
        /// The method parses the skin circle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinCircle">Skin circle</param>
        public static void ParseToXmlElementFromSkinCircle(StreamWriter streamWriter, SkinCircle skinCircle)
        {
            streamWriter.WriteLine($"\t<{nameof(SkinCircle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(SkinCircle.Radius)}>{skinCircle.Radius}</{nameof(SkinCircle.Radius)}>");
            streamWriter.WriteLine($"\t</{nameof(SkinCircle)}>");
        }

        /// <summary>
        /// The method parses the skin rectangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinRectangle">Skin rectangle</param>
        public static void ParseToXmlElementFromSkinRectangle(StreamWriter streamWriter, SkinRectangle skinRectangle)
        {
            streamWriter.WriteLine($"\t<{nameof(SkinRectangle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(SkinRectangle.Sides)}>{string.Join(' ', skinRectangle.Sides)}</{nameof(SkinRectangle.Sides)}>");
            streamWriter.WriteLine($"\t</{nameof(SkinRectangle)}>");
        }

        /// <summary>
        /// The method parses the skin triangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinTriangle">Skin triangle</param>
        public static void ParseToXmlElementFromSkinTriangle(StreamWriter streamWriter, SkinTriangle skinTriangle)
        {
            streamWriter.WriteLine($"\t<{nameof(SkinTriangle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(SkinTriangle.Sides)}>{string.Join(' ', skinTriangle.Sides)}</{nameof(SkinTriangle.Sides)}>");
            streamWriter.WriteLine($"\t</{nameof(SkinTriangle)}>");
        }
    }
}

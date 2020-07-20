using EPAM_Task3.Enums;

namespace EPAM_Task3.Interfaces
{
    /// <summary>
    /// An interface containing methods for paper figures.
    /// </summary>
    public interface IPaperFigure : IFigure
    {
        /// <summary>
        /// Property for determining the ability to recolor a figure.
        /// </summary>
        bool IsRecolor { get; }

        /// <summary>
        /// Property for storing color.
        /// </summary>
        Color Color { get; }

        /// <summary>
        /// Method for recoloring a figure.
        /// </summary>
        /// <param name="color"></param>
        void RecolorFigure(Color color);
    }
}

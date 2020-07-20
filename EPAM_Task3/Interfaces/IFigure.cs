namespace EPAM_Task3.Interfaces
{
    /// <summary>
    /// An interface containing methods for geometric figures.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// The method calculates the perimeter of the current figure.
        /// </summary>
        /// <returns>Perimeter</returns>
        double GetPerimeter();

        /// <summary>
        /// The method calculates the area of the current figure.
        /// </summary>
        /// <returns>Area</returns>
        double GetArea();
    }
}

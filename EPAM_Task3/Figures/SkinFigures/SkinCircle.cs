using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;

namespace EPAM_Task3.Figures.SkinFigures
{
    public class SkinCircle : Circle, ISkinFigure
    {
        /// <summary>
        /// Constructor to initialize a circle through a radius.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        public SkinCircle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// Constructor to initialize a circle through a radius and a other skin figure.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// /// <param name="figure">Other skin figure</param>
        public SkinCircle(double radius, ISkinFigure figure) : base(radius)
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.", "radius");
            }
        }
    }
}

using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;

namespace EPAM_Task3.Figures.SkinFigures
{
    public class SkinRectangle : Rectangle, ISkinFigure
    {
        /// <summary>
        /// Constructor to initialize a rectangle through two or four sides.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public SkinRectangle(IEnumerable<double> sidesCollection) : base(sidesCollection)
        {
        }

        /// <summary>
        /// Constructor to initialize a rectangle through two or four sides and other skin figure.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        /// <param name="figure">Other skin figure</param>
        public SkinRectangle(IEnumerable<double> sidesCollection, ISkinFigure figure) : base(sidesCollection)
        {
            double area = Sides[0] * Sides[1];

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.");
            }
        }
    }
}

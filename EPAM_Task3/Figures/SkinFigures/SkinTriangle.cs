using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task3.Figures.SkinFigures
{
    public class SkinTriangle : Triangle, ISkinFigure
    {
        /// <summary>
        /// Constructor to initialize a square through one or three sides.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        public SkinTriangle(IEnumerable<double> sidesCollection) : base(sidesCollection)
        {
        }

        /// <summary>
        /// Constructor to initialize a square through one or three sides and other skin figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="figure">Other skin figure</param>
        public SkinTriangle(IEnumerable<double> sidesCollection, ISkinFigure figure) : base(sidesCollection)
        {
            double halfPerimetr = Sides.Sum() / 2;
            double area = Math.Sqrt(halfPerimetr * (halfPerimetr - Sides[0]) * (halfPerimetr - Sides[1]) * (halfPerimetr - Sides[2]));

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.");
            }
        }
    }
}

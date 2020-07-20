using EPAM_Task3.Enums;
using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task3.Figures.PaperFigures
{
    /// <summary>
    /// Class for working with a triangle.
    /// </summary>
    public class PaperTriangle : Triangle, IPaperFigure
    {
        /// <summary>
        /// Constructor to initialize a square through one or three sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="color">Other paper figure</param>
        public PaperTriangle(IEnumerable<double> sidesCollection, Color color) : base(sidesCollection)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// Constructor to initialize a square through one or three sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="figure">Other paper figure</param>
        public PaperTriangle(IEnumerable<double> sidesCollection, IPaperFigure figure) : base(sidesCollection)
        {
            double halfPerimetr = Sides.Sum() / 2;
            double area = Math.Sqrt(halfPerimetr * (halfPerimetr - Sides[0]) * (halfPerimetr - Sides[1]) * (halfPerimetr - Sides[2]));

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.", "sidesCollection");
            }

            Color = figure.Color;
            IsRecolor = true;
        }

        /// <inheritdoc cref="IPaperFigure.Color"/>
        public Color Color { get; private set; }

        /// <inheritdoc cref="IPaperFigure.IsRecolor"/>
        public bool IsRecolor { get; private set; }

        /// <inheritdoc cref="IPaperFigure.RecolorFigure(Color)"/>
        public void RecolorFigure(Color color)
        {
            if (!IsRecolor)
            {
                throw new ArgumentException("You can only recolor a shape once.", "color");
            }

            Color = color;
            IsRecolor = false;
        }

        /// <inheritdoc cref="Triangle.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            PaperTriangle triangle = (PaperTriangle)obj;

            return (base.Equals(obj) && (Color == triangle.Color));
        }

        /// <inheritdoc cref="Triangle.GetHashCode"/>
        public override int GetHashCode()
        {
            return (base.GetHashCode() + (Color.GetHashCode() >> 3));
        }

        /// <inheritdoc cref="Triangle.ToString"/>
        public override string ToString()
        {
            return (base.ToString() + string.Format($"\nColor: {Color}"));
        }
    }
}

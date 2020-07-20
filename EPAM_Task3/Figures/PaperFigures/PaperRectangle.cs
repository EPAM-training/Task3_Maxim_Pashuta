using EPAM_Task3.Enums;
using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;

namespace EPAM_Task3.Figures.PaperFigures
{
    /// <summary>
    /// Class for working with a rectangle.
    /// </summary>
    public class PaperRectangle : Rectangle, IPaperFigure
    {
        /// <summary>
        /// Constructor to initialize a rectangle through two or four sides and color.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public PaperRectangle(IEnumerable<double> sidesCollection, Color color) : base(sidesCollection)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// Constructor to initialize a rectangle through two or four sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public PaperRectangle(IEnumerable<double> sidesCollection, IPaperFigure figure) : base(sidesCollection)
        {
            double area = Sides[0] * Sides[1];

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

        /// <inheritdoc cref="Rectangle.Equals(object)"/>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            PaperRectangle rectangle = (PaperRectangle)obj;

            return (base.Equals(obj) && (Color == rectangle.Color));
        }

        /// <inheritdoc cref="Rectangle.GetHashCode"/>
        public override int GetHashCode()
        {
            return (base.GetHashCode() ^ Color.GetHashCode());
        }

        /// <inheritdoc cref="Rectangle.GetHashCode"/>
        public override string ToString()
        {
            return (base.ToString() + string.Format($"\nColor: {Color}"));
        }
    }
}

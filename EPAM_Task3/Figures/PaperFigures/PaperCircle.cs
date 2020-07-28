using EPAM_Task3.Enums;
using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;

namespace EPAM_Task3.Figures.PaperFigures
{
    /// <summary>
    /// Class for working with a paper circle.
    /// </summary>
    public class PaperCircle : Circle, IPaperFigure
    {
        /// <summary>
        /// Constructor to initialize a circle through a radius and a color.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// <param name="color">Cicle color</param>
        public PaperCircle(double radius, Color color) : base(radius)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// Constructor to initialize a circle through a radius and other paper figure.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// <param name="figure">Other paper figure</param>
        public PaperCircle(double radius, IPaperFigure figure) : base(radius)
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.");
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
                throw new ArgumentException("You can only recolor a shape once.");
            }

            Color = color;
            IsRecolor = false;
        }

        /// <inheritdoc cref="Circle.RecolorFigure(object)"/>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            PaperCircle circle = (PaperCircle)obj;

            return ((Color == circle.Color) && base.Equals(obj));
        }

        /// <inheritdoc cref="Circle.GetHashCode"/>
        public override int GetHashCode()
        {
            return (base.GetHashCode() ^ Color.GetHashCode());
        }

        /// <inheritdoc cref="Circle.ToString"/>
        public override string ToString()
        {
            return (base.ToString() + string.Format($"\nColor: {Color}"));
        }
    }
}

using EPAM_Task3.Interfaces;
using System;

namespace EPAM_Task3.Figures.UsualFigures
{
    /// <summary>
    /// Abstract class for working with a circle.
    /// </summary>
    public abstract class Circle : IFigure
    {
        /// <summary>
        /// Constructor to initialize a circle through a radius.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The argument less or equal a zero.", "radius");
            }

            Radius = radius;
        }

        /// <summary>
        /// Property for storing radius.
        /// </summary>
        public double Radius { get; }

        /// <inheritdoc cref="IFigure.GetArea()"/>
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        /// <inheritdoc cref="IFigure.GetPerimeter()"/>
        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            Circle circle = (Circle)obj;

            return (Radius == circle.Radius);
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (Radius.GetHashCode() >> 2);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"Type Figure: {GetType().Name}\n" +
                                 $"Area: {GetArea()}\n" +
                                 $"Perimeter: {GetPerimeter()}");
        }
    }
}

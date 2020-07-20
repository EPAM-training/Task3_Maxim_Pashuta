using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task3.Figures.UsualFigures
{
    /// <summary>
    /// Abstract class for working with a triangle.
    /// </summary>
    public abstract class Triangle
    {
        /// <summary>
        /// Constructor to initialize a square through one or three sides.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        public Triangle(IEnumerable<double> sidesCollection)
        {
            if (sidesCollection.Count() != 3)
            {
                throw new ArgumentException("The count of sides is not equal to three.", "sides");
            }

            Sides = sidesCollection.ToList();
        }

        /// <summary>
        /// Property for storing sides.
        /// </summary>
        public List<double> Sides { get; }

        /// <inheritdoc cref="IFigure.GetArea()"/>
        public double GetArea()
        {
            var halfPerimetr = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimetr * (halfPerimetr - Sides[0]) * (halfPerimetr - Sides[1]) * (halfPerimetr - Sides[2]));
        }

        /// <inheritdoc cref="IFigure.GetPerimeter()"/>
        public double GetPerimeter()
        {
            return Sides.Sum();
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

            Triangle triangle = (Triangle)obj;

            for (int i = 0; i < Sides.Count; i++)
            {
                if (Sides[i] != triangle.Sides[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Sides.Select(obj => (int)obj >> 3).Sum(); ;
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

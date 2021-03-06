﻿using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPAM_Task3.Figures.UsualFigures
{
    /// <summary>
    /// Abstract class for working with a rectangle.
    /// </summary>
    public abstract class Rectangle : IFigure
    {
        /// <summary>
        /// Constructor to initialize a rectangle through two or four sides.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public Rectangle(IEnumerable<double> sidesCollection)
        {
            if ((sidesCollection.Count() != 2) && (sidesCollection.Count() != 4))
            {
                throw new ArgumentException("The count of sides is not equal to two or four.");
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
            return Sides[0] * Sides[1];
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

            Rectangle rectangle = (Rectangle)obj;

            for (int i = 0; i < Sides.Count; i++)
            {
                if (Sides[i] != rectangle.Sides[i])
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
            return Sides.Select(obj => obj.GetHashCode() >> 4).Sum();
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

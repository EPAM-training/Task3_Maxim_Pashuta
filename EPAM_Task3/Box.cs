using EPAM_Task3.Figures.UsualFigures;
using EPAM_Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task3
{
    /// <summary>
    /// Class for working with figures collection.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Constructor to initialize the box through a figures collection.
        /// </summary>
        /// <param name="figures">Figures collection</param>
        public Box(IEnumerable<IFigure> figures)
        {
            Figures = new IFigure[20];
            var arrayFigures = figures.ToArray();
            
            for (var i = 0; i < Figures.Length; i++)
            {
                if (i == arrayFigures.Length)
                {
                    break;
                }

                Figures[i] = arrayFigures[i];
            }
        }

        /// <summary>
        /// Property for storing a figures collection.
        /// </summary>
        public IFigure[] Figures { get; private set; }

        /// <summary>
        /// The method adds a new figure to the figures collection.
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(IFigure figure)
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    Figures[i] = figure;
                    break;
                }

                if (Figures[i].Equals(figure))
                {
                    throw new ArgumentException("The box already contains this shape.");
                }
            }
        }

        /// <summary>
        /// The method returns the figure at the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Figure</returns>
        public IFigure ShowFigure(int index)
        {
            return Figures[index];
        }

        /// <summary>
        /// The method returns the figure at the given index and removes it.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Figure</returns>
        public IFigure GetFigure(int index)
        {
            IFigure figure = Figures[index];
            
            for (var i = 0; i < Figures.Length; i++)
            {
                if (i == index)
                {
                    for (var j = i; j < Figures.Length - 1; j++)
                    {
                        Figures[j] = Figures[j + 1];
                    }
                }
            }

            return figure;
        }

        /// <summary>
        /// The method replaces the figure at the given index to the new figure.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="figure">New figure</param>
        public void SetFigure(int index, IFigure figure)
        {
            Figures[index] = figure;
        }

        /// <summary>
        /// The method returns the specified figure if it is the figures collection.
        /// </summary>
        /// <param name="figure"></param>
        /// <returns>Specified figure</returns>
        public IFigure SearchFigure(IFigure figure)
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    break;
                }

                if (Figures[i].Equals(figure))
                {
                    return Figures[i];
                }
            }

            return null;
        }

        /// <summary>
        /// The method returns the count of figures in the collection.
        /// </summary>
        /// <returns>Count of figures</returns>
        public int GetCountFigures()
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// The method returns the total perimeter of the figures.
        /// </summary>
        /// <returns>Total perimeter</returns>
        public double GetTotalPerimeter()
        {
            double totalPerimeter = 0;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                totalPerimeter += Figures[i].GetPerimeter();
            }

            return totalPerimeter;
        }

        /// <summary>
        /// The method returns the total area of the figures.
        /// </summary>
        /// <returns>Total area</returns>
        public double GetTotalArea()
        {
            double totalArea = 0;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                totalArea += Figures[i].GetArea();
            }

            return totalArea;
        }

        /// <summary>
        /// The method returns circles from a figures collection.
        /// </summary>
        /// <returns>Circle collection</returns>
        public List<IFigure> GetCircles()
        {
            var cirles = new List<IFigure>();

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (Figures[i] is Circle)
                {
                    cirles.Add(Figures[i]);
                }
            }

            return cirles;
        }

        /// <summary>
        /// The method returns skin figures from a figures collection. 
        /// </summary>
        /// <returns>Skin figures</returns>
        public List<ISkinFigure> GetSkinFigures()
        {
            var skinFigures = new List<ISkinFigure>();

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (Figures[i] is ISkinFigure)
                {
                    skinFigures.Add((ISkinFigure)Figures[i]);
                }
            }

            return skinFigures;
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

            var box = (Box)obj;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (!Figures[i].Equals(box.Figures[i]))
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
            return Figures.Select(obj => obj.GetHashCode() >> 20).Sum();
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            var boxString = "Figures:\n\n";

            foreach (IFigure figure in Figures)
            {
                boxString += figure.ToString() + "\n\n";
            }

            return boxString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Building : GameEntity
    {
        private List<Coordinate> optinalCoordinates;

        public int CostToBuild { get; set; }

        public Building(Coordinate position, List<Coordinate> optinalCoordinates, ConsoleColor color)
            : base(position, color)
        {
            this.optinalCoordinates = optinalCoordinates;
        }

        public List<Coordinate> OptinalCoordinates
        {
            get { return optinalCoordinates; }
        }

        public Coordinate? HasCoordinate(Coordinate coordinate)
        {
            foreach (Coordinate element in optinalCoordinates)
            {
                if (element.Equals(coordinate))
                {
                    return element;
                }
            }

            return null;
        }
        
    }
}

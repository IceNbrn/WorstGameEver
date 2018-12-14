using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Building : GameEntity
    {
        protected int costToBuild;
        private Coordinate optinalCoordinate;
        private List<Coordinate> optinalCoordinates;
        
        
        public Building(Coordinate position, List<Coordinate> optinalCoordinates, ConsoleColor color)
            : base(position, color)
        {
            this.optinalCoordinates = optinalCoordinates;
        }
        public Coordinate OptinalCoordinate
        {
            get { return optinalCoordinate; }
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

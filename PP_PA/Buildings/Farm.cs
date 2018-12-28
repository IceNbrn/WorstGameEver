using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA.Buildings
{
    class Farm : Building
    {
        private int coinsRate = 20;

        public Farm(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates,color)
        {
            base.Health = 24;
            base.Icon = "F";
            base.CostToBuild = 20;
        }

        public int Work()
        {
            return coinsRate;
        }
    }
}

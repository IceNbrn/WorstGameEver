using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Stable : Building
    {
        //This cost is in coins
        private int costToTrainCavalry = 30;
        //How many cavalries can have
        private int capacity = 10;

        public Stable(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates, color)
        {
            base.Health = 30;
            base.Icon = "S";
            base.costToBuild = 30;
        }

        public int Work(int numberOfCavalries)
        {
            return numberOfCavalries * costToTrainCavalry;
        }
    }
}

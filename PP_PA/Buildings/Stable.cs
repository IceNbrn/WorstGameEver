using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA.Buildings
{
    class Stable : Building
    {
        //This cost is in coins
        private int costToTrainCavalry = 30;
        //How many cavalries can have

        public Stable(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates, color)
        {
            base.Health = 30;
            base.Icon = "S";
            base.CostToBuild = 30;
        }

        public int Work(int numberOfCavalries)
        {
            return numberOfCavalries * costToTrainCavalry;
        }

        public int Capacity { get; set; } = 10;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Barrack : Building
    {
        //This cost is in coins
        private int costToTrainInfantry = 10;

        public int Capacity { get; set; } = 5;

        public Barrack(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates, color)
        {
            base.Health = 60;
            base.Icon = "B";
            base.CostToBuild = 20;
        }

        public int Work(int numberOfInfantries)
        {
            return numberOfInfantries * costToTrainInfantry;
        }
    }
}

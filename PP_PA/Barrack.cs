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
        //How many Artilleries can have
        private int capacity = 5;

        public Barrack(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates, color)
        {
            base.Health = 60;
            base.Icon = "B";
            base.costToBuild = 20;
        }

        public int Work(int numberOfInfantries)
        {
            return numberOfInfantries * costToTrainInfantry;
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
    }
}

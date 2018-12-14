using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class ArtilleryFactory : Building
    {
        //This cost is in coins
        private int costToProduceArtillery = 60;
        //How many Artilleries can have
        private int capacity = 3;

        public ArtilleryFactory(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates, color)
        {
            base.Health = 60;
            base.Icon = "A";
            base.costToBuild = 40;
        }

        public int Work(int numberOfArtilleries)
        {
            return numberOfArtilleries * costToProduceArtillery;
        }
    }
}

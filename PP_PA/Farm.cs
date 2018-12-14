using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Farm : Building
    {
        private int coinsRate = 20;
        

        public Farm(Coordinate position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(position, otherCoordinates,color)
        {
            base.Health = 24;
            base.Icon = "F";
        }

        public int Work()
        {
            return coinsRate;
        }
    }
}

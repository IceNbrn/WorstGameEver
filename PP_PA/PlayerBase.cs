using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class PlayerBase : Building
    {
        public PlayerBase(Coordinate _position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(_position, otherCoordinates, color)
        {
            //TODO: this is not the actual health
            base.Health = 24;
            base.Icon = "O";
        }
    }
}

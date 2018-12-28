using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA.Buildings
{
    class PlayerBase : Building
    {
        public PlayerBase(Coordinate _position, List<Coordinate> otherCoordinates, ConsoleColor color) : base(_position, otherCoordinates, color)
        {
            base.Health = 100;
            base.Icon = "O";
        }
    }
}

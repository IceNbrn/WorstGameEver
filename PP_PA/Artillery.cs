using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Artillery : Unit
    {
        public Artillery(Coordinate position, ConsoleColor color) : base(position, color)
        {
            base.Health = 12;
            base.AttackValue = 24;
            base.AttackRange = 4;
            base.MovePerCell = 6;
            base.Icon = "a";

        }
    }
}

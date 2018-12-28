using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA.Units
{
    class Infantry : Unit
    {
        public Infantry(Coordinate position, ConsoleColor color) : base(position, color)
        {
            base.Health = 48;
            base.AttackValue = 6;
            base.AttackRange = 1;   
            base.MovePerCell = 2;
            base.Icon = "i";
        }
    }
}

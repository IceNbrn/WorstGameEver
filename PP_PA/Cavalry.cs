using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Cavalry : Unit
    {
       
        public Cavalry(Coordinate position, ConsoleColor color) : base(position, color)
        {
            base.Health = 24;
            base.AttackValue = 12;
            base.AttackRange = 1;
            base.MovePerCell = 1;
            base.Icon = "c";
            
        }
        
        
    }
}

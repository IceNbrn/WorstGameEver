using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Unit : GameEntity
    {
        public int MovePerCell { get; set; }
        public int AttackValue { get; set; }
        public int AttackRange { get; set; }

        public Unit(Coordinate position, ConsoleColor color) : base(position, color) { }

        public int CanMove(int distance, int movingPoints)
        {
            int distanceMove = distance * MovePerCell;
            if (distanceMove <= movingPoints)
            {
                return distanceMove;
            }

            return 0;
        }
    }
}

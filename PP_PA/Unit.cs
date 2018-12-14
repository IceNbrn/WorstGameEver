using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Unit : GameEntity
    {
        private int attackValue;
        private int movePerCell;
        private int attackRange;
        

        public Unit(Coordinate position, ConsoleColor color) : base(position, color) { }

        public bool CanMove(int distance, int movingPoints)
        {
            if (distance * movePerCell <= movingPoints)
            {
                return true;
            }

            return false;
        }

        

        public int MovePerCell
        {
            get { return movePerCell; }
            set { movePerCell = value; }
        }
        public int AttackValue
        {
            get { return attackValue; }
            set { attackValue = value; }
        }
        public int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }
    }
}

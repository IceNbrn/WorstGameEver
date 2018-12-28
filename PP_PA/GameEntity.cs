using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class GameEntity
    {
        public int Score { get; set; }

        public int Health { get; set; }

        public Coordinate Position { get; set; }

        public string Icon { get; set; }

        public ConsoleColor Color { get; private set; }

        public GameEntity(Coordinate position, ConsoleColor color)
        {
            this.Color = color;
            this.Position = position;
            Score = 10;
        }

        public int Distance(Coordinate destinationCoordinate)
        {
            int x = destinationCoordinate.Letter - Position.Letter;
            int y = destinationCoordinate.Number - Position.Number;
            int result = x + y;

            result = result > 0 ? result : -result;

            return result;
        }

        public bool TakeDamage(int attackDamage)
        {
            int tempHealth = Health;

            Health -= attackDamage;

            UpdateColor(tempHealth);

            if (Health <= 0)
            {
                //If returns true, means that the GameEntity is destroyed
                return true;
            }
            //If returns false, the GameEntity still alive
            return false;
        }

        public void UpdateColor(int health)
        {
            if (this.Health <= health / 2)
            {
                if (Color == ConsoleColor.Blue)
                    Color = ConsoleColor.DarkBlue;
                else
                    Color = ConsoleColor.DarkRed;
            }
        }

    }
}

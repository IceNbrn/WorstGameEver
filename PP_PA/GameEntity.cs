using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class GameEntity
    {
        private int health;
        private Coordinate position;
        private string icon;
        private ConsoleColor color;
        private int cost;

        public GameEntity(){ }
        

        public GameEntity(Coordinate position, ConsoleColor color)
        {
            this.color = color;
            this.position = position;
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Coordinate Position
        {
            get { return position; }
            set { position = value; }
        }


        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public ConsoleColor Color
        {
            get { return color; }
        }

        public int Distance(Coordinate destinationCoordinate)
        {
            int x = destinationCoordinate.Letter - position.Letter;
            int y = destinationCoordinate.Number - position.Number;
            /*int x = destinationCoordinate.Letter - actualCoordinate.Letter;
            int y = destinationCoordinate.Number - actualCoordinate.Number;*/
            int result = x + y;
            if (result > 0)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }

        public bool TakeDamage(int attackDamage)
        {
            int tempHealth = health;

            health -= attackDamage;

            UpdateColor(tempHealth);

            if (health <= 0)
            {
                //If returns true, means that the GameEntity is destroyed
                return true;
            }
            //If returns false, the GameEntity still alive
            return false;
        }

        public void UpdateColor(int health)
        {
            if (this.health <= health / 2)
            {
                if (color == ConsoleColor.Blue)
                    color = ConsoleColor.DarkBlue;
                else
                    color = ConsoleColor.DarkRed;
            }
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public class Coins
    {
        private int x = 0;

        public Coins(int _x)
        {
            x += _x;
        }

        public void AddCoins(int coins)
        {
            x += coins;
        }

        public void RemoveCoins(int coins)
        {
            x -= coins;
        }

        public int GetCoins()
        {
            return x;
        }
    }
}

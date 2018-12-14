using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class GameManager
    {
        private int turn = 0;
        private Player playerTurn;
        private bool gameFinished;
        private Player p1, p2;
        

        public void SetPlayers(Player _p1, Player _p2)
        {
            p1 = _p1;
            p2 = _p2;
        }

        public int NewTurn()
        {
            turn++;
            playerTurn = Utils.IsDivisibleByX(turn, 2) ? p1 : p2;
            PlayerTurn.Resources.GetToWork();
            
            return turn;
        }

        public Player GetEnemyPlayer()
        {
            if (playerTurn == p1)
                return p2;
            return p1;
        }

        public Player PlayerTurn
        {
            get { return playerTurn; }
            set { playerTurn = value; }
        }
        public Player Player1
        {
            get { return p1; }
        }
        public Player Player2
        {
            get { return p2; }
        }
    }
}

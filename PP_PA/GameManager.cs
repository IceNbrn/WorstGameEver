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


        public GameManager()
        {
            p1 = new Player("Player 1",ConsoleColor.Blue);
            p2 = new Player("Player 2", ConsoleColor.Red);
            
        }

        public void UpdatePlayers(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
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

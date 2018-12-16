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
        public bool GameFinished { get; set; }
        private Player winner;
        private Player p1, p2;


        public GameManager()
        {
            p1 = new Player("Player 1",ConsoleColor.Blue);
            p2 = new Player("Player 2", ConsoleColor.Red);
            
            CreatePlayerBase(p1, "player 1");
            CreatePlayerBase(p2, "player 2");

            CreatePlayerFarm(p1, "player 1");
            CreatePlayerFarm(p2, "player 2");
        }

        public void SetGameOver()
        {
            this.winner = playerTurn;
            GameFinished = true;

        }
        public void CreatePlayerBase(Player p,string player)
        {
            Coordinate addCoordinate = new Coordinate();
            if (player == "player 1")
                addCoordinate = new Coordinate('M', 0);
            else
                addCoordinate = new Coordinate('M', 15);

            char firstLetter = addCoordinate.Letter;
            int firstNumber = addCoordinate.Number;

            List<Coordinate> listCoordinates = new List<Coordinate>();

            Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);
            Coordinate thirdCoordinate = new Coordinate(firstLetter, ++firstNumber);
            Coordinate fourthCoordinate = new Coordinate(--firstLetter, firstNumber);

            listCoordinates.Add(secondCoordinate);
            listCoordinates.Add(thirdCoordinate);
            listCoordinates.Add(fourthCoordinate);

            PlayerBase pb = new PlayerBase(addCoordinate, listCoordinates, p.Color);
            p.Resources.AddEntity(pb);
        }

        public void CreatePlayerFarm(Player p, string player)
        {
            Coordinate addCoordinate = new Coordinate();
            if (player == "player 1")
                addCoordinate = new Coordinate('A', 0);
            else
                addCoordinate = new Coordinate('A', 16);

            char firstLetter = addCoordinate.Letter;
            int firstNumber = addCoordinate.Number;

            List<Coordinate> listCoordinates = new List<Coordinate>();

            Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);

            listCoordinates.Add(secondCoordinate);

            Farm farm = new Farm(addCoordinate, listCoordinates, p.Color);
            p.Resources.AddEntity(farm);
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

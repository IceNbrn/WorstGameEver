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
        
        private Player winner;
        private Player p1, p2;

        public bool GameFinished { get; set; }

        public ScoreTableManager ScoreTableManager { get; set; }

        public GameManager()
        {
            p1 = new Player("Player 1", ConsoleColor.Blue);
            p2 = new Player("Player 2", ConsoleColor.Red);
            
            CreatePlayerBase(p1, true);
            CreatePlayerBase(p2, false);

            CreatePlayerFarm(p1, true);
            CreatePlayerFarm(p2, false);

            ScoreTableManager = new ScoreTableManager();
            
        }

        public void SetGameOver()
        {
            this.winner = playerTurn;
            GameFinished = true;
            ScoreTableManager.AddScoreToFile(playerTurn);
        }
        

        public void CreatePlayerBase(Player p,bool isP1)
        {
            Coordinate addCoordinate = new Coordinate();
            if (isP1)
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

        public void CreatePlayerFarm(Player p, bool isP1)
        {
            Coordinate addCoordinate = new Coordinate();
            if (isP1)
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

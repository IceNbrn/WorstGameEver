using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP_PA.Buildings;

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

            ScoreTableManager = new ScoreTableManager();
            
        }

        public void SetGameOver()
        {
            this.winner = playerTurn;
            Sound.PlaySound(SoundType.WonGame);
            GameFinished = true;
            ScoreTableManager.AddScoreToFile(playerTurn);
        }
        

        public void CreatePlayerBase(Player p,bool isP1)
        {
            
            Coordinate coordinate = new Coordinate();
            Coordinate p2Coordinate = new Coordinate();

            Random rndLetter;
            rndLetter = new Random();
            Random rndNumber;
            rndNumber = new Random();
            int letter = 0;
            int number = 0;

            if (isP1)
            {
                letter = rndLetter.Next(65, 89);
                number = rndNumber.Next(0, 15);
                coordinate = new Coordinate((char)letter,number);
            }
            else
            {
                do
                {
                    letter = rndLetter.Next(65, 89);
                    number = rndNumber.Next(0, 15);
                    coordinate = new Coordinate((char)letter, number);
                } while (coordinate.Distance(p1.Resources.GetRandomBuilding<PlayerBase>().Position) < 20);
                
            }
                

            char firstLetter = coordinate.Letter;
            int firstNumber = coordinate.Number;

            List<Coordinate> listCoordinates = new List<Coordinate>();

            Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);
            Coordinate thirdCoordinate = new Coordinate(firstLetter, ++firstNumber);
            Coordinate fourthCoordinate = new Coordinate(--firstLetter, firstNumber);

            listCoordinates.Add(secondCoordinate);
            listCoordinates.Add(thirdCoordinate);
            listCoordinates.Add(fourthCoordinate);

            PlayerBase pb = new PlayerBase(coordinate, listCoordinates, p.Color);
            p.Resources.AddEntity(pb);
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

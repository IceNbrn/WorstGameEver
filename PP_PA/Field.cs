using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PP_PA
{
    class Field
    {
        //n rows
        private int fieldSizeI; //16 * 2 + 3  35
        //n columns
        private int fieldSizeJ; //26 * 2 + 2  54

        private GameManager gm;


        //TODO: Rever este player, não deve ser preciso pois já temos o GameManager;
        private Player p1;
        private Player p2;

        
        private Hashtable letterCoordinates;
        //private char[] letterCoordinates;
        private string[,] savedPositions;

        string line = Char.ConvertFromUtf32(9472);
        string lineUp = Char.ConvertFromUtf32(9474);
        string upLeftCorner = Char.ConvertFromUtf32(9484);
        string upRightCorner = Char.ConvertFromUtf32(9488);
        string downLeftCorner = Char.ConvertFromUtf32(9492);
        string downRightCorner = Char.ConvertFromUtf32(9496);
        string cross = Char.ConvertFromUtf32(9532);
        string tUpSide = Char.ConvertFromUtf32(9524);
        string tUpSideDown = Char.ConvertFromUtf32(9516);
        string tPointingRight = Char.ConvertFromUtf32(9500);
        string tPointingLeft = Char.ConvertFromUtf32(9508);

        public Field(GameManager _gm)
        {
            gm = _gm;

            fieldSizeI = 16 * 2 + 3;
            fieldSizeJ = 26 * 2 + 2;

            letterCoordinates = new Hashtable();
            //letterCoordinates = new char[fieldSizeJ];
            savedPositions = new string['Z'+1,fieldSizeJ];
            
        }

        public Field(GameManager _gm, int rows, int columns)
        {
            gm = _gm;
            fieldSizeI = rows * 2 + 3;
            fieldSizeJ = columns * 2 + 2;

            letterCoordinates = new Hashtable();
            //letterCoordinates = new char[fieldSizeJ];
            savedPositions = new string['Z', fieldSizeJ];
            
        }

        public bool IsOutOfBorders(Coordinate coordinate)
        {
            if ((coordinate.Letter >= 'A' && coordinate.Letter <= 'Z') && (coordinate.Number <= 16 && coordinate.Number >= 0))
            {
                return false;
            }

            return true;
        }

        public void AddPlayerBase()
        {
            //gm.Player1.Resources.
        }
        
        private void Create()
        {
            char letter = 'A';
            int number = 0;
            for (int i = 0; i <= fieldSizeI; i++)
            {
                for (int j = 0; j <= fieldSizeJ; j++)
                {
                    //If is the first line then is going to check which column is
                    
                    if (i == 0)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            Console.Write(" ");
                            letterCoordinates[j] = '-';
                        }
                        else if (!Utils.IsDivisibleByX(j, 2))
                        {
                            letterCoordinates[j] = letter;
                            Console.Write(letter++);
                            
                        }
                        //If j == fieldSizeJ that means we are at the last number of the row, so we go to the next line
                        else if (j == fieldSizeJ)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                    }
                    else if (i == 1)
                    {
                        DrawFirstLine(fieldSizeJ);
                        break;

                    }
                    else if (i == fieldSizeI)
                    {
                        DrawLastLine(fieldSizeJ);
                        break;
                    }
                    else
                    {
                        if (Utils.IsDivisibleByX(i, 2))
                        {
                            DrawLineUpRowTeste(number++, fieldSizeJ);
                            break;
                        }
                        else
                        {
                            DrawCrossRow(fieldSizeJ);
                            break;
                        }
                    }
                }
            }
        }
        public void Show()
        {
            Create();
        }
        //TODO: This function just needs to be removed!
        public void NewField()
        {
            Console.Clear();
            //Console.WriteLine(Char.ConvertFromUtf32(2017));
            char letter = 'A';
            int number = 0;
            for (int i = 0; i <= fieldSizeI; i++)
            {
                for (int j = 0; j <= fieldSizeJ; j++)
                {

                    //If is the first line then will check which column is
                    if (i == 0)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            Console.Write(" ");
                            letterCoordinates[j] = '-';

                        }
                        else if (!Utils.IsDivisibleByX(j, 2))
                        {
                            letterCoordinates[j] = letter;
                            Console.Write(letter++);

                        }
                        //If j == fieldSizeJ that means we are at the last number of the row, so we go to the next line
                        else if (j == fieldSizeJ)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(" ");
                        }

                    }
                    else if (i == 1)
                    {
                        DrawFirstLine(fieldSizeJ);
                        break;

                    }
                    else if (i == fieldSizeI)
                    {
                        DrawLastLine(fieldSizeJ);
                        break;
                    }
                    else
                    {
                        if (Utils.IsDivisibleByX(i, 2))
                        {
                            //type = type.ToLower();
                            DrawLineUpRowTeste(number++,fieldSizeJ);
                            //DrawLineUpRow(number++, fieldSizeJ, ge, type, isBuilding);
                            break;
                        }
                        else
                        {
                            DrawCrossRow(fieldSizeJ);
                            break;
                        }
                    }
                }
            }
            
        }
        //TODO: This function just needs to call the Create method!
        public bool Update()
        {
            NewField();

            return true;
        }
        //TODO: This function needs to be remove!
        /*
        public bool Update(GameEntity ge, Coordinate optionalCoordinate)
        {
            GameEntity newGe = new GameEntity();
            //Dúvida ao professor
            newGe = (GameEntity)ge.Clone();
            newGe.Position = optionalCoordinate;
            Move(ge, newGe);

            return true;
        }*/
        //TODO: This function needs to be remove!
        /*
        private bool Move(GameEntity ge, GameEntity newGe)
        {
            
            DeleteEntity(ge);
            DrawEntity(newGe);
            return true;
        }*/
        //TODO: This function needs to be remove!
        /*private bool DrawEntity(GameEntity ge)
        {
            bool isBuilding = ge is Building ? true : false;
            NewField("Add",ge, isBuilding);
            return true;
        }
        //TODO: This function needs to be remove!
        public bool DeleteEntity(GameEntity ge)
        {
            NewField("Delete",ge);
            return true;
        }*/

        //Function to show the first line
        public void DrawFirstLine(int x)
        {
            for (int i = 0; i <= x; i++)
            {
                if (i == 0 || i == 1)
                {
                    Console.Write(" ");
                }
                else if (i == 2)
                {
                    Console.Write(upLeftCorner);
                }
                else if (!Utils.IsDivisibleByX(i, 2))
                {
                    Console.Write(line);
                }
                else if (i == x)
                {
                    Console.Write(upRightCorner);
                }
                else
                {
                    Console.Write(tUpSideDown);
                }
            }
            Console.WriteLine();
        }
        //TODO: This function needs to be deleted!
        //Function to show the row with linesUp, it's called for the first time that field is created.
        public void DrawLineUpRow(int x, int n)
        {
            if (x < 10)
                Console.Write(" {0}", x);
            else
                Console.Write("{0}", x);

            for (int j = 0; j < n; j++)
            {
                
                if (Utils.IsDivisibleByX(j, 2))
                {
                    Console.Write(lineUp);
                }
                else
                {
                    savedPositions[x, j] = " ";
                    Console.Write(savedPositions[x,j]);
                }

            }
            Console.WriteLine();
        }
        //TODO: This function needs to renamed!
        //This function is called when is needed to add/update a unit on the field
        public void DrawLineUpRowTeste(int x, int n)
        {
            Coordinate addCoordinate = new Coordinate();
            

            int letterInNumber = 0;

            if (x < 10)
                Console.Write(" {0}", x);
            else
                Console.Write("{0}", x);
            

            for (int j = 0; j <= n - 2; j++)
            {
                int middleNumber = (('A' + 'Z') / 2);
                if (j < 52)
                {
                    letterInNumber = j + 2;
                }
                //This is where it's added the inicial farm to each player ResourcesManager
                if ((x == 0 || x == 16) && !Utils.IsDivisibleByX(j, 2) && (char)letterCoordinates[letterInNumber] == 'A')
                {
                    addCoordinate = new Coordinate((char)letterCoordinates[letterInNumber], x);

                    char firstLetter = addCoordinate.Letter;
                    int firstNumber = addCoordinate.Number;

                    List<Coordinate> listCoordinates = new List<Coordinate>();

                    Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);

                    listCoordinates.Add(secondCoordinate);

                    Farm farm;

                    if (x == 0)
                    {
                        farm = new Farm(addCoordinate, listCoordinates, gm.Player1.Color);
                        gm.Player1.Resources.AddEntity(farm);
                    }
                    else if (x == 16)
                    {
                        farm = new Farm(addCoordinate, listCoordinates, gm.Player2.Color);
                        gm.Player2.Resources.AddEntity(farm);
                    }
                        
                }
                //This is where it's added the PlayerBase to each player ResourcesManager
                if ((x == 0 || x == 15) && !Utils.IsDivisibleByX(j, 2) && (char)letterCoordinates[letterInNumber] == middleNumber)
                {
                    addCoordinate = new Coordinate((char)letterCoordinates[letterInNumber], x);

                    char firstLetter = addCoordinate.Letter;
                    int firstNumber = addCoordinate.Number;

                    List<Coordinate> listCoordinates = new List<Coordinate>();

                    Coordinate secondCoordinate = new Coordinate(++firstLetter, firstNumber);
                    Coordinate thirdCoordinate = new Coordinate(firstLetter, ++firstNumber);
                    Coordinate fourthCoordinate = new Coordinate(--firstLetter, firstNumber);

                    listCoordinates.Add(secondCoordinate);
                    listCoordinates.Add(thirdCoordinate);
                    listCoordinates.Add(fourthCoordinate);

                    PlayerBase pb;

                    if (x == 0)
                    {
                        pb = new PlayerBase(addCoordinate, listCoordinates, gm.Player1.Color);
                        gm.Player1.Resources.AddEntity(pb);
                    }else if (x == 15)
                    {
                        pb = new PlayerBase(addCoordinate, listCoordinates, gm.Player2.Color);
                        gm.Player2.Resources.AddEntity(pb);
                    }
                        
                }
                if (Utils.IsDivisibleByX(j, 2))
                {
                    Console.Write(lineUp);
                    
                }
                else if (!Utils.IsDivisibleByX(j, 2))
                {
                    if (gm.Player1.Resources.IsCoordinateAvailable(new Coordinate((char)letterCoordinates[letterInNumber], x)) != null)

                    {
                        GameEntity newGameEntity = gm.Player1.Resources.IsCoordinateAvailable(new Coordinate((char)letterCoordinates[letterInNumber], x));
                        Utils.ColorWrite(newGameEntity.Color,newGameEntity.Icon);
                        
                    }
                    else if (gm.Player2.Resources.IsCoordinateAvailable(new Coordinate((char)letterCoordinates[letterInNumber], x)) != null)

                    {
                        GameEntity newGameEntity = gm.Player2.Resources.IsCoordinateAvailable(new Coordinate((char)letterCoordinates[letterInNumber], x));
                        Utils.ColorWrite(newGameEntity.Color, newGameEntity.Icon);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        

        //Function to show the row with Cross and lines
        public void DrawCrossRow(int n)
        {
            Console.Write("  " + tPointingRight);
            for (int i = 3; i <= n; i++)
            {
                if (!Utils.IsDivisibleByX(i,2))
                {
                    Console.Write(line);
                }else if (i == n)
                {
                    Console.Write(tPointingLeft);
                }
                else
                {
                    Console.Write(cross);
                }
            }
            Console.WriteLine();
        }

        //Function to show the last line
        public void DrawLastLine(int x)
        {
            for (int i = 0; i <= x; i++)
            {
                if (i == 0 || i == 1)
                {
                    Console.Write(" ");
                }
                else if (i == 2)
                {
                    Console.Write(downLeftCorner);
                }
                else if (!Utils.IsDivisibleByX(i, 2))
                {
                    Console.Write(line);
                }
                else if (i == x)
                {
                    Console.Write(downRightCorner);
                }
                else
                {
                    Console.Write(tUpSide);
                }
            }
            Console.WriteLine();
        }
    }
}

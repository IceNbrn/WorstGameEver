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
        
        
        private Hashtable letterCoordinates;

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
            
        }

        public Field(GameManager _gm, int rows, int columns)
        {
            gm = _gm;
            fieldSizeI = rows * 2 + 3;
            fieldSizeJ = columns * 2 + 2;

            letterCoordinates = new Hashtable();
            
        }

        public bool IsOutOfBorders(Coordinate coordinate)
        {
            if ((coordinate.Letter >= 'A' && coordinate.Letter <= 'Z') && (coordinate.Number <= 16 && coordinate.Number >= 0))
            {
                return false;
            }

            return true;
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
                            DrawLineUpRow(number++, fieldSizeJ);
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
        
        public void Update()
        {
            Create();
        }

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
        //This function is called when is needed to add/update a unit on the field
        public void DrawLineUpRow(int x, int n)
        {
            int letterInNumber = 0;

            if (x < 10)
                Console.Write(" {0}", x);
            else
                Console.Write("{0}", x);
            

            for (int j = 0; j <= n - 2; j++)
            {
                if (j < 52)
                {
                    letterInNumber = j + 2;
                }
                Coordinate atualCoordinate = new Coordinate();
                if (letterCoordinates[letterInNumber] != null)
                    atualCoordinate = new Coordinate((char) letterCoordinates[letterInNumber], x);
                if (Utils.IsDivisibleByX(j, 2))
                {
                    Console.Write(lineUp);
                    
                }
                else if (!Utils.IsDivisibleByX(j, 2))
                {
                    if (gm.Player1.Resources.IsCoordinateAvailable(atualCoordinate) != null)

                    {
                        GameEntity newGameEntity = gm.Player1.Resources.IsCoordinateAvailable(atualCoordinate);
                        Utils.ColorWrite(newGameEntity.Color,newGameEntity.Icon);
                        
                    }
                    else if (gm.Player2.Resources.IsCoordinateAvailable(atualCoordinate) != null)

                    {
                        GameEntity newGameEntity = gm.Player2.Resources.IsCoordinateAvailable(atualCoordinate);
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

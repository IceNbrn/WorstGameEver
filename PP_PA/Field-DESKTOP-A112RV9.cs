using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    class Field
    {
        //n rows
        private int fieldSizeI = 16 * 2 + 3; //16 * 2 + 3  35
        //n columns
        private int fieldSizeJ = 26 * 2 + 2; //26 * 2 + 2  54

        char[] letterCoordinates = new char['Z'];



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
                        }
                        else if (!Utils.IsDivisibleByX(j, 2))
                        {
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
                        FirstLine(fieldSizeJ);
                        break;

                    }
                    else if (i == fieldSizeI)
                    {
                        LastLine(fieldSizeJ);
                        break;
                    }
                    else
                    {
                        if (Utils.IsDivisibleByX(i, 2))
                        {
                            LineUpRow(number++, fieldSizeJ);
                            break;
                        }
                        else
                        {
                            CrossRow(fieldSizeJ);
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

        public void Update(int type, Coordinate position)
        {
            Console.Clear();
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
                            Console.Write(letter++);
                            letterCoordinates[j] = letter;
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
                        FirstLine(fieldSizeJ);
                        break;

                    }
                    else if (i == fieldSizeI)
                    {
                        LastLine(fieldSizeJ);
                        break;
                    }
                    else
                    {
                        if (Utils.IsDivisibleByX(i, 2))
                        {
                            LineUpRow(number++, fieldSizeJ,position);
                            break;
                        }
                        else
                        {
                            CrossRow(fieldSizeJ);
                            break;
                        }
                    }
                }
            }
        }
        //Function to show the first line
        public void FirstLine(int x)
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

        //Function to show the row with linesUp
        public void LineUpRow(int x, int n)
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
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
        }
        //This function is called when is needed to add/update a unit on the field
        public void LineUpRow(int x, int n, Coordinate newPosition)
        {
            if(x < 10)
                Console.Write(" {0}",x);
            else
                Console.Write("{0}", x);

            for (int j = 0; j < n; j++)
            {
                
                if (Utils.IsDivisibleByX(j, 2))
                {
                    Console.Write(lineUp);
                }else if (!Utils.IsDivisibleByX(j,2) && x == newPosition.GetY() && letterCoordinates[j] == newPosition.GetX())
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
        }

        //Function to show the row with Cross and lines
        public void CrossRow(int n)
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
        public void LastLine(int x)
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

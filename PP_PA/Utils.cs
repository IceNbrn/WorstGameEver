using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public static class Utils
    {
        //This function is used to see if is a even number, if it return true
        public static bool IsDivisibleByX(int x, int y)
        {
            if (x % y == 0)
            {
                return true;
            }

            return false;
        }

        public static void ColorWrite(ConsoleColor color,string txt)
        {
            Console.ForegroundColor = color;
            Console.Write(txt);
            Console.ResetColor();
        }
    }
}

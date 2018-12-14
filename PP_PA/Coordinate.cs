using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_PA
{
    public struct Coordinate
    {
        private char letter;
        private int number;

        public Coordinate(char letter, int number)
        {
            this.letter = letter;
            this.number = number;
        }
        
        public Coordinate Right()
        {
            return new Coordinate(++letter,number);
        }
        public Coordinate Up()
        {
            return new Coordinate(letter, ++number);
        }
        //TODO: This is not needed, because we already got get&set!
        public char GetLetter()
        {
            return letter;
        }

        public int GetNumber()
        {
            return number;
        }

        public char Letter
        {
            get { return letter; }
            set { letter = value; }
        }
        public int Number
        {
            get { return number; }
        }
    }
}

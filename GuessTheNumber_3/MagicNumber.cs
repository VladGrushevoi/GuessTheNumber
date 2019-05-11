using System;

namespace GuessTheNumber_3
{
    public class MagicNumber
    {
        private  int gnumber = 0;
        private  int from = 0;
        private  int to = 0;
        private  int countTry ;
        private int inputNumber = 0;

        Random rand = new Random();

        public MagicNumber()
        {

        }

        public int  SetGuess()
        {
            return rand.Next(from, to);
        }

        public int Guess
        {
            get
            {
                return gnumber;
            }
            set
            {
                if (value > 0)
                {
                    gnumber = value;
                }
                else
                {
                    throw new Exception("Загадане число не коректне, воно менше нуля");
                }
            }
        }
        public int From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }
        public int To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }
        public int CountTry
        {
            get
            {
                return countTry;
            }
            set
            {
                countTry = value;
            }
        }
        public int InputNumber
        {
            get
            {
                return inputNumber;
            }
            set
            {
                inputNumber = value;
            }
        }


        public int Check()
        {
            if (inputNumber > to)
            {
                return 1;
            }
            else if (inputNumber < from)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public void TryCulculate()
        {
            int temp = to - from;
            while (temp > 1)
            {
                temp = temp / 2;
                countTry += 1;
            }
        }
    }
}

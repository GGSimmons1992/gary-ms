using System;

namespace FizzbuzzConsole.Library
{
    public class Fizzy
    {
        public int counter { get; set; }
        public int factor { get; set; }
        public string name { get; set; }

        public Fizzy(string countName, int countNum)
        {
            counter = 0;
            factor = countNum;
            name = countName;
        }

        public Incrementer(int currentNumber)
        {
            if (currentNumber % factor == 0)
            {

            }
        }
    }
}

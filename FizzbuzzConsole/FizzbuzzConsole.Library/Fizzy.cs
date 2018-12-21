using System;

namespace FizzbuzzConsole.Library
{
    public class Fizzy
    {
        int counter { get; set; }
        int factor { get; set; }
        string name { get; set; }

        public Fizzy(string countName, int countNum)
        {
            counter = 0;
            factor = countNum;
            name = countName;
        }
    }
}

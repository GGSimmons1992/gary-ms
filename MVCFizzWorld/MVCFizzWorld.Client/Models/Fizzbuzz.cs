using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFizzWorld.Client.Models
{
    public static class Fizzbuzz
    {     

        public static string Categorize(int number)
        {
            string category = "";
            if (number % 3 == 0 && number % 5 == 0)
            { category = "Fizzbuzz"; }
            else if (number % 3 == 0)
            { category = "Fizz"; }
            else if (number % 5 == 0)
            { category = "Buzz"; }

            return category;
        }

    }
}

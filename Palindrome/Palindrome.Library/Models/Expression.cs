using System;
using System.Collections.Generic;
using System.Text;

namespace Palindrome.Library.Models
{
    public class Expression
    {
        public String regular { get; set; }
        public String reverse { get; set; }

        public Expression(string input)
        {
            regular = input.ToLower();
            reverse = "";
            for (var i=(regular.Length-1);i>=0;i-=1)
            {
                reverse = reverse + regular[i];
            }

        }

        public bool IsPalindrome()
        {
            if (regular == reverse)
            {
                Console.WriteLine("{0} is a palindrome",regular);
            }
            else
            {
                Console.WriteLine("{0} is not a palindrome", regular);
            }
            return (regular == reverse);
        }

    }
}

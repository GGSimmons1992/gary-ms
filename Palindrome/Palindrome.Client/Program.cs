using Palindrome.Library.Models;
using System;

namespace Palindrome.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PalindromeChallenge();
        }

        public static void PalindromeChallenge()
        {
            Console.WriteLine("Input a word or sentence");
            String UserInput=Console.ReadLine();
            Expression UsersExpression = new Expression(UserInput);
            UsersExpression.IsPalindrome();
            
        }
    }
}

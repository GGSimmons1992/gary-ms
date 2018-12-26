using Palindrome.Library.Models;
using System;
using Xunit;

namespace Palindrome.Tests
{
    public class PalindromeTest
    {

        [Fact]
        public void LoweringTest()
        {
            //Both original and reverse are lowercased
            Expression sut1 = new Expression("I'm A BUNCH OF CAPITALS");
            Expression sut2 = new Expression("i'm a bunch of capitals");
            Assert.Equal(sut1.regular, sut2.regular);
            Assert.Equal(sut1.reverse, sut2.reverse);
        }

        [Fact]
        public void NonPalindrome()
        {
            //This should not be a plaindrome"
            Expression sut3 = new Expression("Clearly not a palindrome");
            Assert.False(sut3.IsPalindrome());
        }

        [Fact]
        public void DefinitePalindrome()
        {
            //This should pass as palindrome
            Expression sut4 = new Expression("Racecar");//If LoweringTest passess, this should pass.
            Assert.True(sut4.IsPalindrome());
        }

        [Fact]
        public void IsReverse()
        {
            //Double checking if really reverse value is the reverse of regular
            Expression sut5 = new Expression("Something Random");
            Expression sut6 = new Expression(sut5.reverse);
            Assert.Equal(sut5.regular,sut6.reverse);
        }
    }
}

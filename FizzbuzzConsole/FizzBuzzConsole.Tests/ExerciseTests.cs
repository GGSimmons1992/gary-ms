using FizzbuzzConsole.Library;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FizzBuzzConsole.Tests
{
    public class ExerciseTests
    {

        [Fact]
        public void nonEqualCheckerTest()
        {
            string FalseExpectation = "sut1 and sut 2 are the same";

            var sut1 = new Fizzy("sut1",4);
            var sut2 = new Fizzy("sut2",4);
            var sut3 = new Fizzy("sut3",5);
            var sutE= new 

            Assert.False(nonEqualChecker(sut1,sut2));
            Assert.True(nonEqualChecker(sut1,sut3));

        }

        [Fact]
        public void validateFizzbuzzTest()
        {
            var sut1 = new Fizzy("sut1", 4);
            var sut2 = new Fizzy("sut2", 5);
            var sut3 = new Fizzy("sut3", 6);

            var sutE = new Exercise();

            Assert.True(sutE.validateFizzbuzz(sut1, sut2, sut3));
            Assert.False(sutE.validateFizzbuzz(sut2, sut3, sut1));

        }

        [Fact]
        public void LooperTest()
        {
            int expectedFizz = (100*15)/3;
            int expectedBuzz = (100 * 15) / 5;
            int expectedFizzbuzz = 100;
            var sut1 = new Fizzy("sut1", 4);
            var sut2 = new Fizzy("sut2", 5);
            var sut3 = new Fizzy("sut3", 6);
            var sutE = new Exercise();

            sutE.Looper(sut1,sut2,sut3,100);

            Assert.True(sut1.counter==expectedFizz);
            Assert.True(sut2.counter==expectedBuzz);
            Assert.True(sut3.counter==expectedFizzbuzz);
        }

    }
}

using GenericConsole.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GenericConsole.Tests.Library
{
    
    public class EmployeeTests
    {
        [Fact]
        public void Test_Peepname()
        {
            var sut = new Peep();
            //var expected;
            var actual = sut.Name;

            Assert.IsType<string>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        public void Test_Peeptitle()
        {
            var sut1 = new Peep();
            var sut2 = new Peep("associate");
            var actual1 = sut1.Title;
            var actual2 = sut2.Title;

            Assert.Equals(String actual1,String "anon");
            Assert.Equals(String actual2,String "associate");
        }
    }
}

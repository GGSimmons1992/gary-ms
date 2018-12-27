using DelegateWorld.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DelegateWorld.Tests
{
    public class DelegateWorldTests
    {
        [Fact]
        private void Sharpie2Test()
        {
            var expected = "Gary Simmons";
            var actual = (new ActionFunc()).Sharpie2("Gary", "Simmons");
            Assert.Equal(actual,expected);
        }
        
        [Fact]
        private void SharpieMetTest()
        {
            var expected = "Gary Simmons";
            var actualObject = (new Delagation());
            var actual=actualObject.SharpieMet("Gary", "Simmons");
            Assert.Equal(actual, expected);
        }
    }
}

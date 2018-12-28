using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ParallelWorld.Domain.Models;

namespace ParallelWorld.Tests
{
    public class ThreadModelTest
    {
        [Fact]
        public void ThreadMasterTest()
        {
            var sut = new ThreadModel();
            var expected = "fred";
            var actual = sut.ThreadMaster(expected);

            Assert.True(expected == actual);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VarianceWorld.Domain.Models;
using Xunit;
using System.Linq;

namespace VarianceWorld.Tests
{
    public class CastingExplictTests
    {
        [Fact]
        public void TestExplicit()
        {
            //y should be byte
            //Casting sut1 = new Casting();
            //var sut2 = sut1.Explicit(50);
            var x = (short) 10;
            byte y = 10;
            byte? z = 10;

            IEnumerable<byte?> expected=new byte?[2];
            var sut =new Casting();
            var actual =sut.Explicit(x);

            Assert.IsType<short>(x);
            Assert.Equal(10, x);
            Assert.IsType<byte?[]>(actual);
            Assert.True(expected.Count() == actual.Count());
            Assert.True(y==actual.ElementAt(0));//positive test
            Assert.False(z==actual.ElementAt(1));//negative test
        }

        [Fact]
        public void TestExplicitOut()
        {
            short expectedX=10;
            byte expectedY=10;
            byte? expectedZ=null;
            short x = 10;
            byte y = 0;
            byte? z = null;

            Casting sut = new Casting();
            sut.Explicit(x, out y, out z);

            Assert.Equal(x,expectedX);
            Assert.Equal(y, expectedY);
            Assert.Equal(z, expectedZ);
            Assert.IsType<short>(x);
            Assert.IsType<byte>(y);
            Assert.True(z==expectedZ);
        }

        [Fact]
        public void TestExplicitRef()
        {
            short expectedW = 100;
            short expectedX = 100;
            byte expectedY = 10;
            byte? expectedZ = null;
            short x = 10;
            short w = 30;

            Casting sut = new Casting();
            sut.Explicit(ref w, ref x, out byte y, out byte? z);

            Assert.Equal(w, expectedW);
            Assert.Equal(x, expectedX);
            
        }

        [Fact]
        public void TestExplicitNoRef()
        {
            var expected = 100;
            short x = 500;
            short w = 35;
            Casting sut = new Casting();
            sut.Explicit(w, x);

            Assert.False(w == expected);
            Assert.False(x == expected);
        }
    }
}

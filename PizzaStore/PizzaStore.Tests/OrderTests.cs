using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class OrderTests
    {
        //Mandatory: Cannot be cancelled once it’s processed

        [Fact]//Orders instantiate as voidable=true. When finalized, voidable=false
        public void VoidOrderTest()
        {
            var sut = new Order();
            Assert.True(sut.Voidable);
            var InventoryCheck = true;
            var CostCheck = true;
            
            sut.Finalize(sut.PizzaTest(), CostCheck, InventoryCheck);
            Assert.True(sut.Voidable);

            sut.AddPizza(new Pizza());
            sut.Finalize(sut.PizzaTest(), CostCheck, InventoryCheck);
            Assert.False(sut.Voidable);
        }

        [Fact]//If worth of order is greater than $5000 cap, do not finaliz order
        public void CostTest()
        {
            var sut = new Order();
            for (var i = 0; i < 3; i += 1)
            {
                sut.AddPizza(new Pizza());
            }
            Assert.True(sut.costTest());
            sut.Finalize(true,sut.costTest(),true);
            Assert.False(sut.Voidable);

        }

         
    }
}

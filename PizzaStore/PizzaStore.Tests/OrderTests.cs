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
            var UserCheck = true;
            sut.Finalize(sut.PizzaTest(), CostCheck, InventoryCheck, UserCheck);//
            Assert.True(sut.Voidable);

            sut.AddPizza(new Pizza());
            sut.Finalize(sut.PizzaTest(), CostCheck, InventoryCheck, UserCheck);//
            Assert.False(sut.Voidable);
        }

        //----
        //Mandatory: Can be fulfilled only if enough available (Need location.Inventory)

        //[Fact]//If inventory of location cannot fullfil order, then do not finalize order
        //public void InventoryTest()
        //{
        //    var sutStore = new Location();
        //    sutStore.AddToInventory("dough",3);
        //    sutStore.AddToInventory("TomatoSauce", 5);
        //    sutStore.AddToInventory("Mozzarella", 5);
        //    var sut = new Order();
        //    Assert.False(sut.InventoryTest(sutStore));
        //    sut.Finalize();

        //}

        [Fact]//If worth of order is greater than $5000 cap, do not finaliz order
        public void CostTest()
        {
            var sut = new Order();
            for (var i = 0; i < 3; i += 1)
            {
                sut.AddPizza(new Pizza());
            }
            Assert.True(sut.costTest());
            sut.Finalize(true,sut.costTest(),true,true);
            Assert.False(sut.Voidable);

        }

         
    }
}

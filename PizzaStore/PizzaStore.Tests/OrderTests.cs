using PizzaStore.Data;
using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class OrderTests
    {
        
        public EntityHelper eh { get; set; }

        public OrderTests()
        {
            eh = new EntityHelper();
        }
        
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

            var failSut = new Order();
            sut.AddPizza(new Pizza(10000));//Since Pizza cost is based on size, a very large pizza is expensive
            Assert.False(sut.costTest());
            sut.Finalize(true, sut.costTest(), true);
            Assert.True(sut.Voidable);
        }

        [Fact]
        public void itemizedTest()
        {
            var sut1 = new Order();
            var sut2 = new Order();
            var store = new Location();

            store.Inventory = new Dictionary<string, int>() { { "Crust", 3 }, { "Pepperoni", 1 }, { "Mozzarella", 20 }, { "TomatoSauce", 20 } };
            for (var i = 0; i < 3; i += 1)
            { sut1.AddPizza(new Pizza()); }
            var inventoryTest=sut1.BalanceOrder(store);
            sut1.Finalize(true,true,inventoryTest);
            Assert.False(sut1.Voidable);

            store.Inventory = new Dictionary<string, int>() { };
            for (var i = 0; i < 5; i += 1)
            { sut2.AddPizza(new Pizza()); }
            Assert.True((sut2.orderInventory()).Count==3);
            Assert.Empty(store.Inventory);
            var inventoryTest2 = sut2.BalanceOrder(store);
            sut2.Finalize(true, true, inventoryTest2);
            Assert.True(sut2.Voidable);
        }

        [Fact]
        public void Test_OrderData()
        {
            Assert.NotNull(eh.GetOrders());
            var OrderList = eh.GetOrders();
            Assert.True(OrderList[1].finalCost==36.00);
        }

        [Fact]
        public void OrderDataAdditionTest()
        {
            var sut = new Order() { UserID=2,StoreID=1};
            Assert.True(eh.setOrder(sut));
        }
    }
}

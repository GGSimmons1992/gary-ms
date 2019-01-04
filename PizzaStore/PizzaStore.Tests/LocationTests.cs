using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class LocationTests
    {
        //Mandatory: Must manage its inventory
        [Fact]//Location can access its inventory
        public void InventoryTest()
        {
            var newStore = new Location();
            Assert.NotNull(newStore.Inventory);
            newStore.AddInventory("pepperoni", 5);
            Assert.True(newStore.Inventory.Count==4);
        }

        [Fact]
        public void RemoveItems()
        {
            var newStore = new Location();
            newStore.removeItems("Mozzarella", 5);
            Assert.True(20 > newStore.Inventory["Mozzarella"]);
        }

        //----
        //Mandatory: Must manage its users
        [Fact]//Location can access its users
        public void UserTest()
        {
            var newStore = new Location();
            Assert.NotNull(newStore.userlist);
            newStore.AddUser(new User("user","passw"));
            Assert.NotEmpty(newStore.userlist);
        }

        //----
        //Mandatory: Must manage its sales
        [Fact]
        public void AddRevenueTest()
        {
            var sut = new Location();
            var defaultLedger = sut.Ledger;
            var newOrder = new Order();
            var P = new Pizza();
            newOrder.AddPizza(P);
            newOrder.Finalize(true,true,true);
            sut.AddToHistory(newOrder);
            Assert.True(defaultLedger<sut.Ledger);
        }
    }
}

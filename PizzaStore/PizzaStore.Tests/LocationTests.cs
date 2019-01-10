using PizzaStore.Data;
using PizzaStore.Data.Helpers;
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
            Assert.True(newStore.Inventory.Count == 4);
        }

        [Fact]
        public void RemoveItems()
        {
            var newStore = new Location();
            newStore.removeItems("Mozzarella", 5);
            Assert.True(15 == newStore.Inventory["Mozzarella"]);
        }

        //----
        //Mandatory: Must manage its users
        [Fact]//Location can access its users
        public void UserTest()
        {
            var newStore = new Location();
            Assert.NotNull(newStore.userlist);
            newStore.AddUser(new User("user", "passw"));
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
            newOrder.Finalize(true, true, true);
            sut.AddToHistory(newOrder);
            Assert.True(defaultLedger < sut.Ledger);
        }

        [Fact]
        public void RemoveToppingsByOrderTest ()
        {
            var sut = new Location();
            var oldMozzCount = sut.Inventory["Mozzarella"];
            var oldCrustCount = sut.Inventory["Crust"];
            var oldSauceCount = sut.Inventory["TomatoSauce"];
            var newUser = new User("Pizza","70v3r!");
            newUser.SetStore(sut);
            var newOrder=newUser.CreateOrder();
            var newPizza = new Pizza();
            Assert.Contains("Mozzarella", newPizza.Toppings);
            newOrder.AddPizza(newPizza);
            newOrder.TrulyFinalize();
            Assert.False(newOrder.Voidable);
            newUser.Submit(newOrder);

            Assert.True(oldMozzCount == 20);//because default
            Assert.True(oldMozzCount != sut.Inventory["Mozzarella"]);
            Assert.True(oldSauceCount > sut.Inventory["TomatoSauce"]);
            Assert.True(oldCrustCount > sut.Inventory["Crust"]);
        }

        [Fact]
        public void SetLocationTest()
        {
            var sut = new Location();
            Assert.True(1==LocationHelper.SetLocation(sut));
            
        }

        [Fact]
        public void SetIngredientTest()
        {
            var sut = "Caviar";
            Assert.True(1 == LocationHelper.SetIngredient(sut));

        }
    }
}

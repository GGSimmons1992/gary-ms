using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class LocationTests
    {
        //Mandatory: Must manage its inventory
        [Fact]//Location can post items into an inventory
        public void PostIngredientTest()
        { }

        [Fact]//Location can get all items of an inventory
        public void GetIngredientsTest()
        { }

        [Fact]//Location can get a single item from the inventory
        public void GetIngredientTest()
        { }

        [Fact]//Location can change item cost (put item cost)
        public void PutIngredientCostTest()
        { }

        [Fact]//Location can update item supply (put item supply)
        public void PutIngredientSupplyTest()
        { }

        [Fact]//Location can remove item from inventory
        public void RemoveIngredientTest()
        { }

        //----
        //Mandatory: Must manage its users
        [Fact]//Location can post users into a userlist
        public void PostUserTest()
        { }

        [Fact]//Location can get all users of a userlist
        public void GetUsersTest()
        { }

        [Fact]//Location can get full history of a single user
        public void GetUserHistoryTest()
        { }

        [Fact]//Location can remove user from userlist
        public void RemoveUserTest()
        { }

        //----
        //Mandatory: Must manage its sales
        [Fact]//Location can get orders
        public void GetOrdersTest()
        { }

        [Fact]//Location can get an order
        public void GetOrderTest()
        { }

        [Fact]//Location posts orders in history once orders are finalized
        public void PostOrderTest()
        { }

        [Fact]//Location removes ingredients when order is processed
        public void ProcessIngredientRemovalTest()
        { }

        [Fact]//Location Balance increases via order process
        public void ProcessIncomingSaleTest()
        { }
    }
}

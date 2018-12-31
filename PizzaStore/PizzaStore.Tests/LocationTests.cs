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

        [Fact]//Location can get a single user from the inventory
        public void GetUserTest()
        { }

        [Fact]//Location can get full history of a user
        public void GetUserHistoryTest()
        { }

        [Fact]//Location can remove user from userlist
        public void RemoveUserTest()
        { }

        //----
        //Mandatory: Must manage its sales
        //Sales part 1: 

        //Sales part 2:
        //Orders cannot be cancelled once it’s processed (Thus no deletion of orders)
    }
}

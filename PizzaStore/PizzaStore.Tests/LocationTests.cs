using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class LocationTests
    {
        //Must manage its inventory
        [Fact]//Location can post items into an inventory
        public void PostItemTest()
        { }

        [Fact]//Location can get all items of an inventory
        public void GetItemsTest()
        { }

        [Fact]//Location can get a single item from the inventory
        public void GetItemTest()
        { }

        [Fact]//Location can change item cost (put item cost)
        public void PutItemCostTest()
        { }

        [Fact]//Location can update item supply (put item supply)
        public void PutItemSupplyTest()
        { }

        [Fact]//Location can remove item from inventory
        public void RemoveItemTest()
        { }

        //----
        //Must manage its users
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
        //Must manage its sales
    }
}

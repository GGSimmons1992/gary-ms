using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class UserTests
    {
        //Mandatory: Must have an account before ordering
        [Fact]
        public void CreateUserTest()
        {
            User sut = new User("Joey","Chesnut");
            Assert.True(sut.AccountTest());
        }

        //----
        //Mandatory: Must be able to see their order history
        [Fact]//User can see their whole history
        public void getHistoryTest()
        {
            var store = new Location();
            var sut = new User("Wheeler","Yam1");
            Assert.NotNull(sut.History);

            var newOrder = sut.CreateOrder();
            newOrder.Finalize(true,true,true);
            sut.AddOrder(newOrder);
            Assert.NotEmpty(sut.History);
        }

        //----
        //Mandatory: Can order up to $5000 worth per order <Test created in Order>

        //----
        //Mandatory: Limit to 1 order per 1 hour

        [Fact]//If user history has an order that happened less than an hour ago, deny creation of order
        public void DenyCreationTimeTest()
        {
            var sut = new User("John","xj9");
            Assert.True(sut.TimeTest());
            var newOrder = sut.CreateOrder();
            newOrder.Finalize(true,true,true);
            sut.AddOrder(newOrder);
            Assert.False(sut.TimeTest());

            var newOrder2 = sut.CreateOrder();
            Assert.Null(newOrder2);

        }

        //----
        //Mandatory: Limit to ordering from 1 location “24hrs(i.e.end of business day)”
        [Fact]//If user tries to change current location within 24 hours, deny change
        public void DenyChangeSpaceTest()
        {
            var sut = new User("Dexter","AceSpades");
            var userStore = new Location();
            var newStore = new Location();
            sut.SetStore(userStore);
            var a = sut.Store.ID;
            var b = userStore.ID;
            Assert.True(sut.SpaceTest());
            Assert.True(a == b);

            var newOrder=sut.CreateOrder();
            newOrder.Finalize(true,true,true);
            sut.AddOrder(newOrder);
            sut.SetStore(newStore);
            var c = sut.Store.ID;
            var d = newStore.ID;
            Assert.False(sut.SpaceTest());
            Assert.False(c == d);
        }
    }
}

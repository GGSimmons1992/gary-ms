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
            var a = sut.Store.GuidId;
            var b = userStore.GuidId;
            Assert.True(sut.SpaceTest());
            Assert.True(a == b);

            var newOrder=sut.CreateOrder();
            newOrder.Finalize(true,true,true);
            sut.AddOrder(newOrder);
            sut.SetStore(newStore);
            var c = sut.Store.GuidId;
            var d = newStore.GuidId;
            Assert.False(sut.SpaceTest());
            Assert.False(c == d);
        }

        [Fact]//Combine all three finalization tests from OrderTests.cs (Testing in user to ensure, user can instantiate order)
        public void TrulyFinalizeTest()
        {
            var sut = new User("Billy","B0b");
            var store = new Location();
            sut.SetStore(store);
            var newOrder = sut.CreateOrder(sut.Store);
            newOrder.AddPizza(new Pizza());
            newOrder.TrulyFinalize();
            Assert.False(newOrder.Voidable);

        }

        [Fact]
        public void SubmitTest()
        {
            var sut = new User("Billy", "B0b");
            var store = new Location();
            sut.SetStore(store);
            var newOrder = sut.CreateOrder(sut.Store);
            newOrder.AddPizza(new Pizza());
            newOrder.TrulyFinalize();
            sut.Submit(newOrder);
            Assert.True(sut.History.Count == 1);
            Assert.True(store.History.Count == 1);
            Assert.True(store.Ledger == (100.0 + newOrder.Cost()));
            Assert.True(store.userlist.Count == 1);
            Assert.True(store.userlist[((store.userlist.Count) - 1)] ==sut);

            var failSut = new User("sad","Panda!");
            var badOrder = failSut.CreateOrder(store);
            badOrder.TrulyFinalize();
            Assert.True(badOrder.Voidable);
            failSut.Submit(badOrder);
            Assert.False(failSut.History.Count == 1);
            Assert.True(store.History.Count == 1);
            Assert.True(store.Ledger == (100.0 + newOrder.Cost()));
            Assert.True(store.userlist.Count == 1);
            Assert.False(store.userlist[((store.userlist.Count) - 1)] == failSut);


        }
    }
}

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
        public void getFullOrderHistoryTest()
        {
            var sut = new User("Wheeler","Yami");
            sut.AddOrder((new Order()).Finalize(true, true, true, true));
            sut.AddOrder((new Order()).Finalize(true, true, true, true));
            Assert.True(User.History.Count==2);
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
            sut.AddOrder((new Order()).Finalize(true, true, true, true));
            Assert.False(sut.TimeTest());
        }

        //----
        //Mandatory: Limit to ordering from 1 location “24hrs(i.e.end of business day)”
        [Fact]//If user tries to change current location within 24 hours, deny change
        public void DenyCreationSpaceTest()
        {
            var sut = new User("Dexter","AceSpades");
            
        }
    }
}

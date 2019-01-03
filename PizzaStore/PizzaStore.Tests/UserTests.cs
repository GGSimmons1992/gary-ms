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
        [Fact]//Username cannot be duplicated in location
        public void CreateUserTest()
        {
            Location a = new Location();
            User b = new User("Joey");
            b.CreateOrder(a);
            Assert.True();
        }

        //----
        //Mandatory: Must be able to see their order history
        [Fact]//User can see their whole history
        public void getFullOrderHistoryTest()
        { }

        [Fact]//User can see an order from their history
        public void getAnOrderHistoryTest()
        { }

        //----
        //Mandatory: Can order up to $5000 worth per order <Test in Order>

        //----
        //Mandatory: Limit to 1 order per 1 hour

        [Fact]//If user history has an order that happened less than an hour ago, deny creation of pre-order
        public void DenyCreationTimeTest()
        { }

        //----
        //Mandatory: Limit to ordering from 1 location “24hrs(i.e.end of business day)”
        [Fact]//If user history has an order from location that has the same date stamp, deny creation of pre-order
        public void DenyCreationSpaceTest()
        { }
    }
}

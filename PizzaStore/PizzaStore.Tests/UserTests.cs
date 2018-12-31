using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class UserTests
    {
        //Mandatory: Must have an account before ordering
        [Fact]//Username cannot be duplicated in all location in the chain
        public void CreateUserTest()
        { }

        [Fact]//
        //Mandatory: Must be able to see their order history
        //Mandatory: Can order up to $5000 worth per order
        //Mandatory: Limit to 1 order per 1 hour
        //Mandatory: Limit to ordering from 1 location “24hrs(i.e.end of business day)”
    }
}

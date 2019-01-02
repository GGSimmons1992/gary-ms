using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class OrderTests
    {
        //Mandatory: Cannot be cancelled once it’s processed

        [Fact]//"Finaling an order" creates an unchangable Order from a PreOrder
        public void FinalizeTest()
        {
            PreOrder a = new PreOrder();

            c Pizza = new Pizza(new Crust("normal"),new Size("12in"));
            c.AddTopping("mozerella");

            OrderTests b = new Order(PreOrder);
            Assert.IsType<Order>(b);
        }

        [Fact]//Order cannot be changed by location or user once finalized.
        public void AttemptChangeTest()
        {
            new Order a = new Order(PreOrder);

        }

        //----
        //Mandatory: Can be fulfilled only if enough available <Test in Pizza>

        //--Interclass tests
        //Mandatory from User: Can order up to $5000 worth per order 
        [Fact]//PreOrder cannot become an Order if worth is above $5000 after taxes.
        public void MetalDetectorTest()
        { }
    }
}

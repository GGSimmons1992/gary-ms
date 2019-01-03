using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class OrderTests
    {
        //Mandatory: Cannot be cancelled once it’s processed
        [Fact]//When processed, it needs to give total pizza cost
        public void TotalCostTest()
        {
            double sizeCost = 12.00;
            double crustMultiplierThin = 1.25;
            double crustMultiplierDefault = 1.00;
            double pepperoniCost = .25;
            double cheeseCost = .25;
            double pineappleCost = .75;
            double expected1 = (sizeCost * crustMultiplierThin) + pepperoniCost + cheeseCost;
            double expected2 = (sizeCost * crustMultiplierDefault) + pineappleCost + cheeseCost;
            double salesTax = 0.75;

            var sutStore = new Location();
            sutStore.tax = salesTax;
            Pizza sut1 = new Pizza(sutStore, 12, "thin");
            Pizza sut2 = new Pizza(sutStore);
            sut1.AddTopping("Pepperoni");
            sut1.AddTopping("Mozzarella");
            sut2.AddTopping("Pineapple");
            sut2.AddTopping("Mozzarella");

            PreOrder trueSut = new PreOrder();
            trueSut.AddPizza(sut1);
            trueSut.AddPizza(sut2);

            Assert.True(trueSut.TotalCost()==((1.0+salesTax)*(expected1+expected2)));
        }

        
        [Fact]//"Finaling an order" creates an unchangable Order from a PreOrder
        public void FinalizeTest()
        {
            PreOrder a = new PreOrder();
            Location d = new Location();
            Pizza c = new Pizza(d);
            c.AddTopping("Mozzarella");
            a.AddPizza(c);

            Order b = a.Finalize();
            Assert.IsType<Order>(b);
            Assert.True(a.TotalCost == b.TotalCost);
        }

        //----
        //Mandatory: Can be fulfilled only if enough available <Test in Pizza>

        //--Interclass tests
        //Mandatory from User: Can order up to $5000 worth per order 
        [Fact]//PreOrder cannot become an Order if worth is above $5000 after taxes.
        public void MetalDetectorTest()
        {

        }
    }
}

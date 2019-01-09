using PizzaStore.Data;
using PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PizzaStore.Tests
{
    public class PizzaTest
    {
        //Mandatory: Must be whole, No half order accepted (No test needed, for I'm not permitting it)

        //----
        //Mandatory: Can contain no more than 5 toppings all categories included

        public EntityHelper eh { get; set; }

        public PizzaTest()
        {
            eh = new EntityHelper();
        }

        [Fact]
        public void PizzaToppingTest()
        {
            var sut = new Pizza();
            var toppingList = new List<string>() { "pepperoni", "sausage" };
            var sut1 = new Pizza(toppingList);
            Assert.True(sut.Toppings.Count <= 5);
            Assert.True(sut1.Toppings.Count <= 5);
            sut1.AddTopping("anchovies");
            Assert.True(sut1.Toppings.Count <= 5);
            sut1.AddTopping("mushrooms");
            Assert.True(sut1.Toppings.Count <= 5);
        }

        //----
        //Mandatory: Price is derived from toppings, size, and/or crust
        [Fact]
        public void PriceCheck()
        {
            var sut = new Pizza();
            var defaultCost = sut.CalculateCost();
            Assert.True(defaultCost > 0);

            var sut2 = new Pizza("pepperoni");
            Assert.True(sut2.CalculateCost() > defaultCost);
        }

        [Fact]
        public void Test_PizzaData()
        {
            Assert.NotNull(eh.GetPizzas());
            var PizzaList=eh.GetPizzas();
            Assert.True(PizzaList[0].OrderId==1);
            Assert.True(PizzaList[1].crustSize==12);
        }

        [Fact]
        public void PizzaDataAdditionTest()
        {
            var sut = new Pizza() { OrderId=1};
            Assert.True(eh.setPizza(sut));
        }
    }
}

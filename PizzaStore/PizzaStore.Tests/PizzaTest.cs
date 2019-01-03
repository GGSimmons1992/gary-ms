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
        [Fact]//Can add valid toppings
        public void AddToppingTest()
        {
            Toppings PreExpected = new Toppings<Topping>();
            Topping Sauce = new Topping("TomatoSauce");
            Topping nonsense new Topping("nonsense");
            Toppings Expected=PreExpected.Add(Sauce);

            var sutStore = new Location();
            var sut = new Pizza(sutStore);
            sut.Toppings.AddTopping("TomatoSauce");
            sut.Toppings.AddTopping("nonsense");
            Assert.True(sut.ToppingList == Expected);
        }

        [Fact]//Can remove toppings
        public void RemoveToppingTest()
        {
            Toppings PreExpected = new Toppings<Topping>();
            Topping Sauce = new Topping("TomatoSauce");
            Topping Cheese = new Topping("Mozzarella");
            Topping P = new Topping("Pepperoni");
            PreExpected.Add(Sauce);
            Toppings Expected=PreExpected.Add(Cheese);

            var sutStore = new Location();
            var sut = new Pizza(sutStore);
            sut.Toppings.AddTopping("TomatoSauce");
            sut.Toppings.AddTopping("Mozzarella");
            sut.Toppings.AddTopping("Pepperoni");
            sut.Toppings.RemoveTopping("Pepperoni");

            Assert.True(sut.ToppingList == Expected);
        }

        [Fact]//Pizza will prevent adding a new topping if 5 are already on it.
        public void StopAddingToppingTest()
        {
            Topping Sauce = new Topping("TomatoSauce");
            Topping Cheese = new Topping("Mozzarella");
            Topping P = new Topping("Pepperoni");
            Topping S = new Topping("Sausage");
            Topping B = new Topping("Bacon");
            Topping Anch = new Topping("Anchovies");
            Toppings Expectation= new Toppings<Topping>(){Sauce,Cheese,P,S,B};
            Toppings FalseExpectation = new Toppings<Topping>() { Sauce, Cheese, P, S, B, Anch};

            var sutStore = new Location();
            var sut = new Pizza(sutStore);
            List<string> potentialToppings = new List<string>() {"TomatoSauce","Mozzarella","Pepperoni","Sausage","Bacon","Anchovies"};
            foreach (var top in potentialToppings)
            {
                sut.AddTopping(top);
            }
            Assert.False(sut.ToppingList==FalseExpectation);
            Assert.True(sut.ToppingList==Expectation);

        }
        
        //----
        //Mandatory: Price is derived from toppings, size, and/or crust
        [Fact]//Price=((CrustMuliplier*SizeCost)+ToppingCosts)
        public void CalculateCostTest()
        {
            double sizeCost =12.00;
            double crustMultiplierThin =1.25;
            double crustMultiplierDefault = 1.00;
            double pepperoniCost = .25;
            double cheeseCost = .25;
            double pineappleCost = .75;
            double expected1 = (sizeCost * crustMultiplierThin) + pepperoniCost + cheeseCost;
            double expected2= (sizeCost * crustMultiplierDefault) + pineappleCost + cheeseCost;

            var sutStore = new Location();
            var sut = new Pizza(sutStore);
            Pizza sut1 = new Pizza(sutStore,12.00,"thin");
            Pizza sut2 = new Pizza(sutStore);
            sut1.AddTopping("Pepperoni");
            sut1.AddTopping("Mozzarella");
            sut2.AddTopping("Pineapple");
            sut2.AddTopping("Mozzarella");

            Assert.True(expected1 == sut1.CalculateCost());
            Assert.True(expected2 == sut2.CalculateCost());
        }

        //--Interclass tests--

        /*
         Mandatory from Order: Can be fulfilled only if enough available
         1) Deny topping or crust from being added <in Pizza>
        */

        [Fact]//Pizza will not instatiate if not enough dough
        public void DoughInventoryTest()
        {
            var sutStore = new Location();
            sutStore.Inventory.Item["Dough"].Amount = 0.0;
            var sut = new Pizza(sutStore);

            Assert.False(sut.Validity);
        }
        
        [Fact]//Pizza will not add topping if location from order does not enough from supply of toppings
        public void ToppingInventoryTest()
        {
            Toppings PreExpected = new Toppings<Topping>();
            Topping P1 = new Topping("Pepperoni");
            Topping P2 = new Topping("Pepperoni");
            Topping P3 = new Topping("Pepperoni");
            PreExpected.Add(P1);
            Toppings Expected = PreExpected.Add(P2);

            var sutStore = new Location();
            sutStore.Inventory.Item["Pepperoni"].Amount = 5.0;
            sutStore.Inventory.Item["Pepperoni"].PerPizza = 2.5; 
            var sut = new Pizza(sutStore);
            sut.AddTopping("Pepperoni");
            sut.AddTopping("Pepperoni");
            sut.AddTopping("Pepperoni");

            Assert.True(sut.ToppingList==Expected);

        }
    }
}

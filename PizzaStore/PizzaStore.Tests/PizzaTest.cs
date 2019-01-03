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

            var sut = new Pizza();
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

            var sut = new Pizza();
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

            Pizza sut = new Pizza();
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


        }

        //--Interclass tests--

        /*
         Mandatory from Order: Can be fulfilled only if enough available
         1) Deny topping or crust from being added <in Pizza>
        */

        [Fact]//Pizza will not instatiate if not enough dough
        public void DoughInventoryTest()
        { }
        
        [Fact]//Pizza will not add topping if location from order does not enough from supply of toppings
        public void ToppingInventoryTest()
        { }
    }
}

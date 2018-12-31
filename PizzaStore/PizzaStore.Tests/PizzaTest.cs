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
        [Fact]//Can add toppings
        public void AddToppingTest()
        { }

        [Fact]//Can remove toppings
        public void RemoveToppingTest()
        { }

        [Fact]//Pizza will prevent adding a new topping if 5 are already on it.
        public void StopAddingToppingTest()
        { }
        
        //----
        //Mandatory: Price is derived from toppings, size, and/or crust
        [Fact]//Price=((CrustMuliplier*SizeCost)+ToppingCosts)
        public void CalculateCostTest()
        { }

        //--Interclass tests--

        /*
         Mandatory from Order: Can be fulfilled only if enough available
         1) Deny topping from being added <in Pizza>
        */

        [Fact]//Pizza will not add topping if 
        public void IngredientLimitTest()
        { }
    }
}

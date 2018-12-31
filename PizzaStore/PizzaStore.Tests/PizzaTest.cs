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

        [Fact]//Pizza should display message if toppings exceed 5 toppings
        public void CreateMessageTest()
        { }

        //----
        [Fact]//Orders can be fulfilled only if enough available (prevent option, if not enough)
        public void IngredientLimitTest()
        { }
        
        //----
        //Mandatory: Price is derived from toppings, size, and/or crust
        [Fact]//Price=(CrustAndSizeCost+ToppingCosts)
        public void CalculateCostTest()
        { }
    }
}

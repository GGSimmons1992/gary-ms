﻿using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class PizzaHelper
    {
        //private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static List<dom.Pizza> GetPizzas()
        {
            var _db = new PizzaStoreDbContext();
            var ls = new List<dom.Pizza>();

            foreach (var l in _db.Pizza.ToList())
            {
                if (l.Active == true)
                {
                    var crust = _db.Crust.Where(c => c.CrustId == l.CrustId).FirstOrDefault();

                    if (crust == null)
                    {
                        crust = _db.Crust.Where(c => c.Name == "Regular").FirstOrDefault();
                        l.CrustId = crust.CrustId;
                    }

                    var newPizza = new dom.Pizza()
                    {
                        Id = (int)l.PizzaId
                        ,
                        OrderId = (int)l.OrderId
                        ,
                        ModifiedDate = l.ModifiedDate
                        ,
                        crustSize = (int)l.Size
                        ,
                        CrustFactor = (double)crust.CrustId
                        ,
                        CrustId = (byte)l.CrustId
                    };
                    ls.Add(newPizza);
                }
                
            }

            return ls;
        }

        public static List<string> GetIngredientsByPizza(Pizza dp)
        {
            var toppings = new List<string>();

            var _db = new PizzaStoreDbContext();
            var piPairs = _db.PizzaIngredient.Where(pi => pi.PizzaId == dp.PizzaId).ToList();

            if (piPairs != null)
            {
                foreach (var item in piPairs)
                {
                    if (item.Active == true)
                    {
                        var myingredient = _db.Ingredient.Where(i => i.IngredientId == item.IngredientId).FirstOrDefault();
                        { toppings.Add(myingredient.Name); }
                    }
                    
                }
            }
                
            return toppings;
        }

        public static double GetPriceByPizza(Pizza dp)
        {
            var toppings=GetIngredientsByPizza(dp);
            var factor =(double) GetFactorByCrustID(dp.CrustId);
            return (double)((factor*dp.Size) + (0.50*toppings.Count));
        }

        public static double GetFactorByCrustID(short? crustid)
        {
            var _db = new PizzaStoreDbContext();
            var crust = _db.Crust.Where(c=>c.CrustId == crustid).FirstOrDefault();
            if (crust == null)
            {
                crust= _db.Crust.Where(c => c.Name== "Regular").FirstOrDefault();
            }

            return (double) crust.CrustFactor;
        }

        public static string GetCrustNameByPizza(Pizza dp)
        {
            var _db = new PizzaStoreDbContext();
            var crust = _db.Crust.Where(c => c.CrustId == dp.CrustId).FirstOrDefault();
            return crust.Name;
        }

        public static string GetCrustNameByPizza(dom.Pizza p)
        {
            var _db = new PizzaStoreDbContext();
            var crust = _db.Crust.Where(c => c.CrustId == p.CrustId).FirstOrDefault();

            if (crust == null)
            {
                crust= _db.Crust.Where(c => c.Name == "Regular").FirstOrDefault();
                p.CrustId =crust.CrustId;
                p.CrustFactor= (double) crust.CrustFactor;
            }

            return crust.Name;
        }

        public static int PizzaSetter(dom.Pizza p)
        {
            var _db = new PizzaStoreDbContext();
            var myOrder = _db.Order.Where(o => o.OrderId == p.OrderId).FirstOrDefault();
            var myCrust = _db.Crust.Where(c => c.CrustId == p.CrustId).FirstOrDefault();

            if (myCrust == null)
            {
                var DefaultCrust= _db.Crust.Where(c => c.Name == "Regular").FirstOrDefault();
                p.CrustId = DefaultCrust.CrustId;
                p.CrustFactor = (double) DefaultCrust.CrustFactor;
            }

            if (myOrder == null)
            {
                return 0;
            }
            else
            {
                var dataPizza = new Pizza()
                {
                    OrderId = p.OrderId,
                    ModifiedDate = DateTime.Now,
                    Price = (decimal) p.CalculateCost(),
                    Size=(byte)p.crustSize,
                    CrustId=(byte) p.CrustId,
                };

                _db.Pizza.Add(dataPizza);

                var pizzaAdditions = _db.SaveChanges();

                var fullPizzaList = GetPizzas();
                var lastPizza = fullPizzaList[fullPizzaList.Count - 1];
                var lastPizzaID = lastPizza.Id;
                SetPizzaIngredientByIds(p,lastPizzaID);

                return pizzaAdditions;
            }
        }

        public static void SetPizzaIngredientByIds(dom.Pizza p,int lastID)
        {
            foreach (var top in p.Toppings)
            {
                var _db = new PizzaStoreDbContext();
                var topping = _db.Ingredient.Where(i => (i.Name).ToLower() == top.ToLower()).FirstOrDefault();
                if (topping != null)
                {
                    var pipair = new PizzaIngredient() { PizzaId = lastID, IngredientId = topping.IngredientId };
                    _db.PizzaIngredient.Add(pipair);
                    _db.SaveChanges();
                }
            }
        }
    }
}

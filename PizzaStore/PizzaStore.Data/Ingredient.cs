﻿using System;
using System.Collections.Generic;

namespace PizzaStore.Data
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            InventoryIngredient = new HashSet<InventoryIngredient>();
            PizzaIngredient = new HashSet<PizzaIngredient>();
        }

        public short IngredientId { get; set; }
        public string Name { get; set; }
        public int? InventoryAmount { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<InventoryIngredient> InventoryIngredient { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}

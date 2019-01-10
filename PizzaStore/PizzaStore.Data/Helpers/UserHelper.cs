﻿using PizzaStore.Data.Models;
using dom = PizzaStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Data.Helpers
{
    public static class UserHelper
    {
        private static PizzaStoreDbContext _db = new PizzaStoreDbContext();

        public static dom.User DOMUser(User dataUser)
        {
            return new dom.User()
            {
                name=dataUser.Name
                ,password=dataUser.Password
                ,Id=dataUser.UserId
                ,ModifiedDate=dataUser.ModifiedDate
            };
        }

    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dm=MovieNight.Domain.Models;

namespace MovieNight.Code.Helpers
{
    public class UserHelper
    {
        private MovieDayDBContext _db = new MovieDayDBContext();

        public int SetUser(dm.User u)
        {
            _db.Users.Add(u);
            return _db.SaveChanges();
        }

        public List<dm.User> GetUser()
        {
            var users = _db.Users.FromSql("select * from users");
            var query = (from u in _db.Users select u).ToList();

            return _db.Users.Include(m=>m.Name).ToList();//include are the joins between tables
        }
        
    }
}

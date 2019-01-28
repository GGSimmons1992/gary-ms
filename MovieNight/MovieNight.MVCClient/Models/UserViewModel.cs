using MovieNight.Code.Helpers;
using MovieNight.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieNight.MVCClient.Models
{
    public class UserViewModel
    {
        private UserHelper _helper = new UserHelper();
        public List<User> Users { get; set; }

        public UserViewModel()
        {
            Users = _helper.GetUser();
        }
    }
}

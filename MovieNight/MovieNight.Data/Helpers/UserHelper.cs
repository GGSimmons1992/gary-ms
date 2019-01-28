using AutoMapper;
using MovieNight.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dm = MovieNight.Domain.Models;

namespace MovieNight.Data.Helpers
{
    public class UserHelper
    {
        private MovieNightDbContext _db =new MovieNightDbContext();

        MapperConfiguration userMap = new MapperConfiguration(mc =>
        mc.CreateMap<User, dm.User>()
        .ForMember(m => m.Id, u => u.MapFrom(s => s.UserId))
        .ForMember(m => m.Name, u => u.MapFrom(src => DomainHelper.nameMapper))
        .ForMember(m => m.Address,u=>u.MapFrom(src => DomainHelper.addressMapper))
        .ForAllOtherMembers(m=>m.Ignore()));

        public List<dm.User> GetUser()
        {
            var userlist = new List<dm.User>();
            var mapper = userMap.CreateMapper();
            var mapper2 = DomainHelper.nameMapper.CreateMapper();

            foreach (var item in _db.User.ToList())
            {
                var u = mapper.Map<dm.User>(item);

                u.Name = mapper2.Map<dm.Name>(item);
                userlist.Add(u);
            }

            return userlist;
        }
        
    }
}

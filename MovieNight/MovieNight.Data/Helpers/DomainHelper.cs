using AutoMapper;
using MovieNight.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using dm = MovieNight.Domain.Models;

namespace MovieNight.Data.Helpers
{
    public static class DomainHelper
    {
        public static MapperConfiguration addressMapper = new MapperConfiguration(mc => 
        mc.CreateMap <Address, dm.Address>()
        .ForMember(m=>m.Id,u=>u.MapFrom(src=>src.AddressId))
        .ForMember(m=>m.Country.Name,u=>u.MapFrom(src=>src.Country))
        .ForMember(m=>m.Country.Code, u=>u.MapFrom(src=>countryMapper)));

        public static MapperConfiguration nameMapper = new MapperConfiguration(mc =>
       mc.CreateMap<User, dm.Name>()
       .ForPath(m => m.Prefix.Name, u => u.MapFrom(src => src.Prefix))
       .ForMember(m => m.First, u => u.MapFrom(src => src.First))
       .ForMember(m => m.Last, u => u.MapFrom(src => src.Last)));

        public static MapperConfiguration countryMapper = new MapperConfiguration(mc =>
        mc.CreateMap<Address, dm.Country>()
        );//.ForMember(m=>m.,u=>u.MapFrom(src=>src.)))

    }
}

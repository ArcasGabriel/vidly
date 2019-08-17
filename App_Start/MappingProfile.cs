using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.IdentiyConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            // Movie
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Genre, GenreDto>();

            // Rental
            Mapper.CreateMap<Rental, NewRentalDto>();
            Mapper.CreateMap<NewRentalDto, Rental>().ForMember(m=>m.Id, opt=> opt.Ignore());

        }
    }
}
using Application.DTOs;
using Application.Entities;
using AutoMapper;

namespace Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}

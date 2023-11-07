using Application.DTOs;
using Application.Entities;
using Application.Requests;
using AutoMapper;

namespace Application.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomersRequest, Customer>();
        }
    }
}

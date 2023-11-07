using Application.DTOs;
using Application.Entities;
using Application.Requests;

namespace Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAll();

        Customer Add(Customer request);

        Task<List<CustomerDTO>> Get(CustomersQueryRequest request);
    }
}

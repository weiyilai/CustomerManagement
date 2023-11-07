using Application.DTOs;
using Application.Entities;

namespace Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAll();

        Customer Add(Customer request);
    }
}

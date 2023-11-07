using Application.DTOs;
using Application.Entities;
using Application.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            ILogger<CustomerService> logger,
            ICustomerRepository customerRepository,
            IMapper mapper
            )
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
            List<Customer> entity = await _customerRepository.GetAllAsync<Customer>();

            return _mapper.Map<List<CustomerDTO>>( entity );
        }
    }
}

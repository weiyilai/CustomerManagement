using Application.DTOs;
using Application.Entities;
using Application.Requests;
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

        public Customer Add(Customer request)
        {
            return _customerRepository.Add( request );
        }

        public async Task<List<CustomerDTO>> Get(CustomersQueryRequest request)
        {
            var entities = _customerRepository.GetQueryableAsync<Customer>(t => true);
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                entities = entities.Where(t => t.Name.Contains(request.Name));
            }
            if (request.StartAge.HasValue && request.EndAge.HasValue)
            {
                entities = entities.Where(t => t.Age >= request.StartAge && t.Age <= request.EndAge);
            }
            if (!string.IsNullOrWhiteSpace(request.Gender))
            {
                entities = entities.Where(t => t.Gender == request.Gender);
            }

            var customersPaging =
                await PaginatedList<Customer>.CreateAsync(
                    entities,
                    request.Paging.PageIndex ?? 1,
                    request.Paging.PageSize
                    );
            var customers = _mapper.Map<List<CustomerDTO>>(customersPaging);
            return customers;
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
            List<Customer> entity = await _customerRepository.GetAllAsync<Customer>();
            return _mapper.Map<List<CustomerDTO>>( entity );
        }

        public async Task<List<StatisticsDTO>> Statistics()
        {
            List<Customer> entity = await _customerRepository.GetAllAsync<Customer>();
            var customerGroup = entity
                .GroupBy(g => new { g.CityName, g.Gender })
                .Select(t => new StatisticsDTO
                {
                    CityName = t.Key.CityName,
                    Gender = t.Key.Gender,
                    Total = t.Count()
                });

            return customerGroup.ToList();
        }
    }
}

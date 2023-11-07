using Application.Entities;
using Application.Requests;
using Application.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerService customerService,
            IMapper mapper
            )
        {
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetAll());
        }

        // GET api/<CustomersController>/5
        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomersQueryRequest request)
        {
            return Ok(await _customerService.Get(request));
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomersRequest request)
        {
            CustomersRequestValidator validations = new();
            var result = validations.Validate(request);
            if (!result.IsValid) 
            {
                var errorMessage = result.Errors.Select(result => result.ErrorMessage);
                return BadRequest(errorMessage);
            }

            var customer = _mapper.Map<Customer>(request);
            var entity = _customerService.Add(customer);

            return Created($"/customers/{entity.Id}", entity);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string value)
        {
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}

﻿using Application.Services.Interfaces;
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

        public CustomersController(
            ILogger<CustomersController> logger,
            ICustomerService customerService
            )
        {
            _logger = logger;
            _customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customerService.GetAll());
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Created("", nameof(value));
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

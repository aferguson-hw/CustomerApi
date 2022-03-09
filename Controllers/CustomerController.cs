using CustomerApi.DTOs;
using CustomerApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private List<Customer> _customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Steve", LastName = "Stevenson" },
            new Customer { Id = 2, FirstName = "John", LastName = "Johnson" },
            new Customer { Id = 3, FirstName = "Dan", LastName = "Danielson" }
        };

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer([FromBody] NewCustomerDto newCustomer)
        {
            var customerId = _customers.Max(c => c.Id) + 1;
            var customer = new Customer { Id = customerId, FirstName = newCustomer.FirstName, LastName = newCustomer.LastName };
            _customers.Add(customer);
            return Ok(_customers);
        }
    }
}

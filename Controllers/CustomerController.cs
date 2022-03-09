using CustomerApi.DTOs;
using CustomerApi.Entities;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Fetches all Customers
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        /// GET /Customer/GetCustomers
        /// </remarks>
        /// <response code="200">Returns a collection of all customers</response>
        /// <returns>A list of all customers</returns>
        [HttpGet]
        [Route("GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return Ok(_customers);
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// 
        /// POST /Customer/CreateNewCustomer
        /// {
        ///     "firstName": "Old",
        ///     "lastName": "Greg"
        /// }
        /// </remarks>
        /// <response code="200">Returns a collection of all customers including the newly created customer</response>
        /// <param name="newCustomer">The customer first and last name</param>
        /// <returns>A list of all customers</returns>
        [HttpPost]
        [Route("CreateNewCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNewCustomer([FromBody] NewCustomerDto newCustomer)
        {
            var customerId = _customers.Max(c => c.Id) + 1;
            var customer = new Customer { Id = customerId, FirstName = newCustomer.FirstName, LastName = newCustomer.LastName };
            _customers.Add(customer);
            return Ok(_customers);
        }
    }
}

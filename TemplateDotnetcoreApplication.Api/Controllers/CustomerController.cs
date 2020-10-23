using Microsoft.AspNetCore.Mvc;
using TemplateDotnetcoreApplication.Domain.Repositories;

namespace TemplateDotnetcoreApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerRepository.GetAll());
        }
    }
}

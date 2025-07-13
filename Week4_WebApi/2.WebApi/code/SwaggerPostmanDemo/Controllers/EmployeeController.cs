using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SwaggerPostmanDemo.Controllers
{
    [ApiController]
    [Route("Emp")] // custom route instead of default "Employee"
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetEmployees()
        {
            var employees = new List<string> { "John", "Jane", "Bob" };
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddEmployee([FromBody] string name)
        {
            return Ok($"Added: {name}");
        }
    }
}

using EmployeeFilterDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EmployeeFilterDemo.Filters;


namespace EmployeeFilterDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 1, 1)
                }
            };
        }

        [HttpGet("standard")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> GetStandard()
        {
            // Uncomment below line to simulate error:
            // throw new Exception("Simulated error");
            return Ok(GetStandardEmployeeList());
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            return Ok($"Employee added: {employee.Name}");
        }
    }
}

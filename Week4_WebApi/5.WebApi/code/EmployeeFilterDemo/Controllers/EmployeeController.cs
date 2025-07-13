using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeFilterDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeFilterDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] // 🔐 Secures this controller for JWT with Admin role
    public class EmployeeController : ControllerBase
    {
        // 🔸 Hardcoded employee list acting as mock DB
        private static List<Employee> employeeList = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "John",
                Salary = 50000,
                Permanent = true,
                Department = new Department { Id = 1, Name = "HR" },
                Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } },
                DateOfBirth = new DateTime(1990, 1, 1)
            },
            new Employee
            {
                Id = 2,
                Name = "Jane",
                Salary = 60000,
                Permanent = false,
                Department = new Department { Id = 2, Name = "IT" },
                Skills = new List<Skill> { new Skill { Id = 2, Name = "Java" } },
                DateOfBirth = new DateTime(1992, 5, 15)
            }
        };

        // 🔹 GET method to return employees (secured)
        [HttpGet("standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employeeList);
        }

        // 🔹 POST method to add a new employee
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employeeList.Add(employee);
            return Ok($"Employee added: {employee.Name}");
        }

        // 🔹 PUT method to update employee details
        [HttpPut]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            if (updatedEmployee.Id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = employeeList.FirstOrDefault(e => e.Id == updatedEmployee.Id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.Permanent = updatedEmployee.Permanent;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Skills = updatedEmployee.Skills;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

            return Ok(existingEmployee);
        }
    }
}

using FirstApi.DAL;
using FirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();

            if (employees is null)
                return NotFound();

            return Ok(employees);
        }

        [HttpGet]
        [Route ("{id}")]
        public ActionResult GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, [FromBody] Employee employee)
        {
            var employeeDb = _context.Employees.FirstOrDefault(m => m.Id == id);

            if (employeeDb is null)
                return NotFound();

            employee.Id = employeeDb.Id;
            employeeDb.FullName = employee.FullName;
            employeeDb.Age = employee.Age;
            employeeDb.Address = employee.Address;

            _context.SaveChanges();

            return Ok(employee);

        }

        

    }
}

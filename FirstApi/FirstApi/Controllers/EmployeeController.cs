using FirstApi.DAL;
using FirstApi.DTO;
using FirstApi.Models;
using FirstApi.Service.Interface;
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
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet]
        [Route ("{id}")]
        public ActionResult GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _employeeService.Create(employee);

            return Ok();
        }

        [HttpPut]
        [Route ("{id}")]
        public ActionResult Edit(int id, [FromBody] EmployeeDTO employee)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_employeeService.Edit(id, employee));
            
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_employeeService.Delete(id));
        }


    }
}

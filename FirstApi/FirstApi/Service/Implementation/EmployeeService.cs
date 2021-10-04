using AutoMapper;
using FirstApi.DAL;
using FirstApi.DTO;
using FirstApi.Models;
using FirstApi.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace FirstApi.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(EmployeeDTO employee)
        {
            var newEmployee = _mapper.Map<Employee>(employee);
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }

        public EmployeeDTO Delete(int id)
        {
            var employeeDb = _context.Employees.FirstOrDefault(m => m.Id == id);

            if (employeeDb is null)
                return null;

            _context.Employees.Remove(employeeDb);
            _context.SaveChanges();

            return _mapper.Map<EmployeeDTO>(employeeDb);
        }

        public EmployeeDTO Edit(int id, EmployeeDTO employee)
        {
            var employeeDb = _context.Employees.FirstOrDefault(m => m.Id == id);

            if (employeeDb is null)
                return null;

            employee.Id = employeeDb.Id;

            _mapper.Map(employee, employeeDb);

            _context.SaveChanges();

            return employee;
               

        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();

            return _mapper.Map<List<EmployeeDTO>>(employees);
            
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employeeDb = _context.Employees.FirstOrDefault(m => m.Id == id);
            if (employeeDb == null)
                return null;

            return _mapper.Map<EmployeeDTO>(employeeDb);
        }
    }
}

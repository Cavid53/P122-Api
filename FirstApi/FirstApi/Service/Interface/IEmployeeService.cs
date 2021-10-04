using FirstApi.DTO;
using System.Collections.Generic;

namespace FirstApi.Service.Interface
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);

        void Create(EmployeeDTO employee);
        EmployeeDTO Edit(int id, EmployeeDTO employee);

        EmployeeDTO Delete(int id);
    }
}

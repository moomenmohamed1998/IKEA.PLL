using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.DTO_s.Department;
using IKEA.BLL.DTO_s.Employees;

namespace IKEA.BLL.Services.EmploessServices
{
    public interface IEmploteeservices
    {
        IEnumerable<EmployeeDto> GetAllEmpoyees();


        EmployeeDetailsDto? GetEmployeeById(int id);
        int createEmployee(CreatedEmployeeDto employeeDto);

        int UpdateDepartment(UpdatedEmployeeDto employeeDto);

        bool DeleteEmployee(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.DTO_s.Department;
//using IKEA.DAL.Models.Departments;

namespace IKEA.BLL.Services.DepartmentsServices
{
    public interface IDepartmentsServices
    {
        IEnumerable<DepartmentDto> GetALLDepartments();

        
        DepartmentDetailsDto? GetALLDepartmentById(int id);
        int CreateDepartment(CreateDepartmentDto departmentDto);

        int UpdateDepartment(int id, UpdatedDepartmentDto departmentDto);
        
        bool DeleteDepartment(int id);
        int UpdateDepartment(UpdatedDepartmentDto departmentDto);
    }
}

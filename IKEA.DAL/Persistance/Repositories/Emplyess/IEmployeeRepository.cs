using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Repositories._Grneric;

namespace IKEA.DAL.Persistance.Repositories.Emplyess
{
   public interface IEmployeeRepository:IGenaricRepository<Employee>
    {
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;

namespace IKEA.DAL.Persistance.Repositories.Departments
{
   public interface IDepartmentRepository
    {

        IEnumerable<Department> GetAll(bool withTracking=true);
        Department? GetById(int id);
        int Add(Department department);
        int update(Department department);
        int Delete(Department department);

    }
}

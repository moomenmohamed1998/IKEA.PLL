using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Persistance.Repositories.Departments;

namespace IKEA.BLL.Services.DepartmentsServices
{
  public  class DepartmentsServices: IDepartmentsServices
    {

        private IDepartmentRepository Repository;

        public DepartmentsServices(IDepartmentRepository _repositoryc)
        {
            //departmentRepository = new DepartmentRepository();
            Repository = _repositoryc;


        }
    }
}

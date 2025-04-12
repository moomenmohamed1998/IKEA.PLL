using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Repositories._Grneric;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Persistance.Repositories.Emplyess
{
    public class EmployeeRepository :GenaricRepository<Employee>, IEmployeeRepository
    {


        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            dbContext = context;
        }


    }
}

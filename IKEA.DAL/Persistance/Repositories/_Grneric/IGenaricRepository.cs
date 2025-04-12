using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;

namespace IKEA.DAL.Persistance.Repositories._Grneric
{
    public interface IGenaricRepository<T> where T:ModelBase
    {
        IEnumerable<T> GetAll(bool withTracking = true);
        T? GetById(int id);
        int Add(T entity);
        int update(T entity);
        int Delete(T entity);
       
    }
}

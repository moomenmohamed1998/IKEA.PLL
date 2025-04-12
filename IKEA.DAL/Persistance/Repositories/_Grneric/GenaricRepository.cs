using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Persistance.Repositories._Grneric
{
    public class GenaricRepository<T>:IGenaricRepository<T> where T : ModelBase
    {
        private readonly ApplicationDbContext dbContext;

        public GenaricRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public int Add(T item)
        {
            dbContext.Set<T>().Add(item);
            return dbContext.SaveChanges();
        }
        public int Delete(T item)
        {
            item.IsDeleted = true;
            dbContext.Set<T>().Update(item);
            return dbContext.SaveChanges();
        }
        public IEnumerable<T> GetAll(bool withTracking = true)
        {
            if (withTracking)
            {
                return dbContext.Set<T>().Where(D => D.IsDeleted == false).AsNoTracking().ToList();
            }
            return dbContext.Set<T>().Where(D => D.IsDeleted == false).ToList();
        }
        public T? GetById(int id)
        {

            var item = dbContext.Set<T>().Find(id);

            //var Department = dbContext.Departments.Local.FirstOrDefault(D => D.Id == id);
            //if (Department is null)
            //{ Department = dbContext.Departments.FirstOrDefault(D => D.Id == id); }

            return item;
        }
        public int update(T item)
        {
            dbContext.Set<T>().Update(item);
            return dbContext.SaveChanges();
        }
    }
}

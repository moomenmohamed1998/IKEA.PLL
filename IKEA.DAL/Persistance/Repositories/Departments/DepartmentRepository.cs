﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Repositories._Grneric;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Persistance.Repositories.Departments
{
    public class DepartmentRepository :GenaricRepository<Department>,IDepartmentRepository
    {

        private readonly ApplicationDbContext dbContext;

        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            dbContext = context;
        }


    }
}

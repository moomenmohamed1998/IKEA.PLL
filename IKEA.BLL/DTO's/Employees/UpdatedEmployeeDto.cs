﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;

namespace IKEA.BLL.DTO_s.Employees
{
  public  class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public Decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumper { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}

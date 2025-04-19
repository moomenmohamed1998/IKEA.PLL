﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;

namespace IKEA.BLL.DTO_s.Employees
{
  public  class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public Decimal? Salary { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }
        public Gender Gender { get; set; } 
        public EmployeeType EmployeeType { get; set; } 

    }
}

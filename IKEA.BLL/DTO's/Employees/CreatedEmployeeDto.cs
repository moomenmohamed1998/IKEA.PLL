using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;

namespace IKEA.BLL.DTO_s.Employees
{
  public  class CreatedEmployeeDto
    {
        [MaxLength(50,ErrorMessage =" max lenth of Name is 50 chars")]
        [MinLength(5, ErrorMessage = " min lenth of Name is 5 chars")]
        public string Name { get; set; }
        [Range(22,30)]
        public int? Age { get; set; }
        public string? Address { get; set; }
        public Decimal? Salary { get; set; }
        [Display(Name="Is active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "PhoneNumper")]
        [Phone]
        public string? PhoneNumper { get; set; }
        [Display(Name = "HiringDate")]

        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}

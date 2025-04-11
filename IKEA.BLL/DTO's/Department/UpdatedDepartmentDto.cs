using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Department
{
  public  class UpdatedDepartmentDto
    {
        public int id { get; set; }
        [Required(ErrorMessage= "The Name is Required ")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The Cpde is Required ")]

        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date of creation")]
        public DateTime CreationDate { get; set; }  
    }
}

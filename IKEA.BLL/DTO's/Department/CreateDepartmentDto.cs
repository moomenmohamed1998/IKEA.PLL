using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Department
{
   public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Code is Required !! ")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Code is Required !! ")]
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name ="Date Of Creation")]
        public DateTime CreationDate { get; set; }
    }
}

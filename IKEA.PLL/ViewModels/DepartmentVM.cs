using System.ComponentModel.DataAnnotations;

namespace IKEA.PLL.ViewModels
{
    public class DepartmentVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The Name is Required ")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The Cpde is Required ")]

        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date of creation")]
        public DateTime CreationDate { get; set; }

    }
}

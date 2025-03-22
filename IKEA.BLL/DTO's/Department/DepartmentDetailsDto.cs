using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTO_s.Department
{
    public class DepartmentDetailsDto
    {
        public int id { get; set; }

        #region Administritor

        public bool IsDeleted { get; set; }
        public int createdBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public int LastModifiedOn { get; set; }

        #endregion

        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

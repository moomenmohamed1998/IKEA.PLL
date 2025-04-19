using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace IKEA.DAL.Models
{
    public class ModelBase
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int createdBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedon { get; set; }
    }

}

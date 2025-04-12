using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Persistance.Data.Configurations.DpartmentConfigurations
{
   public class DpartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(D => D.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(D => D.LastModifiedon).HasDefaultValueSql("GetDate()");


        }
    }
}

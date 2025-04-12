using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;
using IKEA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IKEA.DAL.Persistance.Data.Configurations.EmployeeConfinguations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(E => E.Address).HasColumnType("nvarchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");


            builder.Property(E => E.Gender).HasConversion(
                    g => g.ToString(),
                    g => (Gender)Enum.Parse(typeof(Gender), g)
                );

            builder.Property(E => E.EmployeeType).HasConversion(
                    t => t.ToString(),
                    t => (EmployeeType)Enum.Parse(typeof(EmployeeType), t)
                );


            builder.Property(D => D.CreatedOn)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(D => D.LastModifiedon)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }

}

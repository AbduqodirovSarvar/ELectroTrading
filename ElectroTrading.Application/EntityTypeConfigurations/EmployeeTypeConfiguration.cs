using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.EntityTypeConfigurations
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Phone).IsUnique();
            builder.HasMany(x => x.Attendances).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            builder.HasMany(x => x.EmployeeDebts).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
            builder.HasMany(x => x.PaymentSalarys).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId);
        }
    }
}

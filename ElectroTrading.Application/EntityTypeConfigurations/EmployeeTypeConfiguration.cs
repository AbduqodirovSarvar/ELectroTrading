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
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.EmployeeId).IsUnique();
            builder.HasMany(x => x.Attendances).WithOne(x => x.Master).HasForeignKey(x => x.EmployeeId);
            builder.HasMany(x => x.EmployeeDebts).WithOne(x => x.Master).HasForeignKey(x => x.EmployeeId);
            builder.HasMany(x => x.PaymentSalarys).WithOne(x => x.Master).HasForeignKey(x => x.EmployeeId);
        }
    }
}

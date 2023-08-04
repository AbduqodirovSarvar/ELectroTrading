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
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(bs => bs.BoughtAndSoldProducts).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(fp => fp.FinishedProducts).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(o => o.Orders).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(Pc => Pc.Compositions).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
            builder.HasMany(s => s.Storages).WithOne(p => p.Product).HasForeignKey(x => x.ProductId);
        }
    }
}

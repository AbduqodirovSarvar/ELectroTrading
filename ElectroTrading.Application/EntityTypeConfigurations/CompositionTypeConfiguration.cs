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
    public class CompositionTypeConfiguration : IEntityTypeConfiguration<ProductComposition>
    {
        public void Configure(EntityTypeBuilder<ProductComposition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ProductId).IsUnique();
        }
    }
}

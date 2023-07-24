using ElectroTrading.Application.Abstractions;
using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Infrastructure.DbContexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDebt> EmployeesDebts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PaymentSalary> PaymentSalaries { get; set; }
        public DbSet<BoughtAndSoldProduct> BoughtAndSoldsProducts { get; set; }
        public DbSet<FinishedProduct> FinishedProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComposition> ProductCompositions { get; set; }
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<ProductComposition>()
                .HasKey(pc => pc.Id);

            modelBuilder.Entity<ProductComposition>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Compositions)
                .HasForeignKey(pc => pc.ProductId);
            /*.OnDelete(DeleteBehavior.Restrict);*/

            modelBuilder.Entity<ProductComposition>()
                .HasOne(pc => pc.Composition)
                .WithMany()
                .HasForeignKey(pc => pc.CompositionId);
                /*.OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}

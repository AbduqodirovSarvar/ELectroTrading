using ElectroTrading.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroTrading.Application.Abstractions
{
    public interface IAppDbContext
    {
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

        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}

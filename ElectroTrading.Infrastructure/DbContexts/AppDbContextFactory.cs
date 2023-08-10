using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ElectroTrading.Infrastructure.DbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /*private readonly IConfiguration _configuration;*/
        public AppDbContextFactory()
        {

        }
        /*public AppDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }*/
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ElectroTrading;User Id=postgres;Password=12345");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
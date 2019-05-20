using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace RealEstateManager.Database
{
    public class RealEstateContextFactory : IDesignTimeDbContextFactory<RealEstateContext>
    {
        public RealEstateContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            var builder = new DbContextOptionsBuilder<RealEstateContext>();
           // var connectionString = configuration.GetConnectionString("RealEstateDb");
            builder.UseSqlServer("Data Source=.;Initial Catalog=GraphQL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new RealEstateContext(builder.Options);
        }
    }
}

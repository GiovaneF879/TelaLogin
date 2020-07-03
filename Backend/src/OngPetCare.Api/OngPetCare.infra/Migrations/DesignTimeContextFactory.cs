using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OngPetCare.infra.Context;
using System.IO;

namespace OngPetCare.infra.Migrations
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()


            .SetBasePath(Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "Migrations")))
                .AddJsonFile("appsettings.migrations.json", optional: false);

            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection")
                        , opt => opt.MigrationsAssembly("OngPetCare.infra"))
                .EnableSensitiveDataLogging();

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}

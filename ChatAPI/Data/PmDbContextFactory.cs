using ChatAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class PmDbContextFactory : IDesignTimeDbContextFactory<PmDbContext>
{
    public PmDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<PmDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new PmDbContext(optionsBuilder.Options);
    }
}


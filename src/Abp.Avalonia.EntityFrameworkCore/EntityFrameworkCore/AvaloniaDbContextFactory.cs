using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Abp.Avalonia.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AvaloniaDbContextFactory : IDesignTimeDbContextFactory<AvaloniaDbContext>
{
    public AvaloniaDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AvaloniaEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AvaloniaDbContext>()
            .UseSqlite(configuration.GetConnectionString("Default"));
        
        return new AvaloniaDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Abp.Avalonia.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}

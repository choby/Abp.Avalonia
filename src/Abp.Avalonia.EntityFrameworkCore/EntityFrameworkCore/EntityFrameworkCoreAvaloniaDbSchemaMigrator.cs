using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Abp.Avalonia.Data;
using Volo.Abp.DependencyInjection;

namespace Abp.Avalonia.EntityFrameworkCore;

public class EntityFrameworkCoreAvaloniaDbSchemaMigrator
    : IAvaloniaDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAvaloniaDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AvaloniaDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AvaloniaDbContext>()
            .Database
            .MigrateAsync();
    }
}

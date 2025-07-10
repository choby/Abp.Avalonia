using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Abp.Avalonia.Data;

/* This is used if database provider does't define
 * IAvaloniaDbSchemaMigrator implementation.
 */
public class NullAvaloniaDbSchemaMigrator : IAvaloniaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

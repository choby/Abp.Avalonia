using System.Threading.Tasks;

namespace Abp.Avalonia.Data;

public interface IAvaloniaDbSchemaMigrator
{
    Task MigrateAsync();
}

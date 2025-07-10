using Abp.Avalonia.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Avalonia.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AvaloniaEntityFrameworkCoreModule),
    typeof(AvaloniaApplicationContractsModule)
)]
public class AvaloniaDbMigratorModule : AbpModule
{
}

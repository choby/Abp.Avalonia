using Volo.Abp.Modularity;

namespace Abp.Avalonia;

[DependsOn(
    typeof(AvaloniaApplicationModule),
    typeof(AvaloniaDomainTestModule)
)]
public class AvaloniaApplicationTestModule : AbpModule
{

}

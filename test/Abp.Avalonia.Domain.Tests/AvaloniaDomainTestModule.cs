using Volo.Abp.Modularity;

namespace Abp.Avalonia;

[DependsOn(
    typeof(AvaloniaDomainModule),
    typeof(AvaloniaTestBaseModule)
)]
public class AvaloniaDomainTestModule : AbpModule
{

}

using Volo.Abp.Modularity;

namespace Abp.Avalonia;

public abstract class AvaloniaApplicationTestBase<TStartupModule> : AvaloniaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

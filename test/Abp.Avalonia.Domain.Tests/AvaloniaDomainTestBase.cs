using Volo.Abp.Modularity;

namespace Abp.Avalonia;

/* Inherit from this class for your domain layer tests. */
public abstract class AvaloniaDomainTestBase<TStartupModule> : AvaloniaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

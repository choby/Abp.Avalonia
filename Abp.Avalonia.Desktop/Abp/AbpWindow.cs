using Avalonia.Controls;
using Volo.Abp.DependencyInjection;

namespace Abp.Avalonia.Desktop.Abp;

public class AbpWindow : Window, ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;
}
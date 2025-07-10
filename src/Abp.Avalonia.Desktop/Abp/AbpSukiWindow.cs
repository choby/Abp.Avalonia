using SukiUI.Controls;
using Volo.Abp.DependencyInjection;

namespace Abp.Avalonia.Desktop.Abp;

public class AbpSukiWindow : SukiWindow, ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;
   
}
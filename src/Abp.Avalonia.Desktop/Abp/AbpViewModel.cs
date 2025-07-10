using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace Abp.Avalonia.Desktop.Abp;

public class AbpViewModel : ObservableObject, ITransientDependency
{
    public IAbpLazyServiceProvider LazyServiceProvider { get; set; } = default!;
    protected Type? ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));
}
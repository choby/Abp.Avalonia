using Volo.Abp;

namespace Abp.Avalonia.Desktop.Abp;

public interface IAbpApplication
{
    public IAbpApplicationWithInternalServiceProvider AbpApp { get; set; }
}
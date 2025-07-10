using Abp.Avalonia.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Avalonia;

/* Inherit your application services from this class.
 */
public abstract class AvaloniaAppService : ApplicationService
{
    protected AvaloniaAppService()
    {
        LocalizationResource = typeof(AvaloniaResource);
    }
}

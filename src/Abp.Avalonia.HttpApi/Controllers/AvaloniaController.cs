using Abp.Avalonia.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Avalonia.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AvaloniaController : AbpControllerBase
{
    protected AvaloniaController()
    {
        LocalizationResource = typeof(AvaloniaResource);
    }
}

using Abp.Avalonia.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Avalonia.Web.Pages;

public abstract class AvaloniaPageModel : AbpPageModel
{
    protected AvaloniaPageModel()
    {
        LocalizationResourceType = typeof(AvaloniaResource);
    }
}

using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Abp.Avalonia.Localization;

namespace Abp.Avalonia.Web;

[Dependency(ReplaceServices = true)]
public class AvaloniaBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AvaloniaResource> _localizer;

    public AvaloniaBrandingProvider(IStringLocalizer<AvaloniaResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}

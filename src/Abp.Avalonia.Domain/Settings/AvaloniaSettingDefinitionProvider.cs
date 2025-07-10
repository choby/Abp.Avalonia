using Volo.Abp.Settings;

namespace Abp.Avalonia.Settings;

public class AvaloniaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AvaloniaSettings.MySetting1));
    }
}

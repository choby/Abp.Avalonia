using Abp.Avalonia.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Abp.Avalonia.Permissions;

public class AvaloniaPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AvaloniaPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(AvaloniaPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AvaloniaResource>(name);
    }
}

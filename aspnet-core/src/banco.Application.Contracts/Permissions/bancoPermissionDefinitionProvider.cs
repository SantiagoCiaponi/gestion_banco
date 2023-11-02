using banco.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace banco.Permissions;

public class bancoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(bancoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(bancoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<bancoResource>(name);
    }
}

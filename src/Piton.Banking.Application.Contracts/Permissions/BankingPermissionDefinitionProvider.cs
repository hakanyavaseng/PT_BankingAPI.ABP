using Piton.Banking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Piton.Banking.Permissions;

public class BankingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BankingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BankingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BankingResource>(name);
    }
}

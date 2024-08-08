using Volo.Abp.Settings;

namespace Piton.Banking.Settings;

public class BankingSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BankingSettings.MySetting1));
    }
}

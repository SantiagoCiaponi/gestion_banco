using Volo.Abp.Settings;

namespace banco.Settings;

public class bancoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(bancoSettings.MySetting1));
    }
}

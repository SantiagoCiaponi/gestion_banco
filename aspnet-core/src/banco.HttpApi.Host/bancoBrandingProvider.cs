using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace banco;

[Dependency(ReplaceServices = true)]
public class bancoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "banco";
}

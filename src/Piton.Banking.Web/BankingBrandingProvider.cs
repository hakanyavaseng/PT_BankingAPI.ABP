using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Piton.Banking.Web;

[Dependency(ReplaceServices = true)]
public class BankingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Banking";
}

using Piton.Banking.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Piton.Banking.Web.Pages;

public abstract class BankingPageModel : AbpPageModel
{
    protected BankingPageModel()
    {
        LocalizationResourceType = typeof(BankingResource);
    }
}

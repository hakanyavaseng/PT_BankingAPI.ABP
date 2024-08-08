using Piton.Banking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Piton.Banking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BankingController : AbpControllerBase
{
    protected BankingController()
    {
        LocalizationResource = typeof(BankingResource);
    }
}

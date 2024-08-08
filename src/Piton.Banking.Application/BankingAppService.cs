using System;
using System.Collections.Generic;
using System.Text;
using Piton.Banking.Localization;
using Volo.Abp.Application.Services;

namespace Piton.Banking;

/* Inherit your application services from this class.
 */
public abstract class BankingAppService : ApplicationService
{
    protected BankingAppService()
    {
        LocalizationResource = typeof(BankingResource);
    }
}

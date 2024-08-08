using Volo.Abp.Modularity;

namespace Piton.Banking;

/* Inherit from this class for your domain layer tests. */
public abstract class BankingDomainTestBase<TStartupModule> : BankingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace Piton.Banking;

public abstract class BankingApplicationTestBase<TStartupModule> : BankingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

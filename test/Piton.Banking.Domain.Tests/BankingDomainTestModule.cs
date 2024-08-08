using Volo.Abp.Modularity;

namespace Piton.Banking;

[DependsOn(
    typeof(BankingDomainModule),
    typeof(BankingTestBaseModule)
)]
public class BankingDomainTestModule : AbpModule
{

}

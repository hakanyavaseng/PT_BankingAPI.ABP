using Volo.Abp.Modularity;

namespace Piton.Banking;

[DependsOn(
    typeof(BankingApplicationModule),
    typeof(BankingDomainTestModule)
)]
public class BankingApplicationTestModule : AbpModule
{

}

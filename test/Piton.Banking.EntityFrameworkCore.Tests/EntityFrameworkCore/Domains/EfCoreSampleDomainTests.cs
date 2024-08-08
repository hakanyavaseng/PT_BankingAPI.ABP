using Piton.Banking.Samples;
using Xunit;

namespace Piton.Banking.EntityFrameworkCore.Domains;

[Collection(BankingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BankingEntityFrameworkCoreTestModule>
{

}

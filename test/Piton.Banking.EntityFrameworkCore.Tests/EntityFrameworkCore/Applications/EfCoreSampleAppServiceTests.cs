using Piton.Banking.Samples;
using Xunit;

namespace Piton.Banking.EntityFrameworkCore.Applications;

[Collection(BankingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BankingEntityFrameworkCoreTestModule>
{

}

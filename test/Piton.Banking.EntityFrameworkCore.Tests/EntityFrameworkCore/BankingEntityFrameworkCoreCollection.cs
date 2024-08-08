using Xunit;

namespace Piton.Banking.EntityFrameworkCore;

[CollectionDefinition(BankingTestConsts.CollectionDefinitionName)]
public class BankingEntityFrameworkCoreCollection : ICollectionFixture<BankingEntityFrameworkCoreFixture>
{

}

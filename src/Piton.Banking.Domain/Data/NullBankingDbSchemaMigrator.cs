using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Piton.Banking.Data;

/* This is used if database provider does't define
 * IBankingDbSchemaMigrator implementation.
 */
public class NullBankingDbSchemaMigrator : IBankingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

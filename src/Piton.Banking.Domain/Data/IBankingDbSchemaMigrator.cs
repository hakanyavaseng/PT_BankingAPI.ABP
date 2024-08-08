using System.Threading.Tasks;

namespace Piton.Banking.Data;

public interface IBankingDbSchemaMigrator
{
    Task MigrateAsync();
}

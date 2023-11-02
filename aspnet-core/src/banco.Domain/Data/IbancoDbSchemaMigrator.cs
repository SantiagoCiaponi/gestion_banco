using System.Threading.Tasks;

namespace banco.Data;

public interface IbancoDbSchemaMigrator
{
    Task MigrateAsync();
}

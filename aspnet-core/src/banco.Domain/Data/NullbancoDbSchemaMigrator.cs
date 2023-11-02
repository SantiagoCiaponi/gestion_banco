using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace banco.Data;

/* This is used if database provider does't define
 * IbancoDbSchemaMigrator implementation.
 */
public class NullbancoDbSchemaMigrator : IbancoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

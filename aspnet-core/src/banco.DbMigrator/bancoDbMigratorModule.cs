using banco.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace banco.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(bancoEntityFrameworkCoreModule),
    typeof(bancoApplicationContractsModule)
    )]
public class bancoDbMigratorModule : AbpModule
{
}

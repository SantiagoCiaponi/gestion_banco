using banco.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace banco;

[DependsOn(
    typeof(bancoEntityFrameworkCoreTestModule)
    )]
public class bancoDomainTestModule : AbpModule
{

}

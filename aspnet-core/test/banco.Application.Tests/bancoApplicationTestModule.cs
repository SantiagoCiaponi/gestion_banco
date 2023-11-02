using Volo.Abp.Modularity;

namespace banco;

[DependsOn(
    typeof(bancoApplicationModule),
    typeof(bancoDomainTestModule)
    )]
public class bancoApplicationTestModule : AbpModule
{

}

using banco.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace banco.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class bancoController : AbpControllerBase
{
    protected bancoController()
    {
        LocalizationResource = typeof(bancoResource);
    }
}

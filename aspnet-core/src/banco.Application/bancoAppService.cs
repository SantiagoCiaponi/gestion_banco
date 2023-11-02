using System;
using System.Collections.Generic;
using System.Text;
using banco.Localization;
using Volo.Abp.Application.Services;

namespace banco;

/* Inherit your application services from this class.
 */
public abstract class bancoAppService : ApplicationService
{
    protected bancoAppService()
    {
        LocalizationResource = typeof(bancoResource);
    }
}

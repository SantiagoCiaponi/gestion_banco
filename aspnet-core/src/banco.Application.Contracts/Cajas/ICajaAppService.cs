using System.Collections.Generic;
using System.Threading.Tasks;
using banco.Egresos;
using banco.Ingresos;
using Volo.Abp.Application.Services;

namespace banco.Cajas;

public interface ICajaAppService : IApplicationService
{
    Task<ICollection<CajaDto>> GetCajaAsync();
    
    Task<CajaDto> GetCajaAsync(int id);

    Task<CajaDto> CreateCajaAsync(CrearCajasDto input);
    
    Task<IngresosDto> CreateNewIngresoAsync(CrearIngresosDto input);
    
    Task<EgresosDto> CreateNewEgresoAsync(CrearEgresosDto input);
    
    Task<CajaDto> UpdateCajaAsync(int id, CajaDto input);

    Task<CajaDto> DeleteCajaAsync(int id);
}
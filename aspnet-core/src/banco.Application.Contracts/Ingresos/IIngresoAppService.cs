using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace banco.Ingresos;

public interface IIngresoAppService : IApplicationService
{
    
    Task<ICollection<IngresosDto>> GetIngresosAsync();
    
    Task<IngresosDto> GetIngresoAsync(int id);

    Task<IngresosDto> CreateIngresoAsync(CrearIngresosDto input);
    
    Task<IngresosDto> UpdateIngresoAsync(int id, CrearIngresosDto input);

    Task<IngresosDto> DeleteIngresoAsync(int id);
    
}
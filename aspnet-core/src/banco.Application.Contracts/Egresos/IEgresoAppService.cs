using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace banco.Egresos;

public interface IEgresoAppService: IApplicationService
{
    Task<ICollection<EgresosDto>> GetIEgresoAsync();
    
    Task<EgresosDto> GetEgresoAsync(int id);

    Task<EgresosDto> CreateEgresoAsync(CrearEgresosDto input);
    
    Task<EgresosDto> UpdateEgresoAsync(int id, CrearEgresosDto input);

    Task<EgresosDto> DeleteEgresoAsync(int id);
}
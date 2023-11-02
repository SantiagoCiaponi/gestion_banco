using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banco.Cajas;
using Volo.Abp.Domain.Repositories;
using static banco.Cajas.CajaAppService;

namespace banco.Ingresos;

public class IngresoAppService : bancoAppService, IIngresoAppService
{
    private readonly IRepository<Ingreso, int> _repository;
    
    public IngresoAppService(IRepository<Ingreso, int> repository)
    {
        _repository = repository;
    }
    
    
    public async Task<ICollection<IngresosDto>> GetIngresosAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<IngresosDto> GetIngresoAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IngresosDto> CreateIngresoAsync(CrearIngresosDto input)
    {
        var ingreso = new Ingreso
        {
            valor = input.valor,
            fecha = input.fecha,
            CajaId = input.CajaId
        };

        await _repository.InsertAsync(ingreso);
        
        return ObjectMapper.Map<Ingreso, IngresosDto>(ingreso);

    }

    public async Task<IngresosDto> UpdateIngresoAsync(int id, CrearIngresosDto input)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IngresosDto> DeleteIngresoAsync(int id)
    {
        throw new System.NotImplementedException();
    }
    
    
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using banco.Egresos;
using banco.Ingresos;
using Volo.Abp.Domain.Repositories;

namespace banco.Cajas;

public class CajaAppService: bancoAppService, ICajaAppService
{
    
    private readonly IRepository<Caja, int> _repository;
    
    private readonly IRepository<Ingreso, int> _repositoryIngresos;

    private readonly IRepository<Egreso, int> _repositoryEgresos;


    public CajaAppService(IRepository<Caja, int> repository,IRepository<Ingreso, int> repositoryIngresos,IRepository<Egreso, int> repositoryEgresos)
    {
        _repository = repository;
        _repositoryEgresos = repositoryEgresos;
        _repositoryIngresos = repositoryIngresos;
    }
    
    
    public async Task<ICollection<CajaDto>> GetCajaAsync()
    {
        var queryCajas = await _repository.WithDetailsAsync(x => x.listaIngresos, y => y.listaEgresos);

        var cajas = await AsyncExecuter.ToListAsync(queryCajas);

        return ObjectMapper.Map<ICollection<Caja>, ICollection<CajaDto>>(cajas);
    }

    public async Task<CajaDto> GetCajaAsync(int id)
    {
        var queryCajas = await _repository.WithDetailsAsync(x => x.listaIngresos, y => y.listaEgresos);

        var filtroCaja = queryCajas.Where(x => x.Id == id);
        
        var caja = await AsyncExecuter.FirstOrDefaultAsync(filtroCaja);

        return ObjectMapper.Map<Caja, CajaDto>(caja);
    }

    public async Task<CajaDto> CreateCajaAsync(CrearCajasDto input)
    {
        var caja = new Caja
        {
            descripcion = input.descripcion,
            saldo = input.saldo
        };

        await _repository.InsertAsync(caja);
        
        return ObjectMapper.Map<Caja, CajaDto>(caja);
    }

    public async Task<IngresosDto> CreateNewIngresoAsync(CrearIngresosDto input)
    {
        var ingreso = new Ingreso
        {
            valor = input.valor,
            fecha = input.fecha,
            CajaId = input.CajaId
        };

        await _repositoryIngresos.InsertAsync(ingreso);
        
        // Obtener la caja relacionada al ingreso
        var caja = await GetCajaAsync(ingreso.CajaId);

        // Actualizar el saldo de la caja
        caja.saldo += ingreso.valor;

        UpdateCajaAsync(ingreso.CajaId, caja);
        
        return ObjectMapper.Map<Ingreso, IngresosDto>(ingreso);
    }

    public async Task<EgresosDto> CreateNewEgresoAsync(CrearEgresosDto input)
    {
        var egreso = new Egreso
        {
            valor = input.valor,
            fecha = input.fecha,
            CajaId = input.CajaId
        };

        await _repositoryEgresos.InsertAsync(egreso);
        
        // Obtener la caja relacionada al ingreso
        var caja = await GetCajaAsync(egreso.CajaId);

        // Actualizar el saldo de la caja
        caja.saldo -= egreso.valor;

        UpdateCajaAsync(egreso.CajaId, caja);
        
        return ObjectMapper.Map<Egreso, EgresosDto>(egreso);
    }

    public async Task<CajaDto> UpdateCajaAsync(int id, CajaDto input)
    {
        var caja = await _repository.GetAsync(id);

        caja.saldo = input.saldo;
        caja.descripcion = input.descripcion;

        await _repository.UpdateAsync(caja);

        return ObjectMapper.Map<Caja, CajaDto>(caja);
    }

    public async Task<CajaDto> DeleteCajaAsync(int id)
    {
        throw new System.NotImplementedException();
    }
}
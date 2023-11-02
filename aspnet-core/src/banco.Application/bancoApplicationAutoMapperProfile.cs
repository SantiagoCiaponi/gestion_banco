using AutoMapper;
using banco.Cajas;
using banco.Egresos;
using banco.Ingresos;

namespace banco;

public class bancoApplicationAutoMapperProfile : Profile
{
    public bancoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        
        // mapas caja
        CreateMap<Caja, CajaDto>();
        CreateMap<Caja, CrearCajasDto>();
        
        // mapas Ingreso
        CreateMap<Ingreso, IngresosDto>();
        CreateMap<Ingreso, CrearIngresosDto>();
        
        // mapas Egreso
        CreateMap<Egreso, EgresosDto>();
        CreateMap<Egreso, CrearEgresosDto>();
        
    }
}

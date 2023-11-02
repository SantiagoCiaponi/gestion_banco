using System.Collections.Generic;
using banco.Egresos;
using banco.Ingresos;

namespace banco.Cajas;

public class CajaDto
{
    public string descripcion { get; set; }
    public int saldo { get; set; }
    
    public ICollection<IngresosDto> listaIngresos { get; set; }
    public ICollection<EgresosDto> listaEgresos { get; set; }
}
using System.Collections.Generic;
using banco.Egresos;
using banco.Ingresos;
using Volo.Abp.Domain.Entities;

namespace banco.Cajas;

public class Caja : Entity<int>
{
    public string descripcion { get; set; }
    
    public int saldo { get; set; }
    
    public ICollection<Ingreso> listaIngresos { get; set; }
    public ICollection<Egreso> listaEgresos { get; set; }

    
}
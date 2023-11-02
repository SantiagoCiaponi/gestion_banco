using System;
using banco.Cajas;
using Volo.Abp.Domain.Entities;

namespace banco.Ingresos;

public class Ingreso : Entity<int>
{
    
    public int valor { get; set; }
    public DateTime fecha { get; set; }
    
    
    public int CajaId { get; set; }
    public Caja? Caja { get; set; }

    
}
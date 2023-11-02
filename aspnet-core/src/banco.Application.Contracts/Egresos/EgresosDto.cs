using System;
using Volo.Abp.Application.Dtos;

namespace banco.Egresos;

public class EgresosDto : EntityDto<int>
{
    public int valor { get; set; }
    public DateTime fecha { get; set; }
    public int CajaId { get; set; }
}
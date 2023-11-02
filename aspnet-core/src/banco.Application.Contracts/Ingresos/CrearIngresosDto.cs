using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace banco.Ingresos;

public class CrearIngresosDto : EntityDto<int>
{
    [Required]
    public int valor { get; set; }
    [Required]
    public DateTime fecha { get; set; }
    [Required]
    public int CajaId { get; set; }
}
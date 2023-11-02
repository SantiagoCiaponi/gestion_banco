using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace banco.Egresos;

public class CrearEgresosDto : EntityDto<int>
{
    [Required]
    public int valor { get; set; }
    [Required]
    public DateTime fecha { get; set; }
    [Required]
    public int CajaId { get; set; } 
    
}
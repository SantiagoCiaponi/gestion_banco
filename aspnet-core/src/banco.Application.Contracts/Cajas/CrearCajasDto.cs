using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace banco.Cajas;

public class CrearCajasDto : EntityDto<int>
{
    [Required]
    public string descripcion { get; set; }
    [Required]
    public int saldo { get; set; }
}
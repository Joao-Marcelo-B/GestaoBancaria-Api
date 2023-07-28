using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GestaoBancariaApi.Data.Dtos;

public class CreateClienteDto
{
    [StringLength(50)]
    public string Name { get; set; }
}

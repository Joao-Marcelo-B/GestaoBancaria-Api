using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Models;

public class Conta
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(4)]
    public string NumeroConta { get; set; }
    [Required]
    [MaxLength(1)]
    public string DigitoVerificador { get; set; }
    [Required]
    public int ClienteId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class CreateMovimentacoesDto
{
    [Required]
    public string OrigemNumConta { get; set; }
    [Required]
    public string DestinoNumConta { get; set; }
    [Required]
    public string Tipo { get; set; }
    [Required]
    public DateTime DataMovimentacao { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public double ValorMovimentado { get; set; }
}

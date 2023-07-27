using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class CreateMovimentacoesDto
{
    [Required]
    public int OrigemContaId { get; set; }
    [Required]
    public int DestinoContaId { get; set; }
    [Required]
    public string Tipo { get; set; }
    [Required]
    public DataType DataMovimentacao { get; set; }
    [Required]
    public double ValorMovimentado { get; set; }
}

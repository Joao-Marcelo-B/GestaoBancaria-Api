using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Models;

public class Movimentacoes
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string OrigemNumConta { get; set; }
    [Required]
    public string DestinoNumConta { get; set; }
    [Required]
    public string Tipo { get; set; }
    [Required]
    public DateTime DataMovimentacao { get; set; }
    [Required]
    public double ValorMovimentado { get; set; }
}

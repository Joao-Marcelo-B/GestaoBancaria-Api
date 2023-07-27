using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Models;

public class Movimentacoes
{
    [Key]
    [Required]
    public int Id { get; set; }
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

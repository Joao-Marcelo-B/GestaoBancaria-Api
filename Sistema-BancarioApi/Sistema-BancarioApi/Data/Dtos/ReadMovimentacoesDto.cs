using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class ReadMovimentacoesDto
{
    public int Id { get; set; }
    public string OrigemNumConta { get; set; }
    public string DestinoNumConta { get; set; }
    public string Tipo { get; set; }
    public DateTime DataMovimentacao { get; set; }
    public double ValorMovimentado { get; set; }
}

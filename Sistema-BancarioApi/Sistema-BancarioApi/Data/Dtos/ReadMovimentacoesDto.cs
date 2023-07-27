using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class ReadMovimentacoesDto
{
    public int OrigemContaId { get; set; }
    public int DestinoContaId { get; set; }
    public string Tipo { get; set; }
    public DataType DataMovimentacao { get; set; }
    public double ValorMovimentado { get; set; }
}

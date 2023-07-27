using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class ReadContaDto
{
    public int Id { get; set; }
    public string NumeroConta { get; set; }
    public string DigitoVerificador { get; set; }
    public double Saldo { get; set; }
    public ReadClienteDto Cliente { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Data.Dtos;

public class UpdateTransfereDto
{
    [Range(0, double.MaxValue)]
    public double Saldo { get; set; }
}

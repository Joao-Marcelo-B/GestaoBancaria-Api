using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Managers;

public class UpdateTransfereDto
{
    [Range(0, double.MaxValue)]
    public double Saldo { get; set; }
}

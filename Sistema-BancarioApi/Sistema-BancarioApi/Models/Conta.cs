using System.ComponentModel.DataAnnotations;

namespace Sistema_BancarioApi.Models;

public class Conta
{
    public Conta()
    {
        Saldo = 200;
    }

    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(4)]
    public string NumeroConta { get; set; }
    [Required]
    [StringLength(1)]
    public string DigitoVerificador { get; set; }
    public double Saldo { get; set; }
    [Required]
    public int ClienteId { get; set; }
    public virtual Cliente Cliente { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace GestaoBancaria.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace GestaoBancariaApi.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}

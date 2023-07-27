using System.ComponentModel.DataAnnotations;

namespace GestaoBancariaApi.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    [EmailAddress] 
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}

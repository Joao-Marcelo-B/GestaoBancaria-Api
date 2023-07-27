using Microsoft.AspNetCore.Identity;

namespace GestaoBancariaApi.Models;

public class Usuario : IdentityUser
{
    public string Name { get; set; }
    public Usuario() : base() { }
}

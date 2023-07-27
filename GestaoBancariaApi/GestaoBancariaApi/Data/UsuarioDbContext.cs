using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoBancariaApi.Data;

public class UsuarioDbContext : IdentityDbContext<IdentityUser>
{
    public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
        :base(options)
    {
    }
}

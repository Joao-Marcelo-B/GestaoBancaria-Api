using Microsoft.EntityFrameworkCore;
using Sistema_BancarioApi.Models;

namespace Sistema_BancarioApi.Data;

public class SistemaContext : DbContext
{
    public SistemaContext(DbContextOptions<SistemaContext> opts) : base(opts)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Movimentacoes> Movimentacoes { get; set; }
}

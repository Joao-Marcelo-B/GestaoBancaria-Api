namespace Sistema_BancarioApi.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Conta Conta { get; set; }
}

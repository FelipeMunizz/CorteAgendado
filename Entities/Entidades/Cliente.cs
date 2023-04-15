namespace Entities.Entidades;

public class Cliente
{
    public int IdCliente { get; set; }
    public int IdPessoa { get; set; }
    public virtual Pessoa Pessoa { get; set; }
}

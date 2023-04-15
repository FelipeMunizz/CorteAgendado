using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Pessoa
{
    public int IdPessoa { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
    [MaxLength(90)]
    public string? Sobrenome { get; set; }
    public int IdBarbearia { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

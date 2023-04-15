using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class ContatoPessoa
{
    public int IdContatoBarbearia { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(100)]
    public bool IsWhatsApp { get; set; }
    public int IdPessoa { get; set; }
    public virtual Pessoa Pessoa { get; set; }
}

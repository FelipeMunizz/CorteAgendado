using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class ContatoBarbearia
{
    public int IdContatoBarbearia { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool IsWhatsApp { get; set; }
    public int IdBarbearia { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

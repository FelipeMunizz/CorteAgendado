using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class ContatoCliente
{
    public int ContatoClienteId { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool IsWhatsApp { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public virtual Cliente Cliente { get; set; }
}

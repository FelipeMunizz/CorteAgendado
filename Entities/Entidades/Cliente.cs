using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Cliente : Login
{
    public int ClienteId { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
    [MaxLength(90)]
    public string? Sobrenome { get; set; }
    public TipoDoc TipoDoc { get; set; }
    [MaxLength(14)]
    public string? Documento { get; set; }
    public int IdBarbearia { get; set; }
    [JsonIgnore]
    public virtual Barbearia Barbearia { get; set; }
}

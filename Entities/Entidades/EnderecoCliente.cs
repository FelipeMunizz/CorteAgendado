using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class EnderecoCliente
{
    public int EnderecoClienteId { get; set; }
    [MaxLength(200)]
    public string? Logradouro { get; set; }
    [MaxLength(100)]
    public string? Numero { get; set; }
    [MaxLength(100)]
    public string? Cidade { get; set; }
    public UF UF { get; set; }
    [MaxLength(20)]
    public string? CEP { get; set; }
    public int ClienteId { get; set; }
    [JsonIgnore]
    public virtual Cliente Cliente { get; set; }
}

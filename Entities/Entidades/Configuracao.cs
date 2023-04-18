using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Configuracao
{
    public int ConfiguracaoId { get; set; }
    [MaxLength(10)]
    public string? HoraInicio { get; set; }
    [MaxLength(10)]
    public string? HoraFim { get; set; }
    public int BarbeariaId { get; set; }
    [JsonIgnore]
    public virtual Barbearia Barbearia { get; set; }
}

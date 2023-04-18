using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Servicos
{
    public int ServicosId { get; set; }
    [MaxLength(70)]
    public string? Servico { get; set; }
    [MaxLength(255)]
    public string? Descricao { get; set; }
    [MaxLength(40)]
    public string? TempoExecucao { get; set; }
    public int BarbeariaId { get; set; }
    [JsonIgnore]
    public Barbearia Barbearia { get; set; }

}

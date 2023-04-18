using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class ServicosAgendados
{
    [Key]
    public int ServicosAgendadosId { get; set; }
    public int AgendamentoId { get; set; }
    public int ServicoId { get; set; }
    [JsonIgnore]
    public Agendamento Agendamento { get; set; }
    [JsonIgnore]
    public Servicos Servicos { get; set; }
}

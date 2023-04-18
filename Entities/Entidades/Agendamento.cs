using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Agendamento
{
    public int AgendamentoId { get; set; }
    public DateTime DataHoraAgendamento { get; set; }
    public int FuncionarioID { get; set; }
    public int ClienteId { get; set; }
    public List<ServicosAgendados> ServicoAgendado { get; set; } = new List<ServicosAgendados>();
    [JsonIgnore]
    public virtual Cliente Cliente { get; set; }
}

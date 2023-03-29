using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entidades;

public class Agendamento
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int FuncionarioId { get; set; }
    public int ServicoId { get; set; }
    public DateTime DataHoraAgendamento { get; set; }

    [JsonIgnore]
    public virtual Cliente Cliente { get; set; }
    [JsonIgnore]
    public virtual Funcionario Funcionario { get; set; }
    [JsonIgnore]
    public virtual Servico Servico { get; set; }
}

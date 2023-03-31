using Entities.Enum;
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
    public int BarbeariaId { get; set; }
    public DateTime DataHoraAgendamento { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual Funcionario Funcionario { get; set; }
    public virtual Servico Servico { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}
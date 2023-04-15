using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Agendamento
{
    [Key]
    public int IdAgendamento { get; set; }
    public DateTime DataHoraAgendamento { get; set; }
    public int IdServico { get; set; }
    public int IdFuncionario { get; set; }
    public int IdCliente { get; set; }
    public virtual Servicos Servicos { get; set; }
    public virtual Funcionario Funcionario { get; set; }
    public virtual Cliente Cliente { get; set; }
}

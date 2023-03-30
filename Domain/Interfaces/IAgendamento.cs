using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IAgendamento : InterfaceGeneric<Agendamento>
{
    Task<IList<Agendamento>> ListarAgendamentosCliente(string emailCliente);
    Task<IList<Agendamento>> ListarAgendamentosFuncionario(string emailFuncionario);
}

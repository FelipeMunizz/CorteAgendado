using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IContatoFuncionario : InterfaceGeneric<ContatoFuncionario>
{
    Task<ContatoFuncionario> GetContatByIdFuncionario(int funcionarioId);
}

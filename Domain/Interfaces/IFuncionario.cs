using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IFuncionario : InterfaceGeneric<Funcionario>
{
    Task<IList<Funcionario>> ListarFuncionariosBarbearia(int idBarbearia);
}

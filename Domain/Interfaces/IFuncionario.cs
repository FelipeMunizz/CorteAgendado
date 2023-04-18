using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IFuncionario : InterfaceGeneric<Funcionario>
{
    Task<Funcionario> GetFuncionarioByDocumento(string documento);
}

using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IFuncionario : InterfaceGeneric<Funcionario>
{
    Task<Funcionario> GetFuncionarioByDocumento(string documento);
    Task<IEnumerable<Funcionario>> GetFuncionariosBarbearia(int barbeariaId);
    Task<Barbearia> Login(string nome, string senha);
}

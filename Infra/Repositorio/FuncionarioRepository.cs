using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class FuncionarioRepository : RepositorioGenerico<Funcionario>, IFuncionario
{
    public Task<IList<Funcionario>> ListarFuncionariosBarbearia(int idBarbearia)
    {
        throw new NotImplementedException();
    }
}

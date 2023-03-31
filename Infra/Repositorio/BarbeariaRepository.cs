using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class BarbeariaRepository : RepositorioGenerico<Barbearia>, IBarbearia
{
    public Task<IList<Barbearia>> ListaClientesBarbearia(int idBarbearia)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Funcionario>> ListarFuncionariosBarbearia(int idBarbearia)
    {
        throw new NotImplementedException();
    }
}

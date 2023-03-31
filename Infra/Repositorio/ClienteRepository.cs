using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class ClienteRepository : RepositorioGenerico<Cliente>, ICliente
{
    public Task<IList<Cliente>> ListaClientesBarbearia(int idBarbearia)
    {
        throw new NotImplementedException();
    }
}

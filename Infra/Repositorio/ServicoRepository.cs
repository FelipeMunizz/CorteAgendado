using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class ServicoRepository : RepositorioGenerico<Servico>, IServico
{
    public Task<IList<Servico>> ListarServicosBarbearia(int idBarbearia)
    {
        throw new NotImplementedException();
    }
}

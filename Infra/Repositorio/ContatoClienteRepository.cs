using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class ContatoClienteRepository : RepositorioGenerico<ContatoCliente>, IContatoCliente
{
}

using Domain.Interfaces;
using Entities.Entidades;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio;

public class ClienteRepository : RepositorioGenerico<Cliente>, ICliente
{
}

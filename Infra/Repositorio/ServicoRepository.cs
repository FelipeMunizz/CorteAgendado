using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class ServicoRepository : RepositorioGenerico<Servico>, IServico
{
}

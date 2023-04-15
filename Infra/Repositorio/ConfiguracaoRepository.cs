using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class ConfiguracaoRepository : RepositorioGenerico<Configuracao>, IConfiguracao
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ConfiguracaoRepository()
    {
        _context = new DbContextOptions<AppDbContext>();
    }
}

using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class BarbeariaRepository : RepositorioGenerico<Barbearia>, IBarbearia
{
    private readonly DbContextOptions<AppDbContext> _context;

    public BarbeariaRepository()
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<Barbearia> ConfiguracaoBarbearia(int idConfiguracao)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await banco.Barbearias.Include(c => c.Configuracao).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}

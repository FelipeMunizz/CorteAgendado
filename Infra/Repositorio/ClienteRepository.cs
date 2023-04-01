using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class ClienteRepository : RepositorioGenerico<Cliente>, ICliente
{
    private readonly DbContextOptions<AppDbContext> _context;

    public ClienteRepository()
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Cliente>> ListaClientesBarbearia(int idBarbearia)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await banco.Clientes.Where(b => b.BarbeariaId == idBarbearia).AsNoTracking().ToListAsync();
        }
    }
}

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

    public Task<Barbearia> Login(string nome, string senha)
    {
        throw new NotImplementedException();
    }
}

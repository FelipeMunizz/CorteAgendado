using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class FuncionarioRepository : RepositorioGenerico<Funcionario>, IFuncionario
{
    private readonly DbContextOptions<AppDbContext> _context;

    public FuncionarioRepository()
    {
        _context = new DbContextOptions<AppDbContext>();
    }

    public async Task<IList<Funcionario>> ListarFuncionariosBarbearia(int idBarbearia)
    {
        using(var banco = new AppDbContext(_context))
        {
            return await banco.Funcionarios.Where(b => b.BarbeariaId == idBarbearia).AsNoTracking().ToListAsync();
        }
    }
}

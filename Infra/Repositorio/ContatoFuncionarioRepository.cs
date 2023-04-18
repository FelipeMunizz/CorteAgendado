using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class ContatoFuncionarioRepository : RepositorioGenerico<ContatoFuncionario>, IContatoFuncionario
{
    private readonly AppDbContext _context;

    public ContatoFuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ContatoFuncionario> GetContatByIdFuncionario(int funcionarioId)
    {
        return await _context.Set<ContatoFuncionario>().Where(c => c.FuncionarioId == funcionarioId).FirstOrDefaultAsync();
    }
}

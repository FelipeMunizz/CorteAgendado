using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class EnderecoFuncionarioRepository : RepositorioGenerico<EnderecoFuncioanrio>, IEnderecoFuncionario
{
    private readonly AppDbContext _context;

    public EnderecoFuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EnderecoFuncioanrio> GetEnderecoByIdFuncionario(int funcionarioId)
    {
        return await _context.Set<EnderecoFuncioanrio>().Where(e => e.FuncionarioId == funcionarioId).FirstAsync();
    }
}

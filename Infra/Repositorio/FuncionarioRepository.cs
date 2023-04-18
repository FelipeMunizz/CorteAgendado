using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class FuncionarioRepository : RepositorioGenerico<Funcionario>, IFuncionario
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<Funcionario> GetFuncionarioByDocumento(string documento)
    {
        Funcionario funcionario = new Funcionario();

        funcionario = await _context.Set<Funcionario>().FirstOrDefaultAsync(d => d.Documento == documento);

        return funcionario;
    }

    public async Task<IEnumerable<Funcionario>> GetFuncionariosBarbearia(int barbeariaId)
    {
        return await _context.Set<Funcionario>().Where(b => b.BarbeariaId == barbeariaId)
                                                .Include(b => b.Barbearia)
                                                .ToListAsync();
    }
}

using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class AgendamentoRepository : RepositorioGenerico<Agendamento>, IAgendamento
{
    private readonly DbContextOptions<AppDbContext> _context;

    public AgendamentoRepository()
    {
        _context = new DbContextOptions<AppDbContext>();
    }
    public async Task<IList<Agendamento>> ListarAgendamentosCliente(string emailCliente)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await banco.Agendamentos.Include(c => c.Cliente)
                                           .Include(s => s.Servico)
                                           .Include(f => f.Funcionario)
                                           .Where(c => c.Cliente.Contato.Email == emailCliente).AsNoTracking().ToListAsync();
        }
    }

    public async Task<IList<Agendamento>> ListarAgendamentosFuncionario(string emailFuncionario)
    {
        using (var banco = new AppDbContext(_context))
        {
            return await banco.Agendamentos.Include(f => f.Funcionario)
                                           .Include(s => s.Servico)
                                           .Include(c => c.Cliente)
                                           .Where(f => f.Funcionario.Contato.Email == emailFuncionario).AsNoTracking().ToListAsync();
        }
    }
}

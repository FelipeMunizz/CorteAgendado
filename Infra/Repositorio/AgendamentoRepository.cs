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
}

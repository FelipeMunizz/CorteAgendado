﻿using Domain.Interfaces;
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
            return null;
        }
    }

    public Task<IList<Agendamento>> ListarAgendamentosFuncionario(string emailFuncionario)
    {
        throw new NotImplementedException();
    }
}

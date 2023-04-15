using Entities.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public AppDbContext() { }

    #region Entidades
    public DbSet<Agendamento> Agendamento { get; set; }
    public DbSet<Barbearia> Barbearia { get; set; }
    public DbSet<Configuracao> Configuracao { get; set; }
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Servicos> Servicos { get; set; }
    #endregion

    #region Metodos Override
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Agendamento>().HasKey(a => a.IdAgendamento);
        builder.Entity<Barbearia>().HasKey(b => b.IdBarbearia);
        builder.Entity<Configuracao>().HasKey(c => c.IdConfiguracao);
        builder.Entity<Funcionario>().HasKey(f => f.IdFuncionario);
        builder.Entity<Servicos>().HasKey(s => s.IdServico);
        builder.Entity<Cliente>().HasKey(cl => cl.IdCliente);
        builder.Entity<Pessoa>().HasKey(p => p.IdPessoa);

        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        builder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
        });

        builder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        });
    }
    #endregion

    #region Metodos Nativos
    public string GetConnectionString()
    {
        return "Data Source=DESKTOP-10DDISU;Initial Catalog=CorteAgendadoDb;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
    }
    #endregion    
}
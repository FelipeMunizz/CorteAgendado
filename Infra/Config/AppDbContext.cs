using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public AppDbContext() { }

    #region Entidades
    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Barbearia> Barbearias { get; set; }
    public DbSet<Configuracao> Configuracao { get; set; }
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
        builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

        base.OnModelCreating(builder);
    }
    #endregion

    #region Metodos Nativos
    public string GetConnectionString()
    {
        return "Data Source=DESKTOP-10DDISU;Initial Catalog=CorteAgendado;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
    }
    #endregion    
}
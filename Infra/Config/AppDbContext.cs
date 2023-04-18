using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Config;

public class AppDbContext : DbContext
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
    public DbSet<ContatoCliente> ContatoCliente { get; set; }
    public DbSet<EnderecoCliente> EnderecoCliente { get; set; }
    public DbSet<ContatoFuncionario> ContatoFuncionario { get; set; }
    public DbSet<EnderecoFuncioanrio> EnderecoFuncionario { get; set; }
    public DbSet<ContatoBarbearia> ContatoBarbearia { get; set; }
    public DbSet<EnderecoBarbearia> EnderecoBarbearia { get; set; }
    public DbSet<ServicosAgendados> ServicosAgendados { get; set; }
    #endregion

    #region Metodos Override
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionString());
            base.OnConfiguring(optionsBuilder);
        }
    }
    #endregion

    #region Metodos Nativos
    public string ConnectionString()
    {
        return "Data Source=DESKTOP-10DDISU;Initial Catalog=CorteAgendadoDb;Integrated Security=True;Pooling=False;Encrypt=False;TrustServerCertificate=False;";
    }
    #endregion    
}
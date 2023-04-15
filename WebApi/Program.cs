using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
AppDbContext dbContext = new AppDbContext();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(dbContext.GetConnectionString()));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

#region Repositorios
builder.Services.AddSingleton<IAgendamento, AgendamentoRepository>();
builder.Services.AddSingleton<IBarbearia,   BarbeariaRepository>();
builder.Services.AddSingleton<IConfiguracao, ConfiguracaoRepository>();
builder.Services.AddSingleton<ICliente,     ClienteRepository>();
builder.Services.AddSingleton<IFuncionario, FuncionarioRepository>();
builder.Services.AddSingleton<IServico,     ServicoRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
AppDbContext dbContext = new AppDbContext();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiCorteAgendado", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autorização JWT usando o esquema Bearer.\r\n\r\nInforme 'Bearer'[espaço] e o seu token.\r\n\r\nExemplo \'Bearer 12345abcdef\'",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });

});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).
    AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
        ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(dbContext.ConnectionString()));

#region Repositorios
builder.Services.AddSingleton<IAgendamento, AgendamentoRepository>();
builder.Services.AddSingleton<IBarbearia,   BarbeariaRepository>();
builder.Services.AddSingleton<IConfiguracao, ConfiguracaoRepository>();
builder.Services.AddSingleton<ICliente,     ClienteRepository>();
builder.Services.AddScoped<IFuncionario, FuncionarioRepository>();
builder.Services.AddSingleton<IServico,     ServicoRepository>();
builder.Services.AddSingleton<IContatoFuncionario, ContatoFuncionarioRepository>();
builder.Services.AddSingleton<IContatoCliente, ContatoClienteRepository>();
builder.Services.AddSingleton<IContatoBarbearia, ContatoBarbeariaRepository>();
builder.Services.AddSingleton<IEnderecoCliente, EnderecoClienteRepository>();
builder.Services.AddSingleton<IEnderecoBarbearia, EnderecoBarbeariaRepository>();
builder.Services.AddSingleton<IEnderecoFuncionario, EnderecoFuncionarioRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
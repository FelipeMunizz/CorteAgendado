using Entities.Entidades;

namespace WebApi.DTOs;

public class UsuarioDTO
{
    public string? NomeBarbearia { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Telefone { get; set; }
    public bool IsWhatsApp { get; set; }
    public string? CEP { get; set; }
    public string? NumeroEndereco { get; set; }
    public Cliente? Cliente { get; set; }
    public Funcionario? Funcionario { get; set; }
}

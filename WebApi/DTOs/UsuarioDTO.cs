using Entities.Entidades;
using Entities.Enum;

namespace WebApi.DTOs;

public class UsuarioDTO
{
    public string? NomeBarbearia { get; set; }
    public string? Usuario { get; set; }
    public string? Senha { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public bool IsWhatsApp { get; set; }
    public string? CEP { get; set; }
    public string? Numero { get; set; }
    public string? TipoDocumento { get; set; }
    public string? Documento { get; set; }
    public string? Cargo { get; set; }
}

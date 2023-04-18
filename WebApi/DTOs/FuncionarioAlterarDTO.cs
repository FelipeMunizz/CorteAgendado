using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class FuncionarioAlterarDTO
{
    public int FuncionarioId { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
    [MaxLength(90)]
    public string? Sobrenome { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public string CEP { get; set; }
    public string Numero { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public bool IsWhatsApp { get; set; }
}

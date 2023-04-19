using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs;

public class LoginDTO
{
    [Required(ErrorMessage = "Digite usuario")]
    public string Usuario { get; set; }
    [Required(ErrorMessage = "Digite a senha")]
    public string Senha { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class ContatoFuncionario
{
    public int ContatoFuncionarioId { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool IsWhatsApp { get; set; }
    public int FuncionarioId { get; set; }
    [JsonIgnore]
    public virtual Funcionario Funcionario { get; set; }
}

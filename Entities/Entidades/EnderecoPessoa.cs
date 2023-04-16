using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class EnderecoPessoa
{
    public int IdEnderecoBarbearia { get; set; }
    [MaxLength(200)]
    public string? Logradouro { get; set; }
    [MaxLength(100)]
    public string? Numero { get; set; }
    [MaxLength(100)]
    public string? Cidade { get; set; }
    public UF UF { get; set; }
    [MaxLength(20)]
    public string? CEP { get; set; }
    public int IdPessoa { get; set; }
    public virtual Pessoa Pessoa { get; set; }
}

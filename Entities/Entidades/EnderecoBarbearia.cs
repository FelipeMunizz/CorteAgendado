using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class EnderecoBarbearia
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
    public int IdBarbearia { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

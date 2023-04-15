using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Barbearia
{
    public int IdBarbearia { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
}

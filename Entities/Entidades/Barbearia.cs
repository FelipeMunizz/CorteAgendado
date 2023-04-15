using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Barbearia : Base
{
    public int IdBarbearia { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
}

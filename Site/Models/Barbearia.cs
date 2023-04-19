using System.ComponentModel.DataAnnotations;

namespace Site.Models;

public class Barbearia
{
    public int BarbeariaId { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
}

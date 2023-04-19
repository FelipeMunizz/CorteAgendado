using System.ComponentModel.DataAnnotations;

namespace Site.Models;

public class Barbearia
{
    public int BarbeariaId { get; set; }

    [Required(ErrorMessage = "Digite um nome para barbearia")]
    [MaxLength(60)]
    public string? Nome { get; set; }
}

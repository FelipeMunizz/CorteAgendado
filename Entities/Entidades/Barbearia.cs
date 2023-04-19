using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades;

public class Barbearia
{
    public int BarbeariaId { get; set; }
    [MaxLength(60)]
    public string? Nome { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
}

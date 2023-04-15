using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Configuracao : Base
{
    public int IdConfiguracao { get; set; }
    [MaxLength(10)]
    public string? HoraInicio { get; set; }
    [MaxLength(10)]
    public string? HoraFim { get; set; }
    public int IdBarbearia { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

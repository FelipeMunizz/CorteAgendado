using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Funcionario
{
    public int IdFuncionario { get; set; }
    public TipoDoc TipoDoc { get; set; }
    [MaxLength(14)]
    public string? Documento { get; set; }
    public Cargos Cargo { get; set; }
    public int IdPessoa { get; set; }
    public virtual Pessoa Pessoa { get; set; }
}

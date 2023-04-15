using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades;

public class Servicos : Base
{
    public int IdServico { get; set; }
    [MaxLength(70)]
    public string? Servico { get; set; }
    [MaxLength(255)]
    public string? Descricao { get; set; }
    [MaxLength(40)]
    public string? TempoExecucao { get; set; }
    public int IdBarbearia { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

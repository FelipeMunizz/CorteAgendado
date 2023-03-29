namespace Entities.Entidades;

public class Servico : Base
{
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string TempoServiço { get; set; }
    public virtual List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}

using Entities.Enum;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Cliente : Base
{
    public int BarbeariaId { get; set; }
    public string Sobrenome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public UF UF { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
    public virtual ICollection<Agendamento> Agendamentos { get; set; } = new HashSet<Agendamento>();
    [JsonIgnore]
    public virtual Barbearia Barbearia { get; set; }
}

using Entities.Enum;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Cliente : Base
{
    public int BarbeariaId { get; set; }
    public string Sobrenome { get; set; }    
    public int EnderecoId { get; set; }
    public int ContatoId { get; set; }
    public virtual Contato Contato { get; set; }
    public virtual Endereco Endereco { get; set; }
    public virtual Barbearia Barbearia { get; set; }
}

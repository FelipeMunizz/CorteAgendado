using Entities.Enum;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class Funcionario : Base
{
    public string Sobrenome { get; set; }
    public string Telefone { get; set; }
    public int EnderecoId { get; set; }
    public int ContatoId { get; set; }
    public int BarbeariaId { get; set; }
    public virtual Contato Contato { get; set; }
    public virtual Endereco Endereco { get; set; }
    public Barbearia Barbearia { get; set; }
}

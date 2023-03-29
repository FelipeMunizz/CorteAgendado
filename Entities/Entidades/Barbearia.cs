using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entidades;

public class Barbearia : Base
{
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public UF UF { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
    public int ConfiguracaoId { get; set; }
    [JsonIgnore]
    public Configuracao Configuracao { get; set; }
}

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
    public int ContatoId { get; set; }
    public int EnderecoId { get; set; }
    public int ConfiguracaoId { get; set; }
    public virtual Contato Contato { get; set; }
    public virtual Endereco Endereco { get; set; }
    public virtual Configuracao Configuracao { get; set; }
}

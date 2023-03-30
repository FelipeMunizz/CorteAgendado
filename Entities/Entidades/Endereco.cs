using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades;

public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public UF UF { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
}

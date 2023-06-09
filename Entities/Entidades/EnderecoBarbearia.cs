﻿using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class EnderecoBarbearia
{
    public int EnderecoBarbeariaId { get; set; }
    [MaxLength(200)]
    public string? Logradouro { get; set; }
    [MaxLength(100)]
    public string? Numero { get; set; }
    [MaxLength(100)]
    public string? Cidade { get; set; }
    public UF UF { get; set; }
    [MaxLength(20)]
    public string? CEP { get; set; }
    public int BarbeariaId { get; set; }
    [JsonIgnore]
    public virtual Barbearia Barbearia { get; set; } 
}

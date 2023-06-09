﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities.Entidades;

public class ContatoBarbearia
{
    public int ContatoBarbeariaId { get; set; }
    [MaxLength(11)]
    public string? Telefone { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; }
    public bool IsWhatsApp { get; set; }
    public int BarbeariaId { get; set; }
    [JsonIgnore]
    public virtual Barbearia Barbearia { get; set; }
}

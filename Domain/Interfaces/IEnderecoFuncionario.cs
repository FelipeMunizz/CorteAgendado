﻿using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IEnderecoFuncionario : InterfaceGeneric<EnderecoFuncioanrio>
{
    Task<EnderecoFuncioanrio> GetEnderecoByIdFuncionario(int funcionarioId);
}

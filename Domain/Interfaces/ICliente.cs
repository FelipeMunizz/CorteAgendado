using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface ICliente : InterfaceGeneric<Cliente>
{
    Task<Barbearia> Login(string nome, string senha);
}

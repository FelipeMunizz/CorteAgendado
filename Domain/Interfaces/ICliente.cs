using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface ICliente : InterfaceGeneric<Cliente>
{
    Task<IList<Cliente>> ListaClientesBarbearia(int idBarbearia);
}

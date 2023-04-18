using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IBarbearia : InterfaceGeneric<Barbearia>
{
    Task<Barbearia> GetBarbeariaByNome (string nome);
    Task<Barbearia> GetBarbeariaFuncionarios(int barbeariaId);
}

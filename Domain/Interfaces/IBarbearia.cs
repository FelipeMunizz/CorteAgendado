using Domain.Interfaces.Generics;
using Entities.Entidades;

namespace Domain.Interfaces;

public interface IBarbearia : InterfaceGeneric<Barbearia>
{

    Task<IList<Barbearia>> ListaClientesBarbearia(int idBarbearia);
    Task<IList<Funcionario>> ListarFuncionariosBarbearia(int idBarbearia);
}

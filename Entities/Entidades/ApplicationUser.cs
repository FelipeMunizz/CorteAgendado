using Microsoft.AspNetCore.Identity;
namespace Entities.Entidades;

public class ApplicationUser : IdentityUser
{ 
    public virtual Cliente Cliente { get; set; }
    public virtual Funcionario Funcionario { get; set; }
}

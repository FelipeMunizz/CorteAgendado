using Entities.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helpers.Utils;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(IConfiguration config, UserManager<ApplicationUser> userManager)
    {
        _config = config;
        _userManager = userManager;
    }

    [HttpGet("TesteConexao")]
    public ActionResult<string> TesteConexao()
    {
        return $"Api acessada: {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}";
    }
}

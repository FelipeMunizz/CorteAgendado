using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpGet("TesteConexao")]
    public ActionResult<string> TesteConexao()
    {
        return $"Api acessada: {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}";
    }
}

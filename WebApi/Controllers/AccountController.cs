using Entities.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helpers.Utils;
using Domain.Interfaces;
using WebApi.DTOs;
using Microsoft.Data.SqlClient;
using Infra.Config;
using Entities.Enum;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ICliente _cliente;
    private readonly IFuncionario _funcionario;

    public AccountController(IConfiguration config,
                             UserManager<IdentityUser> userManager,
                             ICliente cliente,
                             IFuncionario funcionario
    )
    {
        _config = config;
        _userManager = userManager;
        _cliente = cliente;
        _funcionario = funcionario;
    }

    //[HttpPost("Registrar")]
    //public async Task<IActionResult> Registrar([FromBody] UsuarioDTO model)
    //{
        

    //    return Ok("Usuario Registrado com Sucesso");
    //}
}

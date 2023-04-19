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
    private readonly ICliente _cliente;
    private readonly IFuncionario _funcionario;
    private readonly IBarbearia _barbearia;

    public AccountController(IConfiguration config,
                             ICliente cliente,
                             IFuncionario funcionario,
                             IBarbearia barbearia
    )
    {
        _config = config;
        _cliente = cliente;
        _funcionario = funcionario;
        _barbearia = barbearia;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Registrar([FromBody] LoginDTO model)
    {


        return Ok("Usuario Registrado com Sucesso");
    }
}

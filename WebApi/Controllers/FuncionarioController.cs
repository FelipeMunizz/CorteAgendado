using Domain.Interfaces;
using Entities.Entidades;
using Entities.Enum;
using Helpers.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApi.DTOs;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionario _funcionario;
    private readonly IContatoFuncionario _contato;
    private readonly IEnderecoFuncionario _endereco;
    private readonly IBarbearia _barbearia;

    public FuncionarioController(IFuncionario funcionario, IContatoFuncionario contato, IEnderecoFuncionario endereco, IBarbearia barbearia)
    {
        _funcionario = funcionario;
        _contato = contato;
        _endereco = endereco;
        _barbearia = barbearia;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioDTO model)
    {
        string documento = model.Documento;
        string senha = model.Senha;

        var barberaia = await _barbearia.GetBarbeariaByNome(model.NomeBarbearia);

        if (barberaia == null)
            return BadRequest("Barbearia não encontrada");

        if (!Senha.ValidaSenha(senha))
            return BadRequest("Sua senha não condiz com as diretrizes");

        senha = Senha.CriptografarSenha(senha);

        TipoDoc tipoDoc = (TipoDoc)Enum.Parse(typeof(TipoDoc), model.TipoDocumento);
        
        if(tipoDoc == TipoDoc.CPF)
        {
            documento = Utils.RemoverCaracteresCpf(documento);
        }
        else
        {
            documento = Utils.RemoverCaracteresCnpj(documento);
        }

        Cargos cargo = (Cargos)Enum.Parse(typeof(Cargos), model.Cargo);

        Funcionario funcionario = new Funcionario
        {
            Nome = model.Nome,
            Sobrenome = model.Sobrenome,
            Usuario = model.Usuario,
            Senha = senha,
            TipoDoc = tipoDoc,
            Documento = documento,
            Cargo = cargo,
            BarbeariaId = barberaia.BarbeariaId
        };

        await _funcionario.Add(funcionario);

        funcionario = await _funcionario.GetFuncionarioByDocumento(documento);

        ContatoFuncionario contato = new ContatoFuncionario
        {
            Email = model.Email,
            Telefone = model.Telefone,
            IsWhatsApp = model.IsWhatsApp,
            FuncionarioId = funcionario.FuncionarioId
        };

        await _contato.Add(contato);

        string url = $"https://viacep.com.br/ws/{model.CEP}/json/";
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var resultJson = await response.Content.ReadAsStringAsync();
        JObject obj = JObject.Parse(resultJson);

        string ufString = (string)obj["uf"];
        UF uf = (UF)Enum.Parse(typeof(UF), ufString);

        EnderecoFuncioanrio endereco = new EnderecoFuncioanrio
        {
            Logradouro = (string)obj["logradouro"],
            CEP = (string)obj["cep"],
            Cidade = (string)obj["localidade"],
            UF = uf,
            Numero = model.Numero,
            FuncionarioId = funcionario.FuncionarioId
        };

        await _endereco.Add(endereco);

        return Ok("Usuario Registrado com Sucesso");
    }
}

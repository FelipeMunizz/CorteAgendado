using Domain.Interfaces;
using Entities.Entidades;
using Entities.Enum;
using Helpers.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

    [HttpGet("ObterFuncionariosBarbearia")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> GetFuncionariosBarbearia([FromQuery]int barbeariaId)
    {
        var funcionarios = await _funcionario.GetFuncionariosBarbearia(barbeariaId);

        return Ok(funcionarios);
    }

    [HttpGet("{id:int}", Name = "ObterFuncionario")]
    public async Task<IActionResult> Get(int id)
    {
        var funcionario = await _funcionario.GetEntityById(id);

        if (funcionario == null)
            return BadRequest("Usuario não encontrado");

        return Ok(funcionario);
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] FuncionarioDTO model)
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
        UF
            uf = (UF)Enum.Parse(typeof(UF), ufString);

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

        return new CreatedAtRouteResult("ObterFuncionario",
                new { id = funcionario.FuncionarioId }, funcionario);
    }

    [HttpPut("Editar")]
    public async Task<IActionResult> Editar([FromBody] FuncionarioAlterarDTO funcionarioDto)
    {
        string senha = funcionarioDto.Senha;
        if (!Senha.ValidaSenha(senha))
            return BadRequest("Senha não condiz com as diretrizes");

        senha = Senha.CriptografarSenha(senha);

        Funcionario funcionario = await _funcionario.GetEntityById(funcionarioDto.FuncionarioId);
        if (funcionario == null)
            return BadRequest("Funcionario não encontrado");

        ContatoFuncionario contato = await _contato.GetContatByIdFuncionario(funcionario.FuncionarioId);

        contato.Email = funcionarioDto.Email;
        contato.Telefone = funcionarioDto.Telefone;
        contato.IsWhatsApp = funcionarioDto.IsWhatsApp;

        await _contato.Update(contato);

        EnderecoFuncioanrio endereco = await _endereco.GetEnderecoByIdFuncionario(funcionario.FuncionarioId);

        string url = $"https://viacep.com.br/ws/{funcionarioDto.CEP}/json/";
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        var resultJson = await response.Content.ReadAsStringAsync();
        JObject obj = JObject.Parse(resultJson);

        string ufString = (string)obj["uf"];
        UF
            uf = (UF)Enum.Parse(typeof(UF), ufString);
        
        endereco.Logradouro = (string)obj["logradouro"];
        endereco.CEP = (string)obj["cep"];
        endereco.Cidade = (string)obj["localidade"];
        endereco.UF = uf;
        endereco.Numero = funcionarioDto.Numero;

        await _endereco.Update(endereco);        

        funcionario.FuncionarioId = funcionarioDto.FuncionarioId;
        funcionario.Nome = funcionarioDto.Nome;
        funcionario.Sobrenome = funcionarioDto.Sobrenome;
        funcionario.Usuario = funcionarioDto.Usuario;
        funcionario.Senha = senha;

        await _funcionario.Update(funcionario);

        return Ok("Funcionario editado com sucesso");
    }

    [HttpDelete("Deletar")]
    public async Task<IActionResult> Deletar([FromQuery]int funcionarioId)
    {
        Funcionario funcionario = await _funcionario.GetEntityById(funcionarioId);
        if (funcionario == null)
            return BadRequest("Funcionario não encontrado");

        await _funcionario.Delete(funcionario);
        return Ok("Funcionario deletado com sucesso");
    }
}

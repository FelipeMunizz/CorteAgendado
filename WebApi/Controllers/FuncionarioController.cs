using Domain.Interfaces;
using Entities.Entidades;
using Entities.Enum;
using Helpers.Utils;
using Infra.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using WebApi.DTOs;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionario _funcionario;
    private readonly IContatoFuncionario _contatoPessoa;
    private readonly IEnderecoCliente _enderecoPessoa;
    private readonly IBarbearia _barbearia;

    public FuncionarioController(IFuncionario funcionario, IContatoFuncionario contatoPessoa, IEnderecoCliente enderecoPessoa, IBarbearia barbearia)
    {
        _funcionario = funcionario;
        _contatoPessoa = contatoPessoa;
        _enderecoPessoa = enderecoPessoa;
        _barbearia = barbearia;
    }

    [HttpPost("Registrar")]
    public async Task<IActionResult> Registrar([FromBody] UsuarioDTO model)
    {
        #region ADO.NET
        //#region Variaveis
        //int idBarbearia = 0;
        //int idPessoa = 0;
        //string insertFuncionario = "";
        //string insertCliente = "";
        //#endregion        

        //#region Querys
        //string selectBarbearia = @"select IdBarbearia from barbearia where Nome = @Nome";

        //string insertPessoa = @"insert into Pessoa (Nome, Sobrenome, IdBarbearia)
        //                                    values (@Nome, @Sobrenome, @IdBarbearia)";

        //string selectPessoa = @"select IdPessoa from pessoa where CONCAT(Nome,' ', Sobrenome) = CONCAT(@Nome,' ', @Sobrenome)";

        //if (model.Funcionario != null)
        //{
        //    insertFuncionario = @"insert into Funcionario (TipoDoc, Documento, Cargo, IdPessoa)
        //                                           values (@TipoDoc, @Documento, @Cargo, @IdPessoa)";
        //}
        //string inserirContato = @"insert into ContatoPessoa (Telefone, Email, IsWhatsApp, IdPessoa)
        //                                             values (@Telefone, @Email, @IsWhatsApp, @IdPessoa)";

        //string inserirEndereco = @"insert into EnderecoPessoa (Logradouro, Numero, Cidade, UF, CEP, IdPessoa)
        //                                               values (@Logradouro,@Numero,@Cidade,@UF,@CEP ,@IdPessoa)";
        //#endregion

        //#region Processo para Salvar um Usuario
        //using (SqlConnection connection = new SqlConnection(new AppDbContext().ConnectionString()))
        //{
        //    await connection.OpenAsync();

        //    #region Select Barbearia
        //    SqlCommand command = new SqlCommand(selectBarbearia, connection);

        //    command.Parameters.AddWithValue("@Nome", model.NomeBarbearia);
        //    var reader = await command.ExecuteReaderAsync();
        //    if (!reader.HasRows)
        //    {
        //        await connection.CloseAsync();
        //        return NotFound("Barbearia não encontrada.");
        //    }

        //    if (reader.Read())
        //    {
        //        idBarbearia = (int)reader["IdBarbearia"];
        //    }

        //    await connection.CloseAsync();
        //    #endregion

        //    #region Iserindo Pessoa
        //    await connection.OpenAsync();
        //    command = new SqlCommand(insertPessoa, connection);

        //    command.Parameters.AddWithValue("@Nome", model.Nome);
        //    command.Parameters.AddWithValue("@Sobrenome", model.Sobrenome);
        //    command.Parameters.AddWithValue("@IdBarbearia", idBarbearia);
        //    int result = await command.ExecuteNonQueryAsync();
        //    if (result < 0)
        //    {
        //        await connection.CloseAsync();
        //        return NotFound("Não foi possivel inserir Pessoa.");
        //    }
        //    await connection.CloseAsync();
        //    #endregion

        //    #region Select Pessoa
        //    await connection.OpenAsync();
        //    command = new SqlCommand(selectPessoa, connection);

        //    command.Parameters.AddWithValue("@Nome", model.Nome);
        //    command.Parameters.AddWithValue("@Sobrenome", model.Sobrenome);
        //    reader = await command.ExecuteReaderAsync();
        //    if (!reader.HasRows)
        //    {
        //        await connection.CloseAsync();
        //        return NotFound("Pessoa não encontrada.");
        //    }

        //    if (reader.Read())
        //    {
        //        idPessoa = (int)reader["IdPessoa"];
        //    }
        //    await connection.CloseAsync();
        //    #endregion

        //    #region Inserindo Funcionario
        //    if (model.Funcionario != null)
        //    {
        //        await connection.OpenAsync();
        //        command = new SqlCommand(insertFuncionario, connection);

        //        command.Parameters.AddWithValue("@TipoDoc", model.Funcionario.TipoDoc);
        //        command.Parameters.AddWithValue("@Documento", model.Funcionario.Documento);
        //        command.Parameters.AddWithValue("@Cargo", model.Funcionario.Cargo);
        //        command.Parameters.AddWithValue("@IdPessoa", idPessoa);

        //        result = await command.ExecuteNonQueryAsync();
        //        if (result < 0)
        //        {
        //            await connection.CloseAsync();
        //            return NotFound("Não foi possivel inserir Funcionario.");
        //        }
        //        await connection.CloseAsync();
        //    }
        //    #endregion

        //    #region Inserindo Cliente
        //    if (model.Cliente != null)
        //    {
        //        await connection.OpenAsync();
        //        command = new SqlCommand(insertCliente, connection);

        //        command.Parameters.AddWithValue("@IdPessoa", idPessoa);

        //        result = await command.ExecuteNonQueryAsync();
        //        if (result < 0)
        //        {
        //            await connection.CloseAsync();
        //            return NotFound("Não foi possivel inserir Cliente.");
        //        }
        //        await connection.CloseAsync();
        //    }
        //    #endregion

        //    #region Inserindo Contato
        //    await connection.OpenAsync();
        //    command = new SqlCommand(inserirContato, connection);

        //    command.Parameters.AddWithValue("@Telefone", model.Telefone);
        //    command.Parameters.AddWithValue("@Email", model.Email);
        //    command.Parameters.AddWithValue("@IsWhatsApp", model.IsWhatsApp);
        //    command.Parameters.AddWithValue("@IdPessoa", idPessoa);

        //    result = await command.ExecuteNonQueryAsync();
        //    if (result < 0)
        //    {
        //        await connection.CloseAsync();
        //        return NotFound("Não foi possivel inserir Contato.");
        //    }
        //    await connection.CloseAsync();
        //    #endregion

        //    #region Inserindo Endereço (requeste com CEP informado e inserção no banco)
        //    string url = $"https://viacep.com.br/ws/{model.CEP}/json/";
        //    HttpClient client = new HttpClient();
        //    var response = await client.GetAsync(url);
        //    var resultJson = await response.Content.ReadAsStringAsync();
        //    JObject obj = JObject.Parse(resultJson);

        //    string ufString = (string)obj["uf"];
        //    UF uf = (UF)Enum.Parse(typeof(UF), ufString);

        //    EnderecoPessoa endereco = new EnderecoPessoa
        //    {
        //        Logradouro = (string)obj["logradouro"],
        //        CEP = (string)obj["cep"],
        //        Cidade = (string)obj["localidade"],
        //        UF = uf,
        //        Numero = model.NumeroEndereco
        //    };
        //    await connection.OpenAsync();
        //    command = new SqlCommand(inserirEndereco, connection);

        //    command.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
        //    command.Parameters.AddWithValue("@Numero", model.NumeroEndereco);
        //    command.Parameters.AddWithValue("@Cidade", endereco.Cidade);
        //    command.Parameters.AddWithValue("@UF", endereco.UF);
        //    command.Parameters.AddWithValue("@CEP", endereco.CEP);
        //    command.Parameters.AddWithValue("@IdPessoa", idPessoa);
        //    result = await command.ExecuteNonQueryAsync();
        //    if (result < 0)
        //    {
        //        await connection.CloseAsync();
        //        return NotFound("Não foi possivel inserir Endereco.");
        //    }
        //    await connection.CloseAsync();
        //    #endregion
        //}
        //#endregion
        #endregion

        //Barbearia barbearia = await _barbearia.GetBarbeariaByNome(model.NomeBarbearia);

        //Pessoa pessoa = new Pessoa 
        //{ 
        //    Nome = model.Nome,
        //    Sobrenome = model.Sobrenome,
        //    IdBarbearia = barbearia.IdBarbearia
        //};
        //await _pessoa.Add(pessoa);

        //pessoa = await _pessoa.GetPessoaByNome(model.Nome, model.Sobrenome);

        //string url = $"https://viacep.com.br/ws/{model.CEP}/json/";
        //HttpClient client = new HttpClient();
        //var response = await client.GetAsync(url);
        //var resultJson = await response.Content.ReadAsStringAsync();
        //JObject obj = JObject.Parse(resultJson);

        //string ufString = (string)obj["uf"];
        //UF uf = (UF)Enum.Parse(typeof(UF), ufString);

        //EnderecoCliente endereco = new EnderecoCliente
        //{
        //    Logradouro = (string)obj["logradouro"],
        //    CEP = (string)obj["cep"],
        //    Cidade = (string)obj["localidade"],
        //    UF = uf,
        //    Numero = model.Numero,
        //    IdPessoa = pessoa.IdPessoa
        //};
        //await _enderecoPessoa.Add(endereco);

        //ContatoCliente contato = new ContatoCliente
        //{
        //    Telefone = model.Telefone,
        //    Email = model.Email,
        //    IsWhatsApp = model.IsWhatsApp,
        //    IdPessoa = pessoa.IdPessoa
        //};
        //await _contatoPessoa.Add(contato);

        //string documento = model.Documento;
        //string tipodoc = model.TipoDocumento;
        //TipoDoc tpDoc = (TipoDoc)Enum.Parse(typeof(TipoDoc), tipodoc);

        //if(tpDoc == TipoDoc.CNPJ)
        //{
        //    documento = Utils.RemoverCaracteresCnpj(documento);
        //}
        //else
        //{
        //    documento = Utils.RemoverCaracteresCpf(documento);
        //}

        //string cargoString = model.Cargo;
        //Cargos cargo = (Cargos)Enum.Parse(typeof(Cargos), cargoString);

        //Funcionario funcionario = new Funcionario
        //{
        //    TipoDoc = tpDoc,
        //    Documento = documento,
        //    Cargo = cargo,
        //    IdPessoa = pessoa.IdPessoa
        //};

        //await _funcionario.Add(funcionario);

        return Ok("Usuario Registrado com Sucesso");
    }
}

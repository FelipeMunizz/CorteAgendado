using Entities.Entidades;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helpers.Utils;

public static class JwtTokenGenerator
{

    public static string GenerateJwtTokenFuncionario(Funcionario user, ContatoFuncionario contatoFuncionario, IConfiguration config)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, contatoFuncionario.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Nome)
        };

        claims.Add(new Claim("FuncionarioId", user.FuncionarioId.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(double.Parse(config["TokenConfiguration:ExpireHours"]));

        var token = new JwtSecurityToken(
            issuer: config["TokenConfiguration:Issuer"],
            audience: config["TokenConfiguration:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static string GenerateJwtTokenCliente(Cliente user, ContatoCliente contatoCliente, IConfiguration config)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, contatoCliente.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Nome)
        };

        claims.Add(new Claim("ClienteId", user.ClienteId.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(double.Parse(config["TokenConfiguration:ExpireHours"]));

        var token = new JwtSecurityToken(
            issuer: config["TokenConfiguration:Issuer"],
            audience: config["TokenConfiguration:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

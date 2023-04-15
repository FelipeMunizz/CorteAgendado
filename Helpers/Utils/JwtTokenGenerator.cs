using Entities.Entidades;
using Entities.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Helpers.Utils;

public static class JwtTokenGenerator
{

    public static string GenerateJwtToken(IConfiguration config, ApplicationUser user, bool isCliente, bool isFuncionario)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        if(isCliente)
            claims.Add(new Claim("IdCliente", user.Cliente.IdCliente.ToString()));

        if (isFuncionario)
        {
            claims.Add(new Claim("IdFuncionario", user.Funcionario.IdFuncionario.ToString()));

            if(user.Funcionario.Cargo == Cargos.Gerencia)
                claims.Add(new Claim("Gerencia", "true"));

            if (user.Funcionario.Cargo == Cargos.Barbeiro)
                claims.Add(new Claim("Barbeiro", "true"));
        }

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

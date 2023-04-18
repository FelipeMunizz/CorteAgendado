using Domain.Interfaces;
using Entities.Entidades;
using Infra.Config;
using Infra.Repositorio.Generics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorio;

public class BarbeariaRepository : RepositorioGenerico<Barbearia>, IBarbearia
{
    private readonly AppDbContext _context;

    public BarbeariaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Barbearia> GetBarbeariaByNome(string nome)
    {
        Barbearia barbearia = new Barbearia();
        string selectBarbearia = @"select * from barbearia where Nome = @Nome";

        using (SqlConnection connection = new SqlConnection(new AppDbContext().ConnectionString()))
        {
            await connection.OpenAsync();

            #region Select Barbearia
            SqlCommand command = new SqlCommand(selectBarbearia, connection);

            command.Parameters.AddWithValue("@Nome", nome);
            var reader = await command.ExecuteReaderAsync();
            if (!reader.HasRows)
            {
                await connection.CloseAsync();
                return null;
            }

            if (reader.Read())
            {
                barbearia.BarbeariaId = (int)reader["BarbeariaId"];
                barbearia.Nome = (string)reader["Nome"];

            }

            await connection.CloseAsync();
            #endregion

            return barbearia;
        }
    }
}

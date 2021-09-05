using catalogo_api.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace catalogo_api.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly SqlConnection sqlConnection;

        public FilmeRepository(IConfiguration configuration)
        {
            this.sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task Delete(Guid id)
        {
            var comando = $"DELETE FROM tbl_filmes WHERE id = '{id}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }

        public async Task<List<Filme>> Get(int pagina, int quantidade)
        {
            var filmes = new List<Filme>();

            var comando = $"SELECT * FROM tbl_filmes ORDER BY id OFFSET {((pagina - 1) * quantidade)} ROWS FETCH NEXT {quantidade} ROWS ONLY";
            await sqlConnection.OpenAsync();
            SqlCommand sqlComando = new SqlCommand(comando,sqlConnection);
            SqlDataReader sqlDateReader = await sqlComando.ExecuteReaderAsync();

            while (sqlDateReader.Read())
            {
                filmes.Add(new Filme {Id = (Guid)sqlDateReader["id"],
                                        Titulo = (string)sqlDateReader["titulo"],
                                        Valor = (decimal)sqlDateReader["valor"],
                                        Diretor = (string)sqlDateReader["diretor"]});
            }
            await sqlConnection.CloseAsync();
            return filmes;
        }

        public async Task<List<Filme>> Get(string diretor, string titulo)
        {
            var filmes = new List<Filme>();

            var comando = $"SELECT * FROM tbl_filmes WHERE titulo = '{titulo}' AND diretor = '{diretor}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlComando = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDateReader = await sqlComando.ExecuteReaderAsync();

            while (sqlDateReader.Read())
            {
                filmes.Add(new Filme
                {
                    Id = (Guid)sqlDateReader["id"],
                    Titulo = (string)sqlDateReader["titulo"],
                    Valor = (decimal)sqlDateReader["valor"],
                    Diretor = (string)sqlDateReader["diretor"]
                });
            }
            await sqlConnection.CloseAsync();
            return filmes;
        }

        public async Task<Filme> Get(Guid id)
        {
            Filme filme = null;

            var comando = $"SELECT * FROM tbl_filmes WHERE id = '{id}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlComando = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDateReader = await sqlComando.ExecuteReaderAsync();

            while (sqlDateReader.Read())
            {
                filme =new Filme
                {
                    Id = (Guid)sqlDateReader["id"],
                    Titulo = (string)sqlDateReader["titulo"],
                    Valor = (decimal)sqlDateReader["valor"],
                    Diretor = (string)sqlDateReader["diretor"]
                };
            }
            await sqlConnection.CloseAsync();
            return filme;
        }

        public async Task<List<Filme>> Get(string diretor)
        {
            var filmes = new List<Filme>();

            var comando = $"SELECT * FROM tbl_filmes WHERE diretor = '{diretor}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlComando = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDateReader = await sqlComando.ExecuteReaderAsync();

            while (sqlDateReader.Read())
            {
                filmes.Add(new Filme
                {
                    Id = (Guid)sqlDateReader["id"],
                    Titulo = (string)sqlDateReader["titulo"],
                    Valor = (decimal)sqlDateReader["valor"],
                    Diretor = (string)sqlDateReader["diretor"]
                });
            }
            await sqlConnection.CloseAsync();
            return filmes;
        }

        public async Task Patch(Guid id, decimal valor)
        {
            var comando = $"UPDATE tbl_filmes SET valor = {valor.ToString().Replace(",", ".")} WHERE id = '{id}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Post(Filme filme)
        {
            var comando = $"INSERT INTO tbl_filmes (id,titulo,valor,diretor) VALUES ('{filme.Id}','{filme.Titulo}',{filme.Valor.ToString().Replace(",", ".")},'{filme.Diretor}')";
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando,sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();

        }

        public async Task Put(Guid id, Filme filme)
        {
            var comando = $"UPDATE tbl_filmes SET id = '{filme.Id}',titulo = '{filme.Titulo}', valor = {filme.Valor.ToString().Replace(",",".")}, diretor = '{filme.Diretor}' WHERE id = '{id}'";
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();

        }
    }
}
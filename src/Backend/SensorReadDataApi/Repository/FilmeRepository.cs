using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using LocadoraApi.Domain;

namespace LocadoraApi.Repository
{
    public sealed class FilmeRepository : IFilmeRepository
    {
        private readonly string _connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }



        public IEnumerable<Filme> ListAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Filme>("select * from Filme");

            return sensorData;
        }

        public int InsertFilme(Filme data)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO Filme (Titulo,ClassificacaoIndicativa,Lancamento"
                              + "VALUES ('" + data.Titulo + "', '" + data.ClassificacaoIndicativa + "', '"
                              + data.Lancamento + "')";


            try
            {
                var result = connection.Execute(query);
            }catch(Exception e)
            {

            }
            

            return 1;
        }

        public int RemoveFilme(int Id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE FROM Filme WHERE Id = " + Id;

            var result = connection.Execute(query, new { Id = Id });

            return result;
        }
    }
}


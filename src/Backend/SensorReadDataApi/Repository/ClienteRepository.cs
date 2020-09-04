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
    public sealed class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DataServer");
        }

        public IEnumerable<Cliente> ListAll()
        {
            using var connection = new SqlConnection(_connectionString);

            var sensorData = connection.Query<Cliente>("select * from sensor");

            return sensorData;
        }

        public int Insert(Cliente data)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "insert into sensor (step)values (" + data + ")";

            var result = connection.Execute(query, new { step = data });

            return result;
        }

        public int Remove(int Id)
        {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE FROM sensor WHERE Id = " + Id ;

            var result = connection.Execute(query, new { Id = Id });

            return result;
        }
    }
}


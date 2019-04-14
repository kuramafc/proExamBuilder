using Dapper;
using Microsoft.Extensions.Configuration;
using Pro.Exam.Builder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Exam.Builder.Datas
{
    public class Connection : IConnection
    {
        public static IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> Execute<T>(string query, object param = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(query, param);

                    connection.Close();
                    return result;
                } catch(Exception ex)
                {
                    var exception = ex;
                    return null;
                }
            }
        }
    }
}

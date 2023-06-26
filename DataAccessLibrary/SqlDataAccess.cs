using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {

        public string ConnectionStringName { get; set; } = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\zbcwise\\source\\repos\\CrudMvvm\\CrudMvvm\\Database1.mdf;Integrated Security=True";
        public SqlDataAccess()
        {
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = ConnectionStringName;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = ConnectionStringName;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }


    }
}

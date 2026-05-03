using System;
using Microsoft.Data.Client;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace SoftwareDesign.Storage
{
    public interface IStorage 
    {
        Task SaveAsync(string data);
        Task RetrieveAsync(int id);
    }

    public class DbStorage(string connectionString) : IStorage
    {
        private readonly string ConnectionString = connectionString;

        public async Task SaveAsync(string data)
        {
                var sql = $"INSERT INTO Storage(data) VALUES (@data)";

                await using var connection = new SqlConnection(ConnectionString);
                await using var command = new SqlCommand(sql, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@data", data);
                    await connection.OpenAsync();
                    var sqlResult = command.ExecuteNonQuery();

                    if (sqlResult == 0)
                    {
                        throw new InvalidOperationException("error to insert data to the db");
                    }
                }
        }

        public async Task RetrieveAsync(int id)
        {
            var sql = $"SELECT data FROM db.Storage WHERE id = @id";
            
                await using var connection = new SqlConnection(ConnectionString);
                await using var command = new SqlCommand(sql, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                await connection.OpenAsync();
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"{reader.GetOrdinal("data")}");
                }

                throw new Exception($"id not found");
        }
    }

    public class SD1_1 {
        public static async Task Main(string[] args) {
            
            IStorage db = new DbStorage("test connection string");

            try
            {
                await db.SaveAsync("Save data");
                Console.WriteLine("data save");

                var sqlResult = await db.RetrieveAsync(1);
                Console.WriteLine($"result {sqlResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error of the storage service {ex.Message}");
            }

        }
    }
}

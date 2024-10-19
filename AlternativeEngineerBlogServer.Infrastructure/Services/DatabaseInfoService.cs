using AlternativeEngineerBlogServer.Domain.DTOs;
using ED.Result;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlternativeEngineerBlogServer.Infrastructure.Services;
public sealed class DatabaseInfoService
{
    private readonly string _connectionString;

    public DatabaseInfoService(IConfiguration configuration)
    {
        // Bağlantı dizesini al
        _connectionString = configuration.GetConnectionString("SqlServer");
    }

    public async Task<Result<List<GetDatabaseInfoDto>>> GetDatabaseInfo()
    {
        var databaseInfoList = new List<GetDatabaseInfoDto>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (SqlCommand command = new SqlCommand("EXEC sp_helpdb @dbname;", connection))
            {

                //command.Parameters.AddWithValue("@dbname", "AlternativeEngineerBlogDb");

                command.Parameters.AddWithValue("@dbname", "erendeli_AlternativeEngineerBlogDb");

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var dbInfo = new GetDatabaseInfoDto(
                                reader["name"].ToString(),
                                reader["db_size"].ToString(),
                                reader["owner"].ToString(),
                                reader["created"].ToString()
                            );

                            databaseInfoList.Add(dbInfo);
                        }
                    }
                }
            }
        }

        return Result<List<GetDatabaseInfoDto>>.Succeed(databaseInfoList);
    }
}

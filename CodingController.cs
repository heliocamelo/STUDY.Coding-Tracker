using System.Configuration;
using Microsoft.Data.Sqlite;

namespace coding_tracker;

public class CodingController
{
    private string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

    internal void Post(Coding coding)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            using (var tableCmd = connection.CreateCommand())
            {
                connection.Open();
                tableCmd.CommandText = $"INSERT INTO coding (date, duration) VALUES ('{coding.Date}', '{coding.Duration}')";
                tableCmd.ExecuteNonQuery();
            }
        }
    }
}
using System;
using System.Data.SqlClient;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";
        
        static void Main(string[] args)
        {
            var MinionId = Console.ReadLine();

            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            if (UpdateMinionAge(SqlCon, MinionId) > 0)
                Console.WriteLine(GetMinionById(SqlCon, MinionId));
            else 
                Console.WriteLine($"No minion with {MinionId} ID was found in the database");
        }

        private static string GetMinionById(SqlConnection SqlCon, string MinionId)
        {
            var Query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            using var command = new SqlCommand(Query, SqlCon);
            command.Parameters.AddWithValue("@Id", MinionId);

            var reader = command.ExecuteReader();

            var result = string.Empty;

            while (reader.Read())
            {
                result = $"{reader["Name"]?.ToString()} – {reader["Age"]?.ToString()} years old";
            }

            return result;
        }

        private static int UpdateMinionAge(SqlConnection SqlCon, string MinionId)
        {
            var Query = @"EXEC usp_GetOlder @minionId";

            using var command = new SqlCommand(Query, SqlCon);
            command.Parameters.AddWithValue("@minionId", MinionId);

            return command.ExecuteNonQuery();
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Text;

namespace IncreaseMinionAge
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            var MinionIds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            UpdateAges(SqlCon, MinionIds);

            Console.WriteLine(GetAllMinions(SqlCon));
        }

        private static string GetAllMinions(SqlConnection sqlCon)
        {
            var sb = new StringBuilder();

            var query = @"SELECT [Name], Age FROM Minions";

            var cmd = new SqlCommand(query, sqlCon);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sb.AppendLine($"{reader["Name"]?.ToString()} {reader["Age"]?.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void UpdateAges(SqlConnection SqlCon, string[] MinionsIds)
        {
            var Query = @"UPDATE Minions
                           SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                         WHERE Id = @Id";

            foreach (var item in MinionsIds)
            {
                var cmd = new SqlCommand(Query, SqlCon);

                cmd.Parameters.AddWithValue("@Id", item);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

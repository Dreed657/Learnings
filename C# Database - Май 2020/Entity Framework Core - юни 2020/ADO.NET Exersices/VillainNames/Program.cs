using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace VillainNames
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection SqlCon = new SqlConnection(conStr);

            SqlCon.Open();

            var query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                            FROM Villains AS v
                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                        GROUP BY v.Id, v.Name
                            HAVING COUNT(mv.VillainId) > 3 
                        ORDER BY COUNT(mv.VillainId) DESC";

            var sqlCommand = new SqlCommand(query, SqlCon);

            var reader = sqlCommand.ExecuteReader();

            var sb = new StringBuilder();

            while (reader.Read())
            {
                var name = reader["Name"];
                var count = reader["MinionsCount"];

                sb.AppendLine($"{name} - {count}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}

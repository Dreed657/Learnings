using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace MinionNames
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            while (true)
            {
                int InputId = int.Parse(Console.ReadLine());

                Console.WriteLine(GetVillainInfo(InputId));
            }    
        }

        private static string GetVillainInfo(int VillainId)
        {
            var sb = new StringBuilder();

            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var Query = $@"SELECT [Name] FROM Villains WHERE Id = @VillainId";

            var getInfoCommand = new SqlCommand(Query, SqlCon);
            getInfoCommand.Parameters.AddWithValue("@VillainId", VillainId);

            try
            {
                var name = getInfoCommand.ExecuteScalar().ToString();

                sb.AppendLine($"Villain: {name}");

                sb.AppendLine(GetVillainMinions(VillainId));
            }
            catch (Exception)
            {
                sb.AppendLine($"No villain with ID {VillainId} exists in the database.");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetVillainMinions(int VillainId)
        {
            var sb = new StringBuilder();

            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var Query = $@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @VillainId
                                ORDER BY m.Name";

            var getMinionsCommand = new SqlCommand(Query, SqlCon);
            getMinionsCommand.Parameters.AddWithValue("@VillainId", VillainId);

            var reader = getMinionsCommand.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var rank = reader["RowNum"]?.ToString();
                    var name = reader["Name"]?.ToString();
                    var age = reader["Age"]?.ToString();

                    sb.AppendLine($"{rank}. {name} {age}");
                }
            }
            else
            {
                sb.AppendLine("(no minions)");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

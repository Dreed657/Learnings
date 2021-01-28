using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PrintAllMinionNames
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var query = @"SELECT [Name] FROM Minions";

            var cmd = new SqlCommand(query, SqlCon);

            var reader = cmd.ExecuteReader();

            var Names = new List<string>();

            while (reader.Read())
            {
                Names.Add(reader["Name"]?.ToString());
            }

            for (int i = 0; i < Names.Count / 2; i++)
            {
                Console.WriteLine(Names[i]);

                Console.WriteLine(Names[Names.Count - i - 1]);
            }
        }
    }
}

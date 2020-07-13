using System;
using System.Data.SqlClient;

namespace RemoveVillain
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var inputId = Console.ReadLine();

            var getVillainNameQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";

            var getVillainNameCmd = new SqlCommand(getVillainNameQuery, SqlCon);
            getVillainNameCmd.Parameters.AddWithValue("@villainId", inputId);

            var villingName = getVillainNameCmd.ExecuteScalar();

            if (villingName != null)
            {
                var releaseVillainMinionsQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @villainId";

                var releaseVillainMinionsCmd = new SqlCommand(releaseVillainMinionsQuery, SqlCon);
                releaseVillainMinionsCmd.Parameters.AddWithValue("@villainId", inputId);

                var minionsRelesed = releaseVillainMinionsCmd.ExecuteNonQuery();

                var deleteVillainQuery = @"DELETE FROM Villains WHERE Id = @villainId";

                var deleteVillainCmd = new SqlCommand(deleteVillainQuery, SqlCon);
                deleteVillainCmd.Parameters.AddWithValue("@villainId", inputId);

                deleteVillainCmd.ExecuteNonQuery();

                Console.WriteLine($"{villingName} was deleted.");
                Console.WriteLine($"{minionsRelesed} minions were released.");
            }
            else
            {
                Console.WriteLine("No such villain was found.");
            }
        }
    }
}

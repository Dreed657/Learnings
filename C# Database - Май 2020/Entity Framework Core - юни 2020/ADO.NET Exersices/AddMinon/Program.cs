using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddMinon
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using var SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var minionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var villainName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            Console.WriteLine(AddMinion(SqlCon, minionInfo, villainName));
        }

        private static string AddMinion(SqlConnection SqlCon, string[] minionInfo, string[] villainInfo)
        {
            var sb = new StringBuilder();

            var minionName = minionInfo[0];
            var minionAge = minionInfo[1];
            var minionTown = minionInfo[2];

            var villainName = villainInfo[0];

            var transaction = SqlCon.BeginTransaction();

            try
            {
                var townId = EnsureTownExists(SqlCon, sb, minionTown, transaction);
                var villainId = EnsureVillainExists(SqlCon, sb, villainName, transaction);

                InsertMinion(SqlCon, minionName, minionAge, townId, transaction);

                var minionId = GetMinionId(SqlCon, minionName, transaction);

                InsertMinionVillainsRaltion(SqlCon, villainId, minionId, transaction);

                sb.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                transaction.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rEx)
                {

                    sb.AppendLine(rEx.Message);
                }

                Console.WriteLine($"Database not changed.");

                sb.AppendLine(ex.Message);
            }

            return sb.ToString().TrimEnd();
        }

        private static void InsertMinionVillainsRaltion(SqlConnection SqlCon, string villainId, string minionId, SqlTransaction transaction)
        {
            var insertMinionVillainRelation = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using SqlCommand insertMinionsVillainsCmd = new SqlCommand(insertMinionVillainRelation, SqlCon);
            insertMinionsVillainsCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@villainId", villainId),
                new SqlParameter("@minionId", minionId),
            });

            insertMinionsVillainsCmd.Transaction = transaction;

            insertMinionsVillainsCmd.ExecuteNonQuery();
        }

        private static void InsertMinion(SqlConnection SqlCon, string Name, string Age, string townId, SqlTransaction transaction)
        {
            var insertMinionQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using SqlCommand insertMinionCmd = new SqlCommand(insertMinionQuery, SqlCon);
            insertMinionCmd.Parameters.AddWithValue("@name", Name);
            insertMinionCmd.Parameters.AddWithValue("@age", Age);
            insertMinionCmd.Parameters.AddWithValue("@townId", townId);

            insertMinionCmd.Transaction = transaction;

            insertMinionCmd.ExecuteNonQuery();
        }

        private static string GetMinionId(SqlConnection SqlCon, string minionName, SqlTransaction transaction)
        {
            var getMinionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";

            using SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQuery, SqlCon);
            getMinionIdCmd.Parameters.AddWithValue("@name", minionName);

            getMinionIdCmd.Transaction = transaction;

            return getMinionIdCmd.ExecuteScalar().ToString();
        }

        private static string EnsureVillainExists(SqlConnection sqlCon, StringBuilder sb, string villainName, SqlTransaction transaction)
        {
            var getVillainIdQuery = @"SELECT Id FROM Villains WHERE Name = @Name";

            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQuery, sqlCon);
            getVillainIdCmd.Parameters.AddWithValue("@Name", villainName);

            getVillainIdCmd.Transaction = transaction;

            var villainId = getVillainIdCmd.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                var insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                using SqlCommand insertVillain = new SqlCommand(insertVillainQuery, sqlCon);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                insertVillain.Transaction = transaction;

                insertVillain.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar().ToString();

                sb.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId;
        }

        private static string EnsureTownExists(SqlConnection sqlCon, StringBuilder sb, string minionTown, SqlTransaction transaction)
        {
            var getTownIdQuery = @"SELECT Id FROM Towns WHERE Name = @townName";

            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQuery, sqlCon);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            getTownIdCmd.Transaction = transaction;

            var townId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                var insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";

                using SqlCommand insertTownCmd = new SqlCommand(insertTownQuery, sqlCon);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.Transaction = transaction;

                insertTownCmd.ExecuteNonQuery();

                townId = getTownIdCmd.ExecuteScalar().ToString();

                sb.AppendLine($"Town {minionTown} was added to the database.");
            }

            return townId;
        }
    }
}

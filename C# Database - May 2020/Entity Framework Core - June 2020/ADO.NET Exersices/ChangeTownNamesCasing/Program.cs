using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    class Program
    {
        private const string conStr = @"Server=.;Database=MinionsDB;Integrated Security=true;";
       
        static void Main(string[] args)
        {
            var countryName = Console.ReadLine();

            using SqlConnection SqlCon = new SqlConnection(conStr);
            SqlCon.Open();

            var transaction = SqlCon.BeginTransaction();

            int rowsEffected = 0;

            try
            {
                var updateCitiesCasingQuery = @"UPDATE Towns
                                               SET Name = UPPER(Name)
                                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                var updateCitiesCmd = new SqlCommand(updateCitiesCasingQuery, SqlCon);
                updateCitiesCmd.Parameters.AddWithValue("@countryName", countryName);

                updateCitiesCmd.Transaction = transaction;

                rowsEffected = updateCitiesCmd.ExecuteNonQuery();

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
                    Console.WriteLine(rEx.Message);
                }

                Console.WriteLine(ex.Message);
            }

            var getChangedQuery = @"SELECT t.Name
	                                    FROM Towns as t
	                                    JOIN Countries AS c ON c.Id = t.CountryCode
                                    WHERE c.Name = @countryName";

            var getChangedCmd = new SqlCommand(getChangedQuery, SqlCon);
            getChangedCmd.Parameters.AddWithValue("@countryName", countryName);

            var reader = getChangedCmd.ExecuteReader();

            var cities = new List<string>();

            while (reader.Read())
            {
                cities.Add(reader["Name"]?.ToString());
            }

            if (cities.Any())
            {
                Console.WriteLine($"{rowsEffected} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", cities)}]");
            }
            else Console.WriteLine("No town names were affected.");
        }
    }
}

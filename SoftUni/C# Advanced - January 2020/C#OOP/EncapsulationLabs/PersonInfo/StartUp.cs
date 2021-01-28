using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var team = new Team("Softuni");

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                Person person = null;

                try
                {
                    person = new Person(cmdArgs[0],cmdArgs[1],int.Parse(cmdArgs[2]),decimal.Parse(cmdArgs[3]));
                    team.AddPlayer(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }


            Console.WriteLine(team.FirstTeam.Count);
            Console.WriteLine(team.ReserveTeam.Count);
        }
    }
}

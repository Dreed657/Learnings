namespace MilitaryElite
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using MilitaryElite.Models;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            var Soldiers = new List<Private>();

            while (true)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                if (tokens[0] == "End") break;

                try
                {
                    switch (tokens[0])
                    {
                        case "Private":
                            var curPrivate = new Private(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                            Soldiers.Add(curPrivate);
                            Console.WriteLine(curPrivate.ToString());
                            break;
                        case "LieutenantGeneral":
                            var curLeutenant = new LeutenantGeneral(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                            var privatesIds = tokens.Skip(5).ToList();

                            foreach (var id in privatesIds)
                            {
                                var curSoldier = Soldiers.FirstOrDefault(x => x.Id == int.Parse(id));

                                if (curSoldier != null)
                                {
                                    curLeutenant.AddPrivate(curSoldier);
                                }
                            }

                            Console.WriteLine(curLeutenant.ToString());
                            break;
                        case "Engineer":
                            var curEngineer = new Engineer(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);
                            var repairs = new Queue<string>(tokens.Skip(6));

                            while (repairs.Any())
                            {
                                try
                                {
                                    curEngineer.AddRepair(new Repair(repairs.Dequeue(), int.Parse(repairs.Dequeue())));
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            Console.WriteLine(curEngineer.ToString());
                            break;
                        case "Commando":
                            var curCommando = new Commando(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);
                            var missions = new Queue<string>(tokens.Skip(6));

                            while (missions.Any())
                            {
                                try
                                {
                                    curCommando.AddMission(new Mission(missions.Dequeue(), missions.Dequeue()));
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }

                            Console.WriteLine(curCommando.ToString());
                            break;
                        case "Spy":
                            var curSpy = new Spy(int.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4]));
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

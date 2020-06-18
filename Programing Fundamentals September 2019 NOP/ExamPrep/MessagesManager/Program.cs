using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, int>();
            int maxCapacity = int.Parse(Console.ReadLine());
            while (true)
            {
                string[] tokens = Console.ReadLine().Split("->");
                if (tokens[0] == "Statistics") break;

                switch (tokens[0])
                {
                    case "Add":
                        string username = tokens[1];
                        int addSent = int.Parse(tokens[2]);
                        int addReceived = int.Parse(tokens[3]);

                        if (!users.ContainsKey(username))
                        {
                            users.Add(username, 0);
                        }
                        users[username] += addSent + addReceived;
                        break;
                    case "Message":
                        string sender = tokens[1];
                        string receiver = tokens[2];
                        if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                        {
                            if (!((users[sender] + 1) >= maxCapacity)) users[sender]++;
                            else
                            {
                                users.Remove(sender);
                                Console.WriteLine($"{sender} reached the capacity!");
                            }
                            if (!((users[receiver] + 1) >= maxCapacity)) users[receiver]++;
                            else
                            {
                                users.Remove(receiver);
                                Console.WriteLine($"{receiver} reached the capacity!");
                            }
                        }
                        break;
                    case "Empty":
                        string deletable = tokens[1];
                        if (deletable == "All")
                        {
                            users.Clear();
                            break;
                        }
                        else if (users.ContainsKey(deletable))
                        {
                            users.Remove(deletable);
                        }
                        break;
                }
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value}");
            }
        }
    }
}

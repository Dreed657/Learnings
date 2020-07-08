namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var passedThrouth = new List<IIdible>();

            while (true)
            {
                var tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "End") break;

                if (tokens.Length == 3)
                {
                    passedThrouth.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else if (tokens.Length == 2)
                {
                    passedThrouth.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            var fakeIdEnd = Console.ReadLine();

            foreach (var item in passedThrouth)
            {
                if (item.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}

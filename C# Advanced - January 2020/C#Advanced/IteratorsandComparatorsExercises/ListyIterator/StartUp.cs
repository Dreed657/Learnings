using System;
using System.Linq;

namespace TrashyList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var create = Console.ReadLine().Split().ToList();
            ListyIterator<string> collection;

            if (create.Count > 1)
            {
                collection = new ListyIterator<string>(create.Skip(1).ToArray());
            }
            else
            {
                collection = new ListyIterator<string>();
            }

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                if (tokens[0] == "END") break;

                switch (tokens[0])
                {
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    case "PrintAll":
                        collection.PrintAll();
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                }
            }
        }
    }
}

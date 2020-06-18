using System;
using System.Collections.Generic;

namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var tokens = Console.ReadLine().Split();
                switch (i)
                {
                    case 0:
                        var name = $"{tokens[0]} {tokens[1]}";
                        var adress = tokens[2];
                        var town = tokens[3];
                        var line1 = new CustomTuple<string, string, string>(name, adress, town);
                        Console.WriteLine(line1.ToString());
                        break;
                    case 1:
                        var name2 = tokens[0];
                        var beerLitters = double.Parse(tokens[1]);
                        var drunk = tokens[2] switch
                        {
                            "drunk" => true,
                            "not" => false,
                            _ => false
                        };
                        var line2 = new CustomTuple<string, double, bool>(name2, beerLitters, drunk);
                        Console.WriteLine(line2.ToString());
                        break;
                    case 2:
                        var name3 = tokens[0];
                        var balance = double.Parse(tokens[1]);
                        var bankName = tokens[2];
                        var line3 = new CustomTuple<string, double, string>(name3, balance, bankName);
                        Console.WriteLine(line3.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

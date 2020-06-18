using System;
using System.Collections.Generic;

namespace Teamworkprojects
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
        }
    }

    class Team 
    {
        public Team(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public string[] Members { get; set; }
    }
}

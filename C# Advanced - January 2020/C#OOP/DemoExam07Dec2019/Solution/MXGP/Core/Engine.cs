namespace MXGP.Core
{
    using System;
    using System.Linq;

    using MXGP.IO.Contracts;
    using MXGP.IO;
    using MXGP.Core.Contracts;
    using System.Collections.Generic;

    public class Engine
    {
        private IWriter writer;
        private IReader reader;
        private IChampionshipController controller;

        public Engine()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.controller = new ChampionshipController();
        }

        public void Run()
        {
            var massResult = new List<string>();

            while (true)
            {
                var tokens = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] args = tokens.Skip(1).ToArray();
                string result = string.Empty;
                if (tokens[0] == "End") break;

                try
                {
                    switch (tokens[0])
                    {
                        case "StartRace":
                            result = this.controller.StartRace(args[0]);
                            break;
                        case "CreateRace":
                            result = this.controller.CreateRace(args[0], int.Parse(args[1]));
                            break;
                        case "AddRiderToRace":
                            result = this.controller.AddRiderToRace(args[0], args[1]);
                            break;
                        case "AddMotorcycleToRider":
                            result = this.controller.AddMotorcycleToRider(args[0], args[1]);
                            break;
                        case "CreateMotorcycle":
                            result = this.controller.CreateMotorcycle(args[0], args[1], int.Parse(args[2]));
                            break;
                        case "CreateRider":
                            result = this.controller.CreateRider(args[0]);
                            break;
                    }
                    massResult.Add(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            massResult.ForEach(writer.WriteLine);
        }
    }
}

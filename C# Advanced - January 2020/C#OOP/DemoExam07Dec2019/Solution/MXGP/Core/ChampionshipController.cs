namespace MXGP.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Riders;
    using MXGP.Repositories;
    using MXGP.Utilities.Messages;
    using MXGP.Models.Riders.Contracts;
    using System.Collections.Generic;

    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motoRepo;
        private RiderRepository riderRepo;
        private RaceRepository raceRepo;

        public ChampionshipController()
        {
            this.motoRepo = new MotorcycleRepository();
            this.riderRepo = new RiderRepository();
            this.raceRepo = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepo.GetByName(riderName);
            var motorcycle = this.motoRepo.GetByName(motorcycleModel);

            if (motorcycle == null) throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            if (rider == null) throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepo.GetByName(raceName);
            var rider = this.riderRepo.GetByName(riderName);

            if (race == null) throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            if (rider == null) throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = type switch
            {
                "Power" => new PowerMotorcycle(model, horsePower),
                "Speed" => new SpeedMotorcycle(model, horsePower),
                _ => null
            };

            if (motorcycle == null) throw new ArgumentException(ExceptionMessages.MotorcycleInvalid);
            if (this.motoRepo.GetByName(model) != null) throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            this.motoRepo.Add(motorcycle);

            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);

            if (this.raceRepo.GetByName(name) != null) throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            this.raceRepo.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string name)
        {
            var rider = new Rider(name);

            if (this.riderRepo.GetByName(name) != null) throw new ArgumentException(ExceptionMessages.RiderExists, name);
            this.riderRepo.Add(rider);

            return string.Format(OutputMessages.RiderCreated, name);
        }

        public string StartRace(string raceName)
        {
            var sb = new StringBuilder();
            var race = this.raceRepo.GetByName(raceName);
            int minRiders = 3;

            if (race == null) throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));

            var riders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();
            if (riders.Count != minRiders) throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, minRiders));

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, riders[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, riders[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, riders[2].Name, raceName));
            
            return sb.ToString().TrimEnd();
        }
    }
}

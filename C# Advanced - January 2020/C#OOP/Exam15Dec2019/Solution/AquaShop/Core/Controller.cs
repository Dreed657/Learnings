namespace AquaShop.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using AquaShop.Core.Contracts;
    using AquaShop.Repositories.Models;
    using AquaShop.Factories.Contracts;
    using AquaShop.Factories;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Aquariums.Contracts;

    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IDecoration> DecorationsRepository;
        private List<IAquarium> Aquariums;
        private IAquariumFactory aquariumFactory = new AquariumFactory();
        private IFishFactory fishFactory = new FishFactory();
        private IDecorationFactory decorationFactory = new DecorationFactory();

        public Controller()
        {
            this.DecorationsRepository = new DecorationRepository();
            this.Aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            var aquarium = this.aquariumFactory.CreateAquarium(aquariumType, aquariumName);

            if (aquarium == null) throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

            this.Aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            var decoration = this.decorationFactory.CreateDecoration(decorationType);

            if (decoration == null) throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            this.DecorationsRepository.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var fish = this.fishFactory.CreateFish(fishType, fishName, fishSpecies, price);
            var aquarium = this.Aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fish == null) throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            var validFish = fishType.Replace("Fish", "") == aquarium.GetType().Name.Replace("Aquarium", "");

            if (!validFish) return OutputMessages.UnsuitableWater;
            else aquarium.AddFish(fish);

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.Aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var sum = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, sum);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.Aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count());
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.DecorationsRepository.FindByType(decorationType);
            var aquarium = this.Aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.DecorationsRepository.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            this.Aquariums.ForEach(x => sb.AppendLine(x.GetInfo()));

            return sb.ToString().Trim();
        }
    }
}

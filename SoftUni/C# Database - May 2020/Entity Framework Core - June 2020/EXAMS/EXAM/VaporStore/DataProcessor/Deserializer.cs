using System.Globalization;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;
using VaporStore.XMLTools;

namespace VaporStore.DataProcessor
{
	using System;
	using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedGame
            = "Added {0} ({1}) with {2} tags";
        
        private const string SuccessfullyImportedUser
            = "Imported {0} with {1} cards";
        
        private const string SuccessfullyImportedPurchase
            = "Imported {0} for {1}";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
			var sb = new StringBuilder();
            var gamesResult = JsonConvert.DeserializeObject<GameDto[]>(jsonString);

            var validGames = new List<Game>();

            foreach (var gameDto in gamesResult)
            {
                if (!IsValid(gameDto) || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
					continue;
                }

                var isDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var ValidReleaseDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = ValidReleaseDate,
                };

                var validDeveloper = context.Developers.FirstOrDefault(x => x.Name.Trim() == gameDto.Developer.Trim()) ??
                                     new Developer { Name = gameDto.Developer };

                var validGenre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre) ??
                                     new Genre { Name = gameDto.Genre };

                game.Developer = validDeveloper;
                game.Genre = validGenre;

                foreach (var tagName in gameDto.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim()) ??
                              new Tag {Name = tagName};

                    game.GameTags.Add(new GameTag { Tag = tag, Game = game});
                }

                validGames.Add(game);

                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.Games.AddRange(validGames);
            context.SaveChanges();
            //sb.AppendLine($"{context.Games.Count()} games, {context.Developers.Count()} developers, {context.Genres.Count()} genres and {context.Tags.Count()} tags");

            return sb.ToString().Trim();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var usersResults = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var validUsers = new List<User>();

            foreach (var userDto in usersResults)
            {
                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
                    };

                    user.Cards.Add(card);
                }

                validUsers.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            //sb.AppendLine($"{context.Users.Count()} users, {context.Cards.Count()} cards");

            return sb.ToString().Trim();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var sb = new StringBuilder();
            var purchasesResult = XmlConverter.Deserializer<PurchaseDto>(xmlString, "Purchases");
            var validPurchases = new List<Purchase>();

            foreach (var purchaseDto in purchasesResult)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out var validDate);

                if (!isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);

                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validCard = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

                if (validCard == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var purchase = new Purchase()
                {
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Card = validCard,
                    Game = game,
                    Date = validDate
                };

                validPurchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            //sb.AppendLine($"{context.Purchases.Count()} purchases");
            
            return sb.ToString().Trim();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Newtonsoft.Json;
using VaporStore.DataProcessor.Dto.Export;
using VaporStore.XMLTools;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var data = context.Genres
                .ToList()
                .Where(x => genreNames.Distinct().Contains(x.Name))
                .Select(x => new
                {
                    x.Id,
                    Genre = x.Name,
                    Games = x.Games
                        .Where(g => g.Purchases.Count > 0)
                        .Select(g => new
                        {
                            g.Id,
                            Title = g.Name,
                            Developer = g.Developer.Name,
                            Tags = string.Join(", ", g.GameTags.Select(gt => gt.Tag.Name)),
                            Players = g.Purchases.Count
                        })
                        .OrderByDescending(g => g.Players)
                        .ThenBy(g => g.Id)
                        .ToList(),
                    TotalPlayers = x.Games.SelectMany(g => g.Purchases).Count(),
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var purchase = context.Users
                .ToList()
                .Where(x => x.Cards.Any(p => p.Purchases.Any()))
                .Select(x => new ExportUserDto
                {
                    Username = x.Username,
                    Purchases = x.Cards.SelectMany(i => i.Purchases.Select(p => new ExportPurchaseDto
                    {
                        Cvc = p.Card.Cvc,
                        Card = p.Card.Number,
                        Date = p.Date,
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    }))
                        .OrderBy(h => h.Date)
                    .ToArray(),
                    TotalSpend = x.Cards.Select(p => p.Purchases.Sum(o => o.Game.Price)).First()
                })
                .OrderByDescending(x => x.TotalSpend)
                .ThenBy(x => x.Username)
                .ToList();

            return XmlConverter.Serialize(purchase, "Purchases");
        }
	}
}

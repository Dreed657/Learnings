using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddCard(AddCardInputModel model)
        {
            var entity = new Card()
            {
                Attack = model.Attack,
                Health = model.Health,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.Image,
                Keyword = model.Keyword,
            };

            this.db.Cards.Add(entity);
            this.db.SaveChanges();
        }

        public List<CardViewModel> GetAllCards()
        {
            return this.db.Cards
                .Select(x => new CardViewModel()
                {
                    Id = x.Id,
                    Attack = x.Attack,
                    Health = x.Health,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                }).ToList();
        }

        public List<CardViewModel> GetAllCardsByUserId(string userId)
        {
            return this.db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => x.Card)
                .Select(x => new CardViewModel()
                {
                    Id = x.Id,
                    Attack = x.Attack,
                    Health = x.Health,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();
        }

        public void AddCardToCollection(string userId, int cardId)
        {
            this.db.UserCards.Add(new UserCard()
            {
                UserId = userId,
                CardId = cardId,
            });
            this.db.SaveChanges();
        }

        public void RemoveCardFromCollection(int cardId)
        {
            var entity = this.db.UserCards.FirstOrDefault(x => x.CardId == cardId);

            this.db.Remove(entity);
            this.db.SaveChanges();
        }
    }
}

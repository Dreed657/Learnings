using BattleCards.ViewModels.Cards;
using System.Collections;
using System.Collections.Generic;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void AddCard(AddCardInputModel model);

        void AddCardToCollection(string userId, int cardId);

        void RemoveCardFromCollection(int cardId); 

        List<CardViewModel> GetAllCards();

        List<CardViewModel> GetAllCardsByUserId(string userId);
    }
}

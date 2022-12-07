using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizletBackend.Dtos.Card;

namespace quizletBackend.Services.CardService
{
    public interface ICardService
    {
        Task<ServiceResponse<GetCardDto>> CreateCard(CreateCardDto newCard);
        Task<ServiceResponse<GetCardDto>> UpdateCard(UpdateCardDto updatedCard);
        Task<ServiceResponse<int>> Delete(int id);
    }
}
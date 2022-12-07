using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quizletBackend.Dtos.Card;
using quizletBackend.Services.CardService;

namespace quizletBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> CreateCard(CreateCardDto newCard)
        {
            var response = await _cardService.CreateCard(newCard);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCardDto>>> UpdateCard(UpdateCardDto updatedCard)
        {
            var response = await _cardService.UpdateCard(updatedCard);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<int>>> Delete(int id)
        {
            var response = await _cardService.Delete(id);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
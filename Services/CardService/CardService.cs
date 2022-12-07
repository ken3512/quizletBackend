using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using quizletBackend.Data;
using quizletBackend.Dtos.Card;

namespace quizletBackend.Services.CardService
{
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CardService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetCardDto>> CreateCard(CreateCardDto newCard)
        {
            var response = new ServiceResponse<GetCardDto>();

            try
            {
                Card card = _mapper.Map<Card>(newCard);
                NoteSet noteSet = await _context.NoteSets.FirstOrDefaultAsync(n => n.Id == card.NoteSetId && n.UserId == GetUserId()); 
                if(noteSet == null)
                {
                    response.Success = false;
                    response.Message = "NoteSet does not exist.";
                    return response;
                }

                card.NoteSet = noteSet;
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCardDto>(card);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Delete(int id)
        {
            var response = new ServiceResponse<int>();

            try
            {
                Card card = await _context.Cards
                .Include(c => c.NoteSet)
                .FirstOrDefaultAsync(c => c.Id == id && c.NoteSet.UserId == GetUserId());

                if(card == null)
                {
                    response.Success = false;
                    response.Message = "card does not exist.";
                    return response;
                }

                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();

                response.Message = "Card deleted successfully.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCardDto>> UpdateCard(UpdateCardDto updatedCard)
        {
            var response = new ServiceResponse<GetCardDto>();

            try
            {
                Card card = await _context.Cards
                .Include(c => c.NoteSet)
                .FirstOrDefaultAsync(c => c.Id == updatedCard.Id && c.NoteSet.UserId == GetUserId());

                if(card == null)
                {
                    response.Success = false;
                    response.Message = "card does not exist.";
                    return response;
                }

                if(updatedCard.front != string.Empty)
                {
                    card.front = updatedCard.front;
                }

                if(updatedCard.back != string.Empty)
                {
                    card.back = updatedCard.back;
                }

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCardDto>(card);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
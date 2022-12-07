using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using quizletBackend.Data;
using quizletBackend.Dtos.NoteSet;

namespace quizletBackend.Services.NoteSetService
{
    public class NoteSetService : INoteSetService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NoteSetService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User
            .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<GetNoteSetNameDto>> CreateNoteSet(CreateNoteSetDto newNoteSet)
        {
            var response = new ServiceResponse<GetNoteSetNameDto>();

            try
            {
                NoteSet noteSet = _mapper.Map<NoteSet>(newNoteSet);
                noteSet.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
                _context.NoteSets.Add(noteSet);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetNoteSetNameDto>(noteSet);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<int>> DeleteNoteSet(int id)
        {
            var response = new ServiceResponse<int>();

            try
            {
                NoteSet noteSet = await _context.NoteSets
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == GetUserId());

                if(noteSet == null)
                {
                    response.Success = false;
                    response.Message = "NoteSet does not exist.";
                    return response;
                }

                _context.NoteSets.Remove(noteSet);
                await _context.SaveChangesAsync();

                response.Message = "NoteSet deleted successfully.";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetNoteSetDto>> GetNoteSet(int id)
        {
            var response = new ServiceResponse<GetNoteSetDto>();

            try
            {
                NoteSet noteSet = await _context.NoteSets
                .Include(n => n.User)
                .Include(n => n.Cards)
                .FirstOrDefaultAsync(n => n.Id == id && (n.UserId == GetUserId() || n.publicView));

                if(noteSet == null)
                {
                    response.Success = false;
                    response.Message = "NoteSet does not exist.";
                    return response;
                }

                response.Data = _mapper.Map<GetNoteSetDto>(noteSet);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetNoteSetNameDto>>> Search(string search)
        {
            var response = new ServiceResponse<List<GetNoteSetNameDto>>();

            try
            {
                var dbNoteSet = await _context.NoteSets
                    .Include(n => n.User)
                    .Where(n => (n.UserId == GetUserId() || n.publicView) && n.title.ToLower().Contains(search.ToLower()))
                    .ToListAsync();

                response.Data = dbNoteSet.Select(n => _mapper.Map<GetNoteSetNameDto>(n)).ToList();
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
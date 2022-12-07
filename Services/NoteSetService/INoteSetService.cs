using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizletBackend.Dtos.NoteSet;

namespace quizletBackend.Services.NoteSetService
{
    public interface INoteSetService
    {
        Task<ServiceResponse<List<GetNoteSetNameDto>>> Search(string search);
        Task<ServiceResponse<GetNoteSetDto>> GetNoteSet(int id);
        Task<ServiceResponse<GetNoteSetNameDto>> CreateNoteSet(CreateNoteSetDto newNoteSet);
        Task<ServiceResponse<int>> DeleteNoteSet(int id);
    }
}
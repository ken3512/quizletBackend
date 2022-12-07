using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizletBackend.Dtos.Card;
using quizletBackend.Dtos.User;

namespace quizletBackend.Dtos.NoteSet
{
    public class GetNoteSetDto
    {
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
        public GetUserDto User { get; set; }
        public List<GetCardDto> Cards { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizletBackend.Dtos.Card;
using quizletBackend.Dtos.User;

namespace quizletBackend.Dtos.NoteSet
{
    public class GetNoteSetNameDto
    {
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
        public bool publicView { get; set; }
        public GetUserDto User { get; set; }
    }
}
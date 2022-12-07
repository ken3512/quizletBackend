using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizletBackend.Dtos.NoteSet
{
    public class UpdateNoteSetDto
    {
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
    }
}
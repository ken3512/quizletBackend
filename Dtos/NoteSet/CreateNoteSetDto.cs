using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizletBackend.Dtos.NoteSet
{
    public class CreateNoteSetDto
    {
        public bool publicView { get; set; } = false;
        public string title { get; set; } = string.Empty;
    }
}
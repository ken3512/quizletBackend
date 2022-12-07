using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizletBackend.models
{
    public class Card
    {
        public int Id { get; set; }
        public string front { get; set; } = string.Empty;
        public string back { get; set; } = string.Empty;
        public NoteSet NoteSet { get; set; }
        public int NoteSetId { get; set; }
    }
}
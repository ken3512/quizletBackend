using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizletBackend.models
{
    public class NoteSet
    {
        public int Id { get; set; }
        public bool publicView { get; set; } = false;
        public string title { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Card> Cards { get; set; }
    }
}
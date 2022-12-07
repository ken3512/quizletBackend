using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizletBackend.Dtos.Card
{
    public class GetCardDto
    {
        public int Id { get; set; }
        public string front { get; set; } = string.Empty;
        public string back { get; set; } = string.Empty;
    }
}
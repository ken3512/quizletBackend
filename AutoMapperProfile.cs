using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using quizletBackend.Dtos.Card;
using quizletBackend.Dtos.NoteSet;
using quizletBackend.Dtos.User;

namespace quizletBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Card, GetCardDto>();
            CreateMap<NoteSet, GetNoteSetDto>();
            CreateMap<NoteSet, GetNoteSetNameDto>();
            CreateMap<CreateCardDto, Card>();
            CreateMap<CreateNoteSetDto, NoteSet>();
            CreateMap<User, GetUserDto>();
        }
    }
}
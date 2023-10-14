using AutoMapper;
using Character_Management.Application.DTOs.character;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Character, CharacterListDto>().ReverseMap();
            CreateMap<CharacterType, CreateCharacterTypeDto>().ReverseMap();

        }
    }
}

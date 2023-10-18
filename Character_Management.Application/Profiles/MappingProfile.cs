using AutoMapper;
using Character_Management.Application.DTOs.character;
using Character_Management.Application.DTOs.Character;
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
            #region Character Mapping
            CreateMap<Character, CharacterDto>().ReverseMap();
            CreateMap<Character, CharacterListDto>().ReverseMap();
            CreateMap<Character, CreateCharacterDto>().ReverseMap();
            CreateMap<Character, UpdateCharacterDto>().ReverseMap();
            #endregion
            
            #region CharacterType Mapping
            CreateMap<CharacterType, CreateCharacterTypeDto>().ReverseMap();
            CreateMap<CharacterType, UpdateCharacterTypeDto>().ReverseMap();
            CreateMap<CharacterType, CharacterTypeDto>().ReverseMap();
            #endregion
        }
    }
}

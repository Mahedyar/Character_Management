using AutoMapper;
using Character_Management.MVC.Models;
using Character_Management.MVC.Services.Base;

namespace Character_Management.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCharacterTypeDto, CreateCharacterTypeVM>().ReverseMap();
            CreateMap<CharacterTypeDto, CharacterTypeVM>().ReverseMap();
            CreateMap<UpdateCharacterTypeDto, CharacterTypeVM>().ReverseMap();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Character_Management.Application.DTOs.common;

namespace Character_Management.Application.DTOs.CharacterType
{
    public class CharacterTypeDto : BaseDto, ICharacterTypeDto 
    {
        public string Type { get ; set ; }
    }
}

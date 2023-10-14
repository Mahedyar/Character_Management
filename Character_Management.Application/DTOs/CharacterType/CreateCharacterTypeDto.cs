using Character_Management.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.CharacterType
{
    public class CreateCharacterTypeDto:ICharacterTypeDto
    {
        public string Type { get; set; }
    }
}

using Character_Management.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.CharacterType
{
    public class UpdateCharacterTypeDto:BaseDto
    {
        public string Type { get; set; }
    }
}

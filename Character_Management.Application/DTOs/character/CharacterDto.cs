﻿using Character_Management.Application.DTOs.Character;
using Character_Management.Application.DTOs.CharacterType;
using Character_Management.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Domain
{
    public class CharacterDto : BaseDto,ICharacterDto
    {
        public string Name { get; set; }
        public string House { get; set; }
        public CreateCharacterTypeDto CharacterType { get; set; }
        public int CharacterTypeId { get; set; }
        public string? Story { get; set; }
        public string? AbilityDescription { get; set; }
        public string? AbilityType { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? RespondedDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set;}


    }
}

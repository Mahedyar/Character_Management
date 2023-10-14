﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Application.DTOs.Character
{
    public interface ICharacterTypeDto
    {
        public string Name { get; set; }
        public string House { get; set; }
        public int CharacterTypeID { get; set; }
        public string? Story { get; set; }
        public string? AbilityDescription { get; set; }
        public string? AbilityType { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
    }
}

using Character_Management.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Domain
{
    public class CharacterDto : BaseDto
    {
        public string Name { get; set; }
        public string House { get; set; }
        public CharacterTypeDto CharacterType { get; set; }
        public int CharacterTypeID { get; set; }
        public string? Story { get; set; }
        public string? AbilityDescription { get; set; }
        public string? AbilityType { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set;}


    }
}

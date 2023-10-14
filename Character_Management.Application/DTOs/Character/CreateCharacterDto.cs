using System;

namespace Character_Management.Application.DTOs.Character
{
    public class CreateCharacterDto :ICharacterDto
    {
        public string Name { get; set; }
        public string House { get; set; }
        public int CharacterTypeID { get; set; }
        public string? Story { get; set; }
        public string? AbilityDescription { get; set; }
        public string? AbilityType { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public DateTime RequestDate { get; set; }

    }
}

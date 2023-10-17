using Character_Management.Domain.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Domain
{
    public class Character : BaseDomainEntity
    {
        public string Name { get; set; }
        public string House { get; set; }
        public CharacterType? CharacterType { get; set; }
        public int? CharacterTypeID { get; set; }
        public string? Story { get; set; }
        public string? AbilityDescription { get; set; }
        public string? AbilityType { get; set; }
        public string? Continent { get; set; }
        public string? Country { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime RespondedDate { get; set; }
        public bool? Approved { get; set; }
        public bool? Cancelled { get; set;}


    }
}

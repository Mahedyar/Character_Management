using Character_Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Persistence.Configurations.Entities
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasData(
                new Character
            {
                Id = 1,
                CharacterTypeId = 1,
                AbilityType = "Mohajem",
                Name = "Arvid",
                House = "Raviz"
            }
                );


        }
    }
}

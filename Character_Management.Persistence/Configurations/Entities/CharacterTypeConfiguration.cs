using Character_Management.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Persistence.Configurations.Entities
{
    public class CharacterTypeConfiguration : IEntityTypeConfiguration<CharacterType>
    {
        public void Configure(EntityTypeBuilder<CharacterType> builder)
        {
            builder.HasData(
                new CharacterType
                {
                    ID = 1,
                    Type = "AshrafZade",
                },
                new CharacterType
                {
                    ID = 2,
                    Type = "JangJu"
                }
                );
        }
    }
}

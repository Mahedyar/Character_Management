using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "7c2c6311-a7e4-49e3-a41d-965704987e04",
                    RoleId = "c620cc19-cbcb-44db-a44f-a6067ea0dfe1"
                },
                 new IdentityUserRole<string>
                 {
                     UserId = "52f5e9ef-afa8-41ca-8e62-6a7b902f8af9",
                     RoleId = "9d4c2bef-df13-45ce-81a7-3da855aff6fe"
                 }
                );
        }
    }
}

using Character_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "7c2c6311-a7e4-49e3-a41d-965704987e04",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "Admin",
                    LastName = "AdminFamliy",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "12345"),
                    EmailConfirmed = true
                },
                 new ApplicationUser 
                 {
                     Id = "52f5e9ef-afa8-41ca-8e62-6a7b902f8af9",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "12345"),
                     EmailConfirmed = true
                 }


                );
        }
    }
}

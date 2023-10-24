using Character_Management.Identity.Configurations;
using Character_Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Identity
{
    public class CharacterManagementIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public CharacterManagementIdentityDbContext(DbContextOptions<CharacterManagementIdentityDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}

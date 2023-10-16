using Character_Management.Application.Contracts.Persistence;
using Character_Management.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Character_Management.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CharacterManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CharacterManagementConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<ICharacterTypeRepository, CharacterTypeRepository>();

            return services;
        }
    }
}

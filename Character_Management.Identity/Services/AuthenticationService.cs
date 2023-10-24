using Character_Management.Application.Contracts.Identity;
using Character_Management.Application.Models.Identity;
using Character_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager , IOptions<JwtSettings> jwtSettings , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _signInManager = signInManager;
        }
        public Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if(existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' Already Exists");
            }
            var user = new ApplicationUser {
               Email = request.Email,
               FirstName = request.FirstName,
               LastName = request.LastName,
               UserName = request.UserName,
               EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if(existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }

            else
            {
                throw new Exception($"Email '{request.Email}' Already Exists .");
            }
        }
    }
}

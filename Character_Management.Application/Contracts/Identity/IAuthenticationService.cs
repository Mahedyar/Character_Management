using Character_Management.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Character_Management.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

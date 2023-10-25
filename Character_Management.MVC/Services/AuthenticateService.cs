using Character_Management.MVC.Contracts;
using Character_Management.MVC.Services.Base;
using System.IdentityModel.Tokens.Jwt;

namespace Character_Management.MVC.Services
{
    public class AuthenticateService : BaseHttpService, IAuthenticateService
    {
        private readonly IClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticateService(IClient client , ILocalStorageService localStorage , IHttpContextAccessor httpContextAccessor) :base(client , localStorage)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public Task<bool> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(string firstName, string lastName, string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}

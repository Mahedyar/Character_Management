using Character_Management.MVC.Contracts;
using Character_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthenticationRequest authenticationRequest = new()
                {
                    Email = email, Password = password
                };
                var authenticateResponse = await _client.LoginAsync(authenticationRequest);
                if(authenticateResponse.Token != string.Empty)
                {
                    var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(authenticateResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);

                    _localStorageService.SetStorageValue("token", authenticateResponse.Token);
                    return true;
                }
                return false;
            }
            catch
            {
                return false; 
            }
           
        }

        public async Task Logout()
        {
            _localStorageService.ClearStorage(new List<string>() { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public Task<bool> Register(string firstName, string lastName, string userName, string password)
        {
            throw new NotImplementedException();
        }

        private IList<Claim> ParseClaims(JwtSecurityToken token)
        {
            var claims = token.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, token.Subject));
            return claims;
        }


    }
}

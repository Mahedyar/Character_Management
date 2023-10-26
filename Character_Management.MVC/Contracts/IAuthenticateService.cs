using Character_Management.MVC.Models;

namespace Character_Management.MVC.Contracts
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM register);

        Task Logout();
    }
}

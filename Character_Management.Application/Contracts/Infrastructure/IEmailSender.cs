using Character_Management.Application.Models;
using System.Threading.Tasks;

namespace Character_Management.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}

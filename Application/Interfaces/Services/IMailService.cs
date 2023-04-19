using System.Threading.Tasks;
using WordyWellHero.Application.Requests.Mail;

namespace WordyWellHero.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
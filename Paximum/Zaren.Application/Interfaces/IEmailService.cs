using Zaren.Application.Models;
using System.Threading.Tasks;

namespace Zaren.Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
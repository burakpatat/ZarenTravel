using Zaren.Domain;
using System.Threading.Tasks;

namespace Zaren.Application.Services.Interfaces
{
    public interface IUsersService
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task ActivateUser(int id);
        Task SoftDelete(User us);
        Task EditUser(User us);
    }
}
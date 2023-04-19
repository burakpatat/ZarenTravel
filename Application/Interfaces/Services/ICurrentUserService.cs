using WordyWellHero.Application.Interfaces.Common;

namespace WordyWellHero.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}
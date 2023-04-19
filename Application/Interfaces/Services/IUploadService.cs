using WordyWellHero.Application.Requests;

namespace WordyWellHero.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}
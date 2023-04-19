using System.Threading.Tasks;
using WordyWellHero.Application.Features.Documents.Commands.AddEdit;
using WordyWellHero.Application.Features.Documents.Queries.GetAll;
using WordyWellHero.Application.Features.Documents.Queries.GetById;
using WordyWellHero.Application.Requests.Documents;
using WordyWellHero.Shared.Wrapper;

namespace WordyWellHero.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}
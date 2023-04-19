using WordyWellHero.Application.Interfaces.Repositories;
using WordyWellHero.Domain.Entities.Misc;

namespace WordyWellHero.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly IRepositoryAsync<DocumentType, int> _repository;

        public DocumentTypeRepository(IRepositoryAsync<DocumentType, int> repository)
        {
            _repository = repository;
        }
    }
}
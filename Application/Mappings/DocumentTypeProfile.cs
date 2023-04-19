using AutoMapper;
using WordyWellHero.Application.Features.DocumentTypes.Commands.AddEdit;
using WordyWellHero.Application.Features.DocumentTypes.Queries.GetAll;
using WordyWellHero.Application.Features.DocumentTypes.Queries.GetById;
using WordyWellHero.Domain.Entities.Misc;

namespace WordyWellHero.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}
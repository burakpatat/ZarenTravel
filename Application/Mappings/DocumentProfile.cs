using AutoMapper;
using WordyWellHero.Application.Features.Documents.Commands.AddEdit;
using WordyWellHero.Application.Features.Documents.Queries.GetById;
using WordyWellHero.Domain.Entities.Misc;

namespace WordyWellHero.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}
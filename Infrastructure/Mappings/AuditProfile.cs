using AutoMapper;
using WordyWellHero.Application.Responses.Audit;
using WordyWellHero.Infrastructure.Models.Audit;

namespace WordyWellHero.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}
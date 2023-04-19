using AutoMapper;
using WordyWellHero.Application.Requests.Identity;
using WordyWellHero.Application.Responses.Identity;

namespace WordyWellHero.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}
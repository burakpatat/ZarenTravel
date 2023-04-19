using AutoMapper;
using WordyWellHero.Application.Responses.Identity;
using WordyWellHero.Infrastructure.Models.Identity;

namespace WordyWellHero.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}
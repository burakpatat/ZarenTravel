using AutoMapper;
using WordyWellHero.Application.Interfaces.Chat;
using WordyWellHero.Application.Models.Chat;
using WordyWellHero.Infrastructure.Models.Identity;

namespace WordyWellHero.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}
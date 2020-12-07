using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Domain.Entities.GamesAggregate;

namespace Invillia.Challenge.Application.AutoMapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<CreateGameDto, Game>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateGameDto, Game>();
        }
    }
}

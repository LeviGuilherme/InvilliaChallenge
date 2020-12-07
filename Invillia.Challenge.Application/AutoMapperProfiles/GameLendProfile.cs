using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Domain.Entities;

namespace Invillia.Challenge.Application.AutoMapperProfiles
{
    public class GameLendProfile : Profile
    {
        public GameLendProfile()
        {
            CreateMap<GameLend, GameLendDto>();
            CreateMap<CreateGameLendDto, GameLend>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateGameLendDto, GameLend>();
        }
    }
}

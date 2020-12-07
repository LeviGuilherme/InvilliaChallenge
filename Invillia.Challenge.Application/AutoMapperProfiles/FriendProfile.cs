using AutoMapper;
using Invillia.Challenge.Application.DataTransferObjects;
using Invillia.Challenge.Domain.Entities.FriendsAggregate;

namespace Invillia.Challenge.Application.AutoMapperProfiles
{
    public class FriendProfile : Profile
    {
        public FriendProfile()
        {
            CreateMap<Friend, FriendDto>();
            CreateMap<CreateFriendDto, Friend>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<UpdateFriendDto, Friend>();
        }
    }
}

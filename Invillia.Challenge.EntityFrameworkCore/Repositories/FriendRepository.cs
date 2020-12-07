using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Repositories;
using System;

namespace Invillia.Challenge.EntityFrameworkCore.Repositories
{
    public class FriendRepository : Repository<Friend, Guid>, IFriendRepository
    {
        public FriendRepository(ApplicationDbContext context) : base(context) { }
    }
}

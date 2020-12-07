using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.RepositoryContracts;
using System;

namespace Invillia.Challenge.Domain.Repositories
{
    public interface IFriendRepository : IRepository<Friend, Guid>
    {
    }
}

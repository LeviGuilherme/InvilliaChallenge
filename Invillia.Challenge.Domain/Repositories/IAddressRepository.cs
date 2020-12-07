using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.RepositoryContracts;
using System;

namespace Invillia.Challenge.Domain.Repositories
{
    public interface IAddressRepository : IRepository<Address, Guid>
    {
    }
}

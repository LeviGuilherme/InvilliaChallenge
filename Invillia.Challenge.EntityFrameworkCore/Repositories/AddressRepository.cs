using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Repositories;
using System;

namespace Invillia.Challenge.EntityFrameworkCore.Repositories
{
    public class AddressRepository : Repository<Address, Guid>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context) { }
    }
}

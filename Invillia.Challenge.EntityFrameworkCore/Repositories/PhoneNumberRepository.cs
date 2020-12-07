using Invillia.Challenge.Domain.Entities.FriendsAggregate;
using Invillia.Challenge.Domain.Repositories;
using System;

namespace Invillia.Challenge.EntityFrameworkCore.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumber, Guid>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(ApplicationDbContext context) : base(context) { }
    }
}

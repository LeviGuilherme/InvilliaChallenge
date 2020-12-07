using Invillia.Challenge.Domain.Entities;
using Invillia.Challenge.Domain.Repositories;
using System;

namespace Invillia.Challenge.EntityFrameworkCore.Repositories
{
    public class GameLendRepository : Repository<GameLend, Guid>, IGameLendRepository
    {
        public GameLendRepository(ApplicationDbContext context) : base(context) { }
    }
}

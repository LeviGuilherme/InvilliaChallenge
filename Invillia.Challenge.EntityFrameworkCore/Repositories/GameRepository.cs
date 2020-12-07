using Invillia.Challenge.Domain.Entities.GamesAggregate;
using Invillia.Challenge.Domain.Repositories;
using System;

namespace Invillia.Challenge.EntityFrameworkCore.Repositories
{
    public class GameRepository : Repository<Game, Guid>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context) { }
    }
}

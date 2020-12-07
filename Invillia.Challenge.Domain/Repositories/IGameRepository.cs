using Invillia.Challenge.Domain.Entities.GamesAggregate;
using Invillia.Challenge.Domain.RepositoryContracts;
using System;

namespace Invillia.Challenge.Domain.Repositories
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
    }
}

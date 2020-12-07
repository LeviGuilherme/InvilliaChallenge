using Invillia.Challenge.Domain.Entities;
using Invillia.Challenge.Domain.RepositoryContracts;
using System;

namespace Invillia.Challenge.Domain.Repositories
{
    public interface IGameLendRepository : IRepository<GameLend, Guid>
    {
    }
}

using System;
using System.Threading.Tasks;

namespace Invillia.Challenge.Domain.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}

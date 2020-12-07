using Invillia.Challenge.Domain.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Invillia.Challenge.EntityFrameworkCore
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private bool _disposed = false;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            CheckObjectDisposed();

            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            CheckObjectDisposed();

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

            _context.Dispose();
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing && _context != null)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        private void CheckObjectDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

    }
}

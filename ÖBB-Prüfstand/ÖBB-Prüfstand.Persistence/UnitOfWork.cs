using Microsoft.EntityFrameworkCore;
using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        public IOEBBPrueferRepository PrueferRepository { get;}

        public IOEBBAntriebseinheitRepository AntriebseinheitsRepository { get; }

        public IOEBBAntriebskomponentenRepository AntriebskomponentenRepository { get; }

        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            PrueferRepository = new OEBBPrueferRepository(_dbContext);
            AntriebseinheitsRepository = new OEBBAntriebseinheitRepository(_dbContext);
            AntriebskomponentenRepository = new OEBBAntriebskomponentenRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteDatabaseAsync() => await _dbContext.Database.EnsureDeletedAsync();
        public async Task MigrateDatabaseAsync() => await _dbContext.Database.MigrateAsync();
        public async Task CreateDatabaseAsync() => await _dbContext.Database.EnsureCreatedAsync();

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    await _dbContext.DisposeAsync();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

    }
}

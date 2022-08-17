using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {

        public IOEBBPrueferRepository PrueferRepository { get; }
        public IOEBBAntriebseinheitRepository AntriebseinheitsRepository { get; }
        public IOEBBAntriebskomponentenRepository AntriebskomponentenRepository { get; }

        Task<int> SaveChangesAsync();

        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
        Task CreateDatabaseAsync();
    }
}

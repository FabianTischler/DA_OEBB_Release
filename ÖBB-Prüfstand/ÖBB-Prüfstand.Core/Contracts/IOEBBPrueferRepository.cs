using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Contracts
{
    public interface IOEBBPrueferRepository : IGenericRepository<OEBBPruefer>
    {
        Task<IEnumerable<OEBBPruefer>> GetAllAsync();
        Task AddMemberAsync(OEBBPruefer pruefer);
        Task<OEBBPruefer> GetPrueferById(int id);
        Task<bool> DeleteAsync(int id);
    }
}

using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Contracts
{
    public interface IOEBBAntriebseinheitRepository :IGenericRepository<OEBBAntriebseinheit>
    {
        Task<OEBBAntriebseinheit> GetByNummerAsync(string nummer);
        Task<IEnumerable<OEBBAntriebseinheit>> GetAllAsync();
        Task AddMemberAsync(OEBBAntriebseinheit antriebseinheit);
        Task<IEnumerable<OEBBAntriebskomponenten>> GetAntriebskomponentenAsync(string antriebsnummer);
        Task<bool> DeleteAsync(string nummer);
    }
}

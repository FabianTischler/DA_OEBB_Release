using OEBB_Pruefstand.Core.DTOs;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Contracts
{
    public interface IOEBBAntriebskomponentenRepository : IGenericRepository<OEBBAntriebskomponenten>
    {
        Task AddMemberAsync(OEBBAntriebskomponenten antriebskomponente);
        Task<IEnumerable<OEBBAntriebskomponenten>> GetAllAsync();
        Task<bool> DeleteAsync(string nummer);
        Task<IEnumerable<KomponentenDTO>> GetKomponentenByAntriebsId(string nummer);
        Task<OEBBAntriebskomponenten> GetKomponenteByNummer(string nummer);
    }
}

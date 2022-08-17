using Microsoft.EntityFrameworkCore;
using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.DTOs;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Persistence.Repositories
{
    public class OEBBAntriebskomponentenRepository : GenericRepository<OEBBAntriebskomponenten>, IOEBBAntriebskomponentenRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OEBBAntriebskomponentenRepository(ApplicationDbContext context) : base(context)
        {
            this._dbcontext = context;
        }

        public async Task<bool> DeleteAsync(string nummer)
        {
            var komponente = await GetKomponenteByNummer(nummer);
            if(komponente == null)
            {
                return false;
            }
            this._dbcontext.Antriebskomponenten
                .Remove(komponente);
            await this._dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OEBBAntriebskomponenten>> GetAllAsync()
        {
            return await this._dbcontext.Antriebskomponenten
                .Select(ak => ak).ToListAsync();
        }

        public async Task AddMemberAsync(OEBBAntriebskomponenten antriebskomponente)
        {
            await this._dbcontext.Antriebskomponenten
                .AddAsync(antriebskomponente);
        }

        public async Task<IEnumerable<KomponentenDTO>> GetKomponentenByAntriebsId(string nummer)
        {
            return await this._dbcontext.Antriebskomponenten
                .Include(ak => ak.Antriebseinheit)
                .Select(ak => new KomponentenDTO
                {
                    AntriebsNummer = nummer,
                    Bezeichnung = ak.Bezeichnung,
                    KomponentenNummer = ak.Nummer,
                    Leistung = ak.Leistung,
                    Baujahr = ak.Baujahr,
                    PrueferName = ak.Antriebseinheit.Pruefer.Name
                }).Where(ak => ak.AntriebsNummer == nummer)
                .ToListAsync();
        }

        public async Task<OEBBAntriebskomponenten> GetKomponenteByNummer(string nummer)
        {
            return await this._dbcontext.Antriebskomponenten
                .FirstOrDefaultAsync(ak => ak.Nummer == nummer);
        }
    }
}

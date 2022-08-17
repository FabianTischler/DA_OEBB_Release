using Microsoft.EntityFrameworkCore;
using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Persistence.Repositories
{
    public class OEBBAntriebseinheitRepository : GenericRepository<OEBBAntriebseinheit>, IOEBBAntriebseinheitRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public OEBBAntriebseinheitRepository(ApplicationDbContext context) : base(context)
        {
            this._dbcontext = context;
        }

        public async Task<IEnumerable<OEBBAntriebseinheit>> GetAllAsync()
        {
            return await this._dbcontext.Antriebseinheiten
                .Include(an => an.Pruefer)
                .Select(an => an)
                .ToListAsync();
        }

        public async Task<IEnumerable<OEBBAntriebskomponenten>> GetAntriebskomponentenAsync(string antriebsnummer)
        {
            return await this._dbcontext.Antriebskomponenten
                .Select(ak => ak)
                .Where(ak => ak.AntriebseinheitsNummer == antriebsnummer)
                .ToListAsync();
        }

        public async Task<OEBBAntriebseinheit> GetByNummerAsync(string nummer)
        {
            return await this._dbcontext.Antriebseinheiten
                .Include(an => an.Pruefer)
                .FirstOrDefaultAsync(an => an.Nummer == nummer);
        }

        public async Task AddMemberAsync(OEBBAntriebseinheit antriebseinheit)
        {
            await this._dbcontext.Antriebseinheiten
                .AddAsync(antriebseinheit);
        }

        public async Task<bool> DeleteAsync(string nummer)
        {
            var antriebseinheit = await GetByNummerAsync(nummer);
            if(antriebseinheit == null)
            {
                return false;
            }
            this._dbcontext.Antriebseinheiten.Remove(antriebseinheit);
            await this._dbcontext.SaveChangesAsync();
            return true;
        }
    }
}

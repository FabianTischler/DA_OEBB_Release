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
    public class OEBBPrueferRepository : GenericRepository<OEBBPruefer>, IOEBBPrueferRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OEBBPrueferRepository (ApplicationDbContext context) : base(context)
        {
            this._dbContext = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pruefer = await GetPrueferById(id);
            if (pruefer == null)
            {
                return false;
            }
            this._dbContext.Pruefer.Remove(pruefer);
            await this._dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<OEBBPruefer> GetPrueferById(int id)
        {
            return await _dbContext.Pruefer.FindAsync(id);
        }

        public async Task<IEnumerable<OEBBPruefer>> GetAllAsync()
        {
            return await this._dbContext.Pruefer.Select(pr => pr).ToListAsync();
        }

        public async Task AddMemberAsync(OEBBPruefer pruefer)
        {
            await this._dbContext.Pruefer.AddAsync(pruefer);
        }
    }
}

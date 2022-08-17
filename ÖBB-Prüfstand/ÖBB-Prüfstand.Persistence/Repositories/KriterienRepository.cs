using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Persistence.Repositories
{
    public class KriterienRepository : IKriterienRepository
    {

        private static readonly KriterienRepository instance = new KriterienRepository();
        private List<OEBBFunktion> funktionen;

        private KriterienRepository()
        {

        }

        public static KriterienRepository Instance => instance;

        public List<Kriterium> Kriterien { get; set; }
        public List<Kriterium> GetKriterien()
        {
            return Kriterien;
        }
    }
}

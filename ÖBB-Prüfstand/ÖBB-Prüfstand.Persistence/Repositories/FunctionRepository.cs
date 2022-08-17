using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Persistence.Repositories
{
    public class FunctionRepository : IOEBBFunktionsRepository
    {
        private static readonly FunctionRepository instance = new FunctionRepository();
        private List<OEBBFunktion> funktionen;

        private FunctionRepository()
        {

        }

        public static FunctionRepository Instance => instance;
        public List<OEBBFunktion> Funktionen { get; set; }

        public List<OEBBFunktion> GetFunktionen()
        {
            return Funktionen;
        }
    }
}

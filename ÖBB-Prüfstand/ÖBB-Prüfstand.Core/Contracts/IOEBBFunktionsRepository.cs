using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Contracts
{
    public interface IOEBBFunktionsRepository 
    {
        public List<OEBBFunktion> GetFunktionen();
    }
}

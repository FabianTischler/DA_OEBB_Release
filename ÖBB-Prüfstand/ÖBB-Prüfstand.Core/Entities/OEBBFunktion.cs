
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBFunktion 
    {
        
        public string Beschreibung { get; set; }
        public int Headersize { get; set; }
        public int Entries { get; set; }
        public int EchtEntries { get; set; }
        public int NumRead { get; set; }
        public List<OEBBMessergebnisse> Messergebnisse { get; set; }
    }
}

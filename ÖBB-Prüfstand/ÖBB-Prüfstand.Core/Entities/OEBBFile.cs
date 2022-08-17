
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBFile
    {
        
        public string Id { get; set; }
        public Header header { get; set; }
        public List<OEBBFunktion> funktionen => new List<OEBBFunktion>();

        
    }
}

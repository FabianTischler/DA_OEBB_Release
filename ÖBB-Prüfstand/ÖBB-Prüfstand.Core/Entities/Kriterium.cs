using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class Kriterium
    {
        public string Name { get; set; }
        public int Angesprochen { get; set; }
        public double MinWert { get; set; }
        public double MaxWert { get; set; }
        public double IstWert { get; set; }
        public double ResultCode { get; set; }
        public double MaskMin { get; set; }
        public double MaskMax { get; set; }
        public double MessCount { get; set; }
    }
}

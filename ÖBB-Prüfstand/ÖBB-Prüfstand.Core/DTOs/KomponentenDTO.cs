using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.DTOs
{
    public class KomponentenDTO
    {
        public string AntriebsNummer { get; set; }
        public string Bezeichnung { get; set; }
        public string KomponentenNummer { get; set; }
        public int Leistung { get; set; }
        public DateTime Baujahr { get; set; }
        public string PrueferName { get; set; }
    }
}

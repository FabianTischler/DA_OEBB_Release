using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBAntriebseinheit : EntityObject
    {
        public string Bezeichnung { get; set; }
        public bool Zustand { get; set; }
        public int Leistung {get; set;}
        public int Prüflaufnummer { get; set; }
        public string Typ { get; set; }
        public string Nummer { get; set; }

        [ForeignKey(nameof(PrueferID))]
        public OEBBPruefer Pruefer { get; set; }
        public int PrueferID { get; set; }
    }
}

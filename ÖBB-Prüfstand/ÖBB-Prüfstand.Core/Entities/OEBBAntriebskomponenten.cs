using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBAntriebskomponenten :EntityObject
    {
        public string Bezeichnung { get; set; }
        public string Nummer { get; set; }
        public int Leistung { get; set; }
        public DateTime Baujahr { get; set; }

        [ForeignKey(nameof(AntriebseinheitsID))]
        public OEBBAntriebseinheit Antriebseinheit { get; set; }
        public int AntriebseinheitsID { get; set; }
        public string AntriebseinheitsNummer => Antriebseinheit.Nummer;
    }
}

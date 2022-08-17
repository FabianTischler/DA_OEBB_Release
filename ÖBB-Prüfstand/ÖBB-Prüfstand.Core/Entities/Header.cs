using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class Header
    {
        public string Quellsystem { get; set; }
        public string Timestamp { get; set; }
        public string QCFDatei { get; set; }
        public string Fileformat { get; set; }
        public string Teilenummer { get; set; }
        public string Prüflaufnummer { get; set; }
        public string Prüfprogramm { get; set; }
        public string Produkt { get; set; }
        public string MaskProdukt { get; set; }
        public string Zustand { get; set; }
        public string Messzaehler { get; set; }
        public string Messzeit { get; set; }
        public int Anzahlfunktion { get; set; }
        public int Anzahldefinition { get; set; }
        public int AnzahlFehler { get; set; }
        public int AnzahlKriterien { get; set; }
        public int Station { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Core.Entities
{
    public class OEBBMessergebnisse 
    {
        public int Number { get; set; }
        public double YWert { get; set; }
        public double Mittel { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }

        public string Header => $"Nr;YWert;Mittel;Max;Min";
        public string Body => Number.ToString() + ";" + YWert.ToString() + ";" + Mittel.ToString() + ";" + Max.ToString() + ";" + Min.ToString();  
    }
}

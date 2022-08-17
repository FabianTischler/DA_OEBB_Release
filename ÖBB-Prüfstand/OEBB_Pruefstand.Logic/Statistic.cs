using OEBB_Pruefstand.Core.DTOs;
using OEBB_Pruefstand.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEBB_Pruefstand.Logic
{
    public class Statistic
    {
        private ImportController ic;
        private StatisticFehlerDTO statisticFehlerDTO;
        private List<Header> headers;

        public Statistic()
        {
            //headers = new List<Header>();
            this.ic = new ImportController();
            //this.statisticFehlerDTO = new StatisticFehlerDTO();
            /*string[] arr =
            {
                "22587-040-003-7-1-I.QTX",
                "1110416-360-004-8-1-I.QTX",
                "10366-170-003-5-1-I.QTX",
                "10365-090-001-6-1-N.QTX"
            };
            Analysis("Lager",null,null, arr);*/
            //Analysis("Lager", "2021", "08", null);
        }
        
        public List<StatisticFehlerDTO> Analysis(string Zustand, string? Year, string? Month, string? Day)
        {
            List<StatisticFehlerDTO> errors = new List<StatisticFehlerDTO>();

            if(Year == null)
            {
                Console.WriteLine("Zustand");
                foreach (string txtName in Directory.GetFiles(@"D:\Schule\Diplo\Data\" + Zustand, "*.*", SearchOption.AllDirectories))
                {
                    Header header = ic.ReadInHeader(txtName);
                    List<String> names = ic.ReadInFehler(txtName);
                    foreach (string name in names)
                    {
                        StatisticFehlerDTO e = new StatisticFehlerDTO();
                        e.name = name;
                        e.date = header.Timestamp;
                        e.zustand = header.Zustand;
                        errors.Add(e);
                    }
                }
            }
            else if(Month == null)
            {
                foreach (string txtName in Directory.GetFiles(@"D:\Schule\Diplo\Data\" + Zustand + '\\' + Year, "*.*", SearchOption.AllDirectories))
                {
                    Header header = ic.ReadInHeader(txtName);
                    List<String> names = ic.ReadInFehler(txtName);
                    foreach (string name in names)
                    {
                        StatisticFehlerDTO e = new StatisticFehlerDTO();
                        e.name = name;
                        e.date = header.Timestamp;
                        e.zustand = header.Zustand;
                        errors.Add(e);
                    }
                }
            }
            else if (Day == null)
            {
                foreach (string txtName in Directory.GetFiles(@"D:\Schule\Diplo\Data\" + Zustand + '\\' + Year + '\\' + Month, "*.*", SearchOption.AllDirectories))
                {
                    Header header = ic.ReadInHeader(txtName);
                    List<String> names = ic.ReadInFehler(txtName);
                    foreach (string name in names)
                    {
                        StatisticFehlerDTO e = new StatisticFehlerDTO();
                        e.name = name;
                        e.date = header.Timestamp;
                        e.zustand = header.Zustand;
                        errors.Add(e);
                    }
                }
            }
            else
            {
                foreach (string txtName in Directory.GetFiles(@"D:\Schule\Diplo\Data\" + Zustand + '\\' + Year + '\\' + Month + '\\' + Day, "*.*", SearchOption.AllDirectories))
                {
                    Header header = ic.ReadInHeader(txtName);
                    List<String> names = ic.ReadInFehler(txtName);
                    foreach (string name in names)
                    {
                        StatisticFehlerDTO e = new StatisticFehlerDTO();
                        e.name = name;
                        e.date = header.Timestamp;
                        e.zustand = header.Zustand;
                        errors.Add(e);
                    }
                }
            }

            foreach(StatisticFehlerDTO error in errors)
            {
                Console.WriteLine(error.name);
            }

            return errors;
        }
    }
}

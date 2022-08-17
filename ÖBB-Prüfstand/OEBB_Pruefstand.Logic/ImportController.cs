using OEBB_Pruefstand.Core.Contracts;
using OEBB_Pruefstand.Core.Entities;
using OEBB_Pruefstand.Persistence;
using OEBB_Pruefstand.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OEBB_Pruefstand.Logic
{
    //Projekt für die statistishe Auswertung der Daten + abspeicherung in die interne Datenbank
    public class ImportController
    {

        public List<OEBBFunktion> funktionen;
        public List<OEBBMessergebnisse> messergebnisse;
        public List<Header> headerList;
        public List<Kriterium> kriterien;
        public List<OEBBMessergebnisse> backup;
        public OEBBFile file;
        public FunctionRepository functionRepository;
        public KriterienRepository kriterienRepository;
        string[] filenames;

        public ImportController()
        {
            this.funktionen = new List<OEBBFunktion>();
            this.messergebnisse = new List<OEBBMessergebnisse>();
            this.headerList = new List<Header>();
            this.kriterien = new List<Kriterium>();
            this.functionRepository = FunctionRepository.Instance;
            this.file = new OEBBFile();
            this.kriterienRepository = KriterienRepository.Instance;
            this.filenames = filenames;
        }

        public void start(string Zustand, string FileName)
        {
            //ImportMessergebnisse(Directory.GetFiles(@"D:\Schule\Diplo\Data\" + Zustand, FileName, SearchOption.AllDirectories)[0]);
            Console.WriteLine(Directory.GetCurrentDirectory());
            ImportMessergebnisse(Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Data\\" + Zustand, FileName, SearchOption.AllDirectories)[0]);
            
        }

        public void ImportMessergebnisse(string FileName)
        {
            Header header = new Header();
            
            //for (int i = 0; i < FileName.Length; i++)
            //{
                string[] lines = File.ReadAllLines(FileName, Encoding.UTF8 );
                string[] headerdata = new string[17];
                
                for (int y = 1; y <= 17; y++)
                {
                    string[] data = lines[y].Split("=");
                    headerdata[y-1] = data[1];
                }
                ParseIntoHeader(header ,headerdata);
                int startpos = 0;
                for (int y = 21; !String.IsNullOrEmpty(lines[y]); y++)
                {
                    string[] l = lines[y].Split("=");
                    string[] line = l[1].Split("\t");
                    line = formatArray(line);
                    ParseIntoKriterium(kriterien, line);
                    this.kriterienRepository.Kriterien = kriterien;
                    
                    startpos = y + 1;
                    
                }

                for (int y = startpos; y < lines.Length; y++)
                {
                    int l = 0;
                    if (lines[y].Equals("[Funktion1]")) //erste Funktion gefunden...ab diesem Zeitpunkt soll sich der code zum funktionen einlesen wiederholen...for schleife muss noch hinzugefügt werden und aus der übergeordneten muss am schluss rausgegangen werden
                    {
                        
                        for (int c = y;c < lines.Length; c++)
                        {
                            string[] funktionsdata = new string[5];
                            int count = 0;
                            int inCaseOfEmptyFunction =  c + 1;

                            if (!String.IsNullOrEmpty(lines[inCaseOfEmptyFunction]))
                            {
                                for (int k = c + 1; count <= 4 && !String.IsNullOrEmpty(lines[k]); k++)
                                {
                                    string[] data;
                                    if (count >= 1)
                                    {
                                        data = lines[k].Split(":");
                                        funktionsdata[count] += data[1];
                                    }
                                    else
                                    {
                                        funktionsdata[count] += lines[k];
                                    }
                                    count++;
                                    l = k;
                                }


                                for (int x = l + 2; !String.IsNullOrEmpty(lines[x]); x++)
                                {
                                    string[] line = lines[x].Split(";");
                                    ParseIntoMessergebniss(messergebnisse, line);
                                    l = x;
                                }
                                ParseIntoFunktion(funktionen, funktionsdata, messergebnisse);
                                this.messergebnisse = new List<OEBBMessergebnisse>();
                                
                                
                                c = l + 1;
                            }
                            else
                            {
                                c = inCaseOfEmptyFunction;
                            }
                        }
                            

                            y = l;
                    }

                    this.file = new OEBBFile();

            }


            //} 
            this.functionRepository.Funktionen = this.funktionen;
        }

        public Header ReadInHeader(string FileName)
        {
            Header header = new Header();

            string[] lines = File.ReadAllLines(FileName, Encoding.UTF8);
            string[] headerdata = new string[17];

            for (int y = 1; y <= 17; y++)
            {
                string[] data = lines[y].Split("=");
                headerdata[y - 1] = data[1];
            }
            ParseIntoHeader(header, headerdata);
            return header;
            
        }

        public void ParseIntoHeader(Header header ,string[] headerdata)
        {
            header.Quellsystem = headerdata[0];
            header.Timestamp = headerdata[1];
            header.QCFDatei = headerdata[2];
            header.Fileformat = headerdata[3];
            header.Teilenummer = headerdata[4];
            header.Prüflaufnummer = headerdata[5];
            header.Prüfprogramm = headerdata[6];
            header.Produkt = headerdata[7];
            header.MaskProdukt = headerdata[8];
            header.Zustand = headerdata[9];
            header.Messzaehler = headerdata[10];
            header.Messzeit = headerdata[11];
            header.Anzahlfunktion = Convert.ToInt32(headerdata[12]);
            header.Anzahldefinition = Convert.ToInt32(headerdata[13]);
            header.AnzahlFehler = Convert.ToInt32(headerdata[14]);
            header.AnzahlKriterien = Convert.ToInt32(headerdata[15]);
            header.Station = Convert.ToInt32(headerdata[16]);
            this.headerList.Add(header);
            this.file.header = header;
            
            //header = new Header
            //{
            //    Quellsystem = headerdata[0],
            //    Timestamp = headerdata[1],
            //    QCFDatei = headerdata[2],
            //    Fileformat = headerdata[3],
            //    Teilenummer = headerdata[4],
            //    Prüflaufnummer = headerdata[5],
            //    Prüfprogramm = headerdata[6],
            //    Produkt = headerdata[7],
            //    MaskProdukt = headerdata[8],
            //    Zustand = headerdata[9],
            //    Messzaehler = headerdata[10],
            //    Messzeit = headerdata[11],
            //    Anzahlfunktion = Convert.ToInt32(headerdata[12]),
            //    Anzahldefinition = Convert.ToInt32(headerdata[13]),
            //    AnzahlFehler = Convert.ToInt32(headerdata[14]),
            //    AnzahlKriterien = Convert.ToInt32(headerdata[15]),
            //    Station = Convert.ToInt32(headerdata[16])
            //};
        }

        public void ParseIntoKriterium(List<Kriterium> kriterien, string[] kriteriendata)
        {
            Kriterium kriterium = new Kriterium();
            kriterium.Name = kriteriendata[0];
            kriterium.Angesprochen = Convert.ToInt32(kriteriendata[1]);
            kriterium.MinWert = Convert.ToDouble(kriteriendata[2]);
            kriterium.MaxWert = Convert.ToDouble(kriteriendata[3]);
            kriterium.IstWert = Convert.ToDouble(kriteriendata[4]);
            kriterium.ResultCode = Convert.ToDouble(kriteriendata[5]);
            kriterium.MaskMin = Convert.ToDouble(kriteriendata[6]);
            kriterium.MaskMax = Convert.ToDouble(kriteriendata[7]);
            kriterium.MessCount = Convert.ToDouble(kriteriendata[8]);
            //Kriterium kriterium = new Kriterium
            //{
            //    Name = kriteriendata[0],
            //    Angesprochen = Convert.ToInt32(kriteriendata[1]),
            //    MinWert = Convert.ToDouble(kriteriendata[2]),
            //    MaxWert = Convert.ToDouble(kriteriendata[3]),
            //    IstWert = Convert.ToDouble(kriteriendata[4]),
            //    ResultCode = Convert.ToDouble(kriteriendata[5]),
            //    MaskMin = Convert.ToInt32(kriteriendata[6]),
            //    MaskMax = Convert.ToInt32(kriteriendata[7]),
            //    MessCount = Convert.ToInt32(kriteriendata[8])
            //};
            kriterien.Add(kriterium);
        }

        public void ParseIntoFunktion(List<OEBBFunktion> funktionen, string[] funktionendata, List<OEBBMessergebnisse> messergebnisse)
        {
            OEBBFunktion funktion = new OEBBFunktion
            {
                Beschreibung = funktionendata[0],
                Headersize = Convert.ToInt32(funktionendata[1]),
                Entries = Convert.ToInt32(funktionendata[2]),
                EchtEntries = Convert.ToInt32(funktionendata[3]),
                NumRead = Convert.ToInt32(funktionendata[4]),
                Messergebnisse = messergebnisse
            };
            funktionen.Add(funktion);
            this.file.funktionen.Add(funktion);
            
        }

        public void ParseIntoMessergebniss(List<OEBBMessergebnisse> messergebnisse, string[] data)
        {
            OEBBMessergebnisse messergebniss = new OEBBMessergebnisse
            {
                Number = Convert.ToInt32(data[0]),
                YWert = Convert.ToDouble(data[1]),
                Mittel = Convert.ToDouble(data[2]),
                Max = Convert.ToDouble(data[3]),
                Min = Convert.ToDouble(data[4])
            };
            messergebnisse.Add(messergebniss);
            
        }
        
        public string[] formatArray(string[] data)
        {
            
            for (int i = 0; i < data.Length; i++)
            {
                if (String.IsNullOrEmpty(data[i]))
                {
                    data[i] = "0";
                }
            }
            return data;
        }

        public List<string> ReadInFehler(string FileName)
        {
            List<string> fehler = new List<string>();
            string[] lines = File.ReadAllLines(FileName);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Equals("[Fehlercodierung]"))
                {
                    for (int j = i + 1; lines[j] != " "; j++)
                    {
                        var data = lines[j].Split("=");
                        if(data[0] == "")
                        {
                            break;
                        }
                        fehler.Add(data[1]);
                    }
                }
            }
            return fehler;
        }


    }
}

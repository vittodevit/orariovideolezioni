/* 
Copyright 2020 Vittorio Lo Mele
Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file 
except in compliance with the License. You may obtain a copy of the License at
   http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under the 
License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
either express or implied. See the License for the specific language governing permissions 
and limitations under the License.
*/
using System;
using System.IO;

namespace OrarioVideolezioni
{
    class Funzioni
    {
        private string percorsoAppdata;
        private string flagAutostart;
        private string flagNoConf;
        public Funzioni()
        {
            percorsoAppdata = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "OrarioVideolezioni"
                );//calcola percorso appdata dell'applicazione
            flagAutostart = Path.Combine(
                        percorsoAppdata,
                        "autostart.flag"
                    ); //calcola il percorso del file flag "autostart"
            flagNoConf = Path.Combine(
                        percorsoAppdata,
                        "noconf.flag"
                    ); //calcola il percorso del file flag "no conferma"
        }

        public string getPercorsoAppdata()
        {
            return percorsoAppdata;
        }

        //crea la cartella "OrarioVideolezioni" in %AppData% se non esiste
        public void initAppdataFolder()
        {
            Directory.CreateDirectory(percorsoAppdata);
        }

        //calcola il valore in secondi di un orario immesso
        public int calcolaIntervalloSecondi(int ore, int minuti)
        {
            int minasec = minuti * 60;
            int oreasec = ore * 3600;
            return minasec + oreasec;
        }

        //converte un giorno da formato Esteso a contratto (per il db) e viceversa
        public string convertiGiorno(string giorno, bool inverti = false)
        {
            string risultato = "";
            if (inverti)
            {
                switch (giorno)
                {
                    case "LUN":
                        risultato = "Lunedì";
                        break;
                    case "MAR":
                        risultato = "Martedì";
                        break;
                    case "MER":
                        risultato = "Mercoledì";
                        break;
                    case "GIO":
                        risultato = "Giovedì";
                        break;
                    case "VEN":
                        risultato = "Venerdì";
                        break;
                    case "SAB":
                        risultato = "Sabato";
                        break;
                    case "DOM":
                        risultato = "Domenica";
                        break;
                    default:
                        risultato = "Errore";
                        break;
                }
                    
            }
            else
            {
                switch (giorno)
                {
                    case "Lunedì":
                        risultato = "LUN";
                        break;
                    case "Martedì":
                        risultato = "MAR";
                        break;
                    case "Mercoledì":
                        risultato = "MER";
                        break;
                    case "Giovedì":
                        risultato = "GIO";
                        break;
                    case "Venerdì":
                        risultato = "VEN";
                        break;
                    case "Sabato":
                        risultato = "SAB";
                        break;
                    case "Domenica":
                        risultato = "DOM";
                        break;
                    default:
                        risultato = "ERR";
                        break;
                }
            }
            return risultato;
        }

        //converte il giorno della settimana dal datatype DayOfWeek in una stringa...
        //...in formato contratto per il DB
        public string dtToDatabaseFormat(DayOfWeek giorno)
        {
            string risultato;
            switch (giorno)
            {
                case DayOfWeek.Monday:
                    risultato = "LUN";
                    break;
                case DayOfWeek.Tuesday:
                    risultato = "MAR";
                    break;
                case DayOfWeek.Wednesday:
                    risultato = "MER";
                    break;
                case DayOfWeek.Thursday:
                    risultato = "GIO";
                    break;
                case DayOfWeek.Friday:
                    risultato = "VEN";
                    break;
                case DayOfWeek.Saturday:
                    risultato = "SAB";
                    break;
                case DayOfWeek.Sunday:
                    risultato = "DOM";
                    break;
                default:
                    risultato = "ERR";
                    break;
            }
            return risultato;
        }

        //converte il valore in secondi in una stringa leggibile da un umano
        public string secondiAdUmano(int secondi)
        {
            int ore, minuti;
            string oreS, minutiS;
            minuti = secondi / 60; //calcola i minuti rimanenti
            ore = minuti / 60; //calcola le ore rimanenti
            minuti = minuti % 60; //assegna a minuti il modulo (resto divisione)...
            //...di se stesso per lasciare solo i minuti rimanenti

            //se il valore di ore è minore di 10 aggiunge uno zero per adattarsi al formato 24 ore
            if (ore < 10)
            {
                oreS = "0" + ore.ToString();
            }
            else
            {
                oreS = ore.ToString();
            }
            //stessa cosa per i minuti
            if (minuti < 10)
            {
                minutiS = "0" + minuti.ToString();
            }
            else
            {
                minutiS = minuti.ToString();
            }
            //combina le due stringhe con i due punti e ritorna
            string s = oreS + ":" + minutiS;
            return s;
        }

        //converte il valore in secondi in DateTime
        public DateTime secondiADT(int secondi)
        {
            int ore, minuti;
            string oreS, minutiS;
            minuti = secondi / 60; //calcola i minuti rimanenti
            ore = minuti / 60; //calcola le ore rimanenti
            minuti = minuti % 60; //assegna a minuti il modulo (resto divisione)...
            //...di se stesso per lasciare solo i minuti rimanenti

            //converti a DateTime (imposto la data di oggi tanto useremo solo i parametri del time)
            DateTime time = new DateTime(2021, 01, 13, ore, minuti, 0);
            return time;
        }

        public void setImpostazioneAutostart(bool b)
        {
            if (b)
            {
                //crea file
                if (!File.Exists(flagAutostart))
                {
                    var f = File.Create(flagAutostart);
                    f.Close();
                    f.Dispose();
                }
            }
            else
            {
                //se il file esiste elimina
                if (File.Exists(flagAutostart))
                {
                    File.Delete(flagAutostart);
                }
            }
        }

        public void setImpostazioneNoConf(bool b)
        {
            if (b)
            {
                //crea file
                if (!File.Exists(flagNoConf))
                {
                    var f = File.Create(flagNoConf);
                    f.Close();
                    f.Dispose();
                }
            }
            else
            {
                //se il file esiste elimina
                if (File.Exists(flagNoConf))
                {
                    File.Delete(flagNoConf);
                }
            }
        }

        public bool getImpostazioneAutostart()
        {
            return File.Exists(flagAutostart);
        }

        public bool getImpostazioneNoConf()
        {
            return File.Exists(flagNoConf);
        }
    }
}

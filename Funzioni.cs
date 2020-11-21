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
        public Funzioni()
        {
            percorsoAppdata = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "OrarioVideolezioni"
                );//calcola percorso appdata dell'applicazione
        }

        public string getPercorsoAppdata()
        {
            return percorsoAppdata;
        }

        public void initAppdataFolder()
        {
            Directory.CreateDirectory(percorsoAppdata);
        }

        public int calcolaIntervalloSecondi(int ore, int minuti)
        {
            int minasec = minuti * 60;
            int oreasec = ore * 3600;
            return minasec + oreasec;
        }

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

        public string secondiAdUmano(int secondi)
        {
            int ore, minuti;
            string oreS, minutiS;
            minuti = secondi / 60;
            ore = minuti / 60;
            minuti = minuti % 60;
            if (ore < 10)
            {
                oreS = "0" + ore.ToString();
            }
            else
            {
                oreS = ore.ToString();
            }
            if (minuti < 10)
            {
                minutiS = "0" + minuti.ToString();
            }
            else
            {
                minutiS = minuti.ToString();
            }
            string s = oreS + ":" + minutiS;
            return s;
        }
    }
}

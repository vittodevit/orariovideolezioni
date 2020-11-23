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
using System.Windows.Forms;

namespace OrarioVideolezioni
{
    public partial class AggiungiRiga : Form
    {
        Funzioni func = new Funzioni(); //ogg. classe funz.
        /*
        Oggetto classe db.
        N.B.: la chiamata al costruttore contiene due valori, di cui ci interessa il secondo (il primo
        serve al percorso custom). Il secondo parametro richiede alla classe di effettuare il load del file
        senza eseguire le operazioni di init, dato che si presume siano già state efffettuate dalla classe padre.
         */
        GestoreDatabase db = new GestoreDatabase("", true);
        private Form1 _formpadre;  //oggetto form padre
        public AggiungiRiga(Form1 fp)
        {
            //memorizza nella variabile _formpadre l'oggetto che ha chiamato questa finestra...
            //... per poter eseguire le operazioni di callback es. il refresh della tabella
            if (fp == null) throw new NullReferenceException("Non puoi chiamare questo form da null");
            _formpadre = fp;
            InitializeComponent();
        }

        private void AggiungiRiga_Load(object sender, EventArgs e)
        {
            materia_txt.Items.Add("Nessuna"); //aggiungi nella selez. materia la possibilità di nessuna
            //all'apertura del form, carica nella lista elementi del menù a tendina di selezione materia...
            //...tutte le materie contenute nel database
            foreach(string elemento in db.getListaMaterieCombo())
            {
                materia_txt.Items.Add(elemento);
            }
        }

        private void chiudiFinestra(object sender, EventArgs e)
        {
            //alla chiusura finestra libera tutte le risorse allocate dalla classe database per permettere
            //l'accesso ad altre istanze della classe GestoreDatabase
            db.forceClose();
            this.Close();
        }

        private void aggiungi(object sender, EventArgs e)
        {
            //controlla che gli input siano validi e siano tutti compilati
            if(giornoSettimana_txt.Text == "")
            {
                errore("Specifica un giorno della settimana!");
                return;
            }
            if(link_txt.Text.Length <= 4 | linkPrefix_txt.Text == "")
            {
                errore("Link non valido!");
                return;
            }
            //calcola tutti i parametri
            string linkOk = linkPrefix_txt.Text + link_txt.Text;
            string inizioOra = inizio_dtp.Value.ToString("HH");
            string inizioMinuti = inizio_dtp.Value.ToString("mm");
            string fineOra = fine_dtp.Value.ToString("HH");
            string fineMinuti = fine_dtp.Value.ToString("mm");
            int intervalloInizio = func.calcolaIntervalloSecondi(
                        Int32.Parse(inizioOra),
                        Int32.Parse(inizioMinuti));
            int intervalloFine = func.calcolaIntervalloSecondi(
                        Int32.Parse(fineOra),
                        Int32.Parse(fineMinuti));
            //controlla che l'intervallo di fine sia maggiore di quello d'inizio
            //(una lezione non può finire prima del suo inizio .-.)
            if(intervalloFine <= intervalloInizio)
            {
                errore("L'orario di fine non può essere minore o uguale a quello d'inizio!");
                return;
            }
            //invia il comando di aggiunta al DB
            bool r = db.aggiungiRiga(
                    func.convertiGiorno(giornoSettimana_txt.Text),
                    intervalloInizio,
                    intervalloFine,
                    materia_txt.Text,
                    linkOk
                );
            //in caso di errore mostra box di errore
            if (!r)
            {
                errore("Errore interno del database!");
            }
            else
            {
                _formpadre.refresh(); //ricarica la tabella del form padre per mostrare i cambiamenti in tempo reale
                clear(); //ripulisci i controll per preparare ad una nuova aggiunta
                //se l'opzione di uscita dopo aggiunta è attiva
                if (closeOnAdd.Checked)
                {
                    //disalloca risorse db ed esci
                    db.forceClose();
                    this.Close();
                }
            }
        }

        //funz errore (stessa di Form1.cs)
        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clear()
        {
            //ripulisci controlli
            link_txt.Text = "";
            materia_txt.Text = "Nessuna";
            inizio_dtp.Value = new DateTime(2020, 11, 22);
            fine_dtp.Value = new DateTime(2020, 11, 22);
        }
        
    }
}

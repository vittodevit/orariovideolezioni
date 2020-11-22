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
        Funzioni func = new Funzioni();
        GestoreDatabase db = new GestoreDatabase("", true);
        private Form1 _formpadre;
        public AggiungiRiga(Form1 fp)
        {
            if (fp == null) throw new NullReferenceException("Non puoi chiamare questo form da null");
            _formpadre = fp;
            InitializeComponent();
        }

        private void AggiungiRiga_Load(object sender, EventArgs e)
        {
            foreach(string elemento in db.getListaMaterieCombo())
            {
                materia_txt.Items.Add(elemento);
            }
        }

        private void chiudiFinestra(object sender, EventArgs e)
        {
            db.forceClose();
            this.Close();
        }

        private void aggiungi(object sender, EventArgs e)
        {
            //sanitize input
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
            if(intervalloFine <= intervalloInizio)
            {
                errore("L'orario di fine non può essere minore o uguale a quello d'inizio!");
                return;
            }
            bool r = db.aggiungiRiga(
                    func.convertiGiorno(giornoSettimana_txt.Text),
                    intervalloInizio,
                    intervalloFine,
                    materia_txt.Text,
                    linkOk
                );
            if (!r)
            {
                errore("Errore interno del database!");
            }
            else
            {
                _formpadre.refresh();
                clear();
                if (closeOnAdd.Checked)
                {
                    db.forceClose();
                    this.Close();
                }
            }
        }

        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clear()
        {
            giornoSettimana_txt.Text = "";
            linkPrefix_txt.Text = "";
            link_txt.Text = "";
            materia_txt.Text = "";
            inizio_dtp.Value = new DateTime(2020, 11, 22);
            fine_dtp.Value = new DateTime(2020, 11, 22);
        }
        
    }
}

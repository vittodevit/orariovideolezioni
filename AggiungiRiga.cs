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
        GestoreDatabase db = new GestoreDatabase();
        public AggiungiRiga()
        {
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
            this.Close();
        }

        private void aggiungi(object sender, EventArgs e)
        {
            //sanitize input
            if(link_txt.Text == "" | link_txt.Text.Length <= 4)
            {
                errore("Link non valido!");
                return;
            }
            string linkOk = linkPrefix_txt.Text + link_txt.Text;
            string inizioOra = inizio_dtp.Value.ToString("HH");
            string inizioMinuti = inizio_dtp.Value.ToString("mm");
            string fineOra = fine_dtp.Value.ToString("HH");
            string fineMinuti = fine_dtp.Value.ToString("mm");
            db.aggiungiRiga(
                    func.convertiGiorno(giornoSettimana_txt.Text),
                    func.calcolaIntervalloSecondi(
                        Int32.Parse(inizioOra),
                        Int32.Parse(inizioMinuti)),
                    func.calcolaIntervalloSecondi(
                        Int32.Parse(fineOra),
                        Int32.Parse(fineMinuti)),
                    materia_txt.Text,
                    linkOk
                );
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }
}

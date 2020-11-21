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

        private void chiudiFinestra(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aggiungi(object sender, EventArgs e)
        {
            //sanitize input
            if(func.convertiGiorno(giornoSettimana_txt.Text) == "ERR")
            {
                errore("Giorno della settimana non valido!");
                return;
            }
            if(link_txt.Text == "" | link_txt.Text.Length <= 7)
            {
                errore("Link non valido!");
                return;
            }
            if (link_txt.Text.Substring(0, 4) != "http")
            {
                errore("Link non valido!");
                return;
            }
            db.aggiungiRiga(
                    func.convertiGiorno(giornoSettimana_txt.Text),
                    func.calcolaIntervalloSecondi(
                        Decimal.ToInt32(inizioOra_nm.Value),
                        Decimal.ToInt32(inizioMinuti_nm.Value)),
                    func.calcolaIntervalloSecondi(
                        Decimal.ToInt32(fineOra_nm.Value),
                        Decimal.ToInt32(fineMinuti_nm.Value)),
                    link_txt.Text
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

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
using System.Data;

namespace OrarioVideolezioni
{
    public partial class Form1 : Form
    {
        GestoreDatabase db = new GestoreDatabase();
        Funzioni func = new Funzioni();
        public Form1()
        {
            InitializeComponent();
        }

        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void finestraCaricata(object sender, EventArgs e)
        {
            //inizializzazione delle cartelle e file
            func.initAppdataFolder();
            db.initDatabase();
            //refresh tabella
            refresh();
        }

        private void apriFinestraAggRiga(object sender, EventArgs e)
        {
            AggiungiRiga formriga = new AggiungiRiga();
            formriga.ShowDialog();
            refresh();
        }

        private void refresh()
        {
            tabella.DataSource = db.getTabella();
            tabella.AutoResizeColumns();
        }

        private void tabella_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr in tabella.Rows)
            {
                if (dr.Index == e.RowIndex)
                {
                    if (e.ColumnIndex == 4)
                    {
                        apriLink(dr.Cells[4].Value.ToString());
                    }
                }
            }
        }

        private void apriLink(string link)
        {
            var res = MessageBox.Show(
                "Vuoi aprire il link '" + link + "' adesso?", 
                "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.Start(link);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Errore! Impossibile aprire il link: " + e.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rimuoviRigaSelezionata_click(object sender, EventArgs e)
        {
            try
            {
                int indiceRiga = tabella.CurrentCell.RowIndex;
                DataGridViewRow riga = tabella.Rows[indiceRiga];
                int id = Int32.Parse(riga.Cells[0].Value.ToString());
                db.rimuoviRiga(id);
                refresh();
            }catch (Exception)
            {
                errore("Nessuna riga selezionata");
            }
        }

        private void ricaricabtn_click(object sender, EventArgs e)
        {
            refresh();
        }

        private void gestisciMaterieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestioneMaterie form = new GestioneMaterie();
            form.ShowDialog();
            refresh();
        }
    }
}

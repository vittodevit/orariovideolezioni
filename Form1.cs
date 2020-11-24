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
using System.Drawing;
using System.Windows.Forms;

namespace OrarioVideolezioni
{
    public partial class Form1 : Form
    {
        GestoreDatabase db = new GestoreDatabase(); //ogg. database
        Funzioni func = new Funzioni(); //ogg. classe funz.
        private int lastOpened = 0; //indica l'ID dell'ultima richiesta di apertura link
        private int lastTickIdCalled = 0; //ultimo id chiamato dal tick
        private bool inswap = false; //indica se si stanno effettuando operazioni esterne sul database
        private bool ac = false; //indica se l'autostart dei link è attivo

        public Form1()
        {
            InitializeComponent();
        }

        //visualizza box di errore
        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void finestraCaricata(object sender, EventArgs e)
        {
            //inizializzazione delle cartelle e file
            func.initAppdataFolder();
            if (!db.initDatabase())
            {
                //errore di init, chiudi app e mostra messaggio errore
                errore("Inizializzazione del database fallita, l'applicazione verrà terminata adesso");
                this.Close();
            }
            refresh();//refresh tabella
            refresher.Start();
            tickEvent(); //fa partire manualmente il primo tick per le operazioni di refresh riga verde e autolink
        }

        private void apriFinestraAggRiga(object sender, EventArgs e)
        {
            //apertura form di aggiunta riga, in seguito refresha la tabella alla chiusura
            AggiungiRiga formriga = new AggiungiRiga(this);
            formriga.ShowDialog();
            refresh();
        }

        public void refresh()
        {
            //ottieni dati e ridimensiona automaticamente le colonne
            tabella.DataSource = db.getTabella();
            tabella.AutoResizeColumns();
        }

        private void tabella_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //itera in tutte le righe della tabella fino a trovare la riga del click
            foreach (DataGridViewRow dr in tabella.Rows)
            {
                //corrispondenza con arg. chiamata funzioni
                if (dr.Index == e.RowIndex)
                {
                    //se la colonna è quella del link apri
                    if (e.ColumnIndex == 5)
                    {
                        LinkAttivo nla = new LinkAttivo(dr.Cells[5].Value.ToString(), 
                            dr.Cells[4].Value.ToString(),
                            Int32.Parse(
                                    dr.Cells[0].Value.ToString()
                                )
                            );
                        apriLink(nla);
                    }
                }
            }
        }

        private void apriLink(LinkAttivo la)
        {
            //ottieni l'id della richiesta ed imposta la variabile della classe
            lastOpened = la.Id;
            DialogResult res;
            //se la checkbox per non chiedere la conferma è disattivata apri il box di richiesta
            if(!confermaOpenCk.Checked)
            {
                res = MessageBox.Show(
                "Vuoi aprire il link di " + la.NomeMat + " -> '" + la.Link + "' adesso?",
                "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                //assume che la risposta sia di SI (checkbox attivata)
                res = DialogResult.Yes;
            }
            if(res == DialogResult.Yes)
            {
                try
                {
                    //prova ad aprire il link
                    System.Diagnostics.Process.Start(la.Link);
                }
                catch (Exception e)
                {
                    //il link non è valido, mostra messaggio di errore
                    MessageBox.Show("Errore! Impossibile aprire il link: " + e.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rimuoviRigaSelezionata_click(object sender, EventArgs e)
        {
            try
            {
                //prova ad individuare la riga selezionata
                int indiceRiga = tabella.CurrentCell.RowIndex;
                DataGridViewRow riga = tabella.Rows[indiceRiga];
                //ottieni ID riga ed impartisci comando rimozione al database
                int id = Int32.Parse(riga.Cells[0].Value.ToString());
                db.rimuoviRiga(id);
                refresh();
            }catch (Exception)
            {
                //nessuna riga selezionata, mostra box di errore
                errore("Nessuna riga selezionata");
            }
        }

        //chiama funzione di ricarica quando il pulsante ricarica è premuto
        private void ricaricabtn_click(object sender, EventArgs e)
        {
            refresh();
            tickEvent();
        }

        private void gestisciMaterieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //apri form di gestione materie
            GestioneMaterie form = new GestioneMaterie();
            form.ShowDialog();
            //alla chiusura ricarica la tabella
            refresh();
        }

        private void informazioniSullapplicazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //apri infobox
            infoapp infoapp = new infoapp();
            infoapp.ShowDialog();
        }

        private void paginaGitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //apri pag. github
            System.Diagnostics.Process.Start("https://github.com/mrBackSlash-it/orariovideolezioni");
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chiudi app al click di "esci" nel menù
            this.Close();
        }

        //funz. di esportazione database
        private void esportaDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //setta la flag di swap su true per fermare temporaneamente le operazioni nel database
            inswap = true;
            //mostra finestra di salvataggio
            var res = salvadb.ShowDialog();
            if(res == DialogResult.OK)
            {
                //se si preme ok, copia il file database da appdata alla cartella di destinazione
                //scelta dall'utente
                System.IO.File.Copy(
                    db.getPercorsoFileDatabase(),
                    salvadb.FileName
                    );
            }
            //a fine operazione ripristina la flag per permettere le operazioni sul db
            inswap = false;
        }

        private void importaDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //blocca le operazioni sul db
            inswap = true;
            var res = importadb.ShowDialog();
            if(res == DialogResult.OK)
            {
                //per l'importazione, chiudi tutte le connessioni della classe e...
                //...libera tutte le risorse ed il pool, per liberare il file dal processo
                db.forceClose();
                //sovrascrivi il database con il file scelto dall'utente
                System.IO.File.Copy(
                    importadb.FileName,
                    db.getPercorsoFileDatabase(),
                    true
                    );
                //ricarica la classe, fai le prove di init e ricarica la tabella
                db = new GestoreDatabase();
                db.initDatabase();
                refresh();
            }
            //sblocca le operazioni sul db
            inswap = false;
        }

        private void apriLink_btn_Click(object sender, EventArgs e)
        {
            //ottieni link attivo dal db
            LinkAttivo la = db.trovaLinkAttivo();
            //se 'la' non è null (c'è un link candidato per l'apertura' passa alla funzione
            if (la != null && la.Id != lastOpened)
            {
                apriLink(la);
            }
            else
            {
                //nessun link candidato per l'apertura
                MessageBox.Show("Nessun link trovato per l'ora corrente", "Orario Videolezioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }      
        }

        private void tickEvent(bool force = false)
        {
            //evento di check per link attivo (ogni 5000 msec), stesso funzionamento della funzione precedente
            //refresha riga verde ora attiva tabella
            LinkAttivo la = db.trovaLinkAttivo();
            //refresha riga verde se non è stato già fatto
            if (la.Id != lastTickIdCalled)
            {
                aggiornaRigaVerde(la.Id);
            }
            if (force)
            {
                //se il bool force è attivo, forza il refresh della riga verde in tabella nonostante sia già stata disegnata
                aggiornaRigaVerde(la.Id);
            }
            //apri link se c'è, se non è stato già aperto e se l'autostart è attivo
            if (la != null && la.Id != lastOpened && ac == true)
            {
                apriLink(la);
            }
        }

        private void autostart_check_CheckedChanged(object sender, EventArgs e)
        {
            //evento di cambio checkbox "start automatico"
            if (autostart_check.Checked)
            {
                //nel caso di attivazione fai partire immediatamente un evento di tick ed attiva autostart
                ac = true;
                tickEvent();
            }
            else
            {
                //disattiva autostart
                ac = false;
            }
        }

        private void refresher_Tick(object sender, EventArgs e)
        {
            //se il database non è stato bloccato dalle operaz. di import / export passa il tick...
            //...effettivo del timer alla funzione di tick
            if (!inswap)
            {
                tickEvent();
            }
        }

        private void aggiornaRigaVerde(int id)
        {
            //aggiorna l'ultimo id chiamato dal tick
            lastTickIdCalled = id;
            //itera in tutte le righe della tabella
            foreach (DataGridViewRow riga in tabella.Rows)
            {
                //controlla che il valore della cella 0 (l'id) corrisponda a quello...
                //...specificato nella firma della funzione
                if(Int32.Parse(riga.Cells[0].Value.ToString()) == id)
                {
                    //resetta il colore della riga precedente, ottenendo il rowindex dalla variabile riga
                    foreach(DataGridViewColumn col in tabella.Columns)
                    {
                        col.DefaultCellStyle.BackColor = Color.Empty;
                    }
                    //colora la successiva
                    for (int i = 0; i < 6; i++)
                    {
                        tabella.Rows[riga.Index].Cells[i].Style.BackColor = Color.LimeGreen;
                    }
                }
            }
        }

        private void cambioSortColonna(object sender, DataGridViewCellMouseEventArgs e)
        {
            //fai partire un tick per aggiornare la riga verde (il true forza l'aggiornamento)
            tickEvent(true);
        }
    }
}

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
            DataTable originedati = db.getTabella();
            //tabella = new DataGridView();
            tabella.DataSource = originedati;
            //agg pulsante di rimozione
            DataGridViewButtonColumn colRimuovi = new DataGridViewButtonColumn();
            colRimuovi.Name = "Rimuovi";
            colRimuovi.Text = "Rimuovi";
            if (tabella.Columns["Rimuovi"] == null)
            {
                tabella.Columns.Insert(5, colRimuovi);
            }
            colRimuovi.UseColumnTextForButtonValue = true;
            tabella.AutoResizeColumns();
        }

        private void tabella_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr in tabella.Rows)
            {
                if(dr.Index == e.RowIndex)
                {
                    if(e.ColumnIndex == 4)
                    {
                        apriLink(dr.Cells[4].Value.ToString());
                    }
                }
            }
        }

        private void tabella_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr in tabella.Rows)
            {
                if (dr.Index == e.RowIndex)
                {
                    if (e.ColumnIndex == 5)
                    {
                        db.rimuoviRiga(
                                Int32.Parse(dr.Cells[0].Value.ToString())
                            );
                        refresh();
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

        
    }
}

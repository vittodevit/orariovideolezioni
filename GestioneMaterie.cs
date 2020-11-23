using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrarioVideolezioni
{
    public partial class GestioneMaterie : Form
    {
        GestoreDatabase db = new GestoreDatabase("", true);
        Funzioni func = new Funzioni();
        public GestioneMaterie()
        {
            InitializeComponent();
        }

        private void errore(string e)
        {
            MessageBox.Show(e, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GestioneMaterie_Load(object sender, EventArgs e)
        {
            refresh(); //all'apertura della finestra carica la tabella
        }

        private void refresh()
        {
            //ottieni lista materie dal db e ridimensiona in auto le colonne
            tabellamaterie.DataSource = db.getListaMaterie();
            tabellamaterie.AutoResizeColumns();
        }

        //alla pressione del pulsante di aggiunta materie
        private void aggmat_btn_Click(object sender, EventArgs e)
        {
            //controlla che i campi non siano vuoti
            if(nomeMat.Text != "" && nomeProf.Text != "")
            {
                //prova ad aggiungere la materia
                if(!db.aggRigaMateria(nomeMat.Text,nomeProf.Text))
                {
                    errore("Errore interno del database"); //box errore
                }
                //ricarica tabella e ripulisci campi per preparare nuova aggiunta
                refresh();
                nomeMat.Text = "";
                nomeProf.Text = "";
            }
            else
            {
                errore("Compila tutti i campi!");
            }
        }

        //al click sul pulsante rimuovi materia
        private void remmat_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //trova id riga selezionata
                int indiceRiga = tabellamaterie.CurrentCell.RowIndex;
                DataGridViewRow riga = tabellamaterie.Rows[indiceRiga];
                int id = Int32.Parse(riga.Cells[0].Value.ToString());
                //invia al db comando di rimozione
                if (!db.rimRigaMateria(id))
                {
                    errore("Errore interno del database"); //box di errore
                }
                refresh(); //ricarica tabella
            }
            catch (Exception)
            {
                errore("Nessuna riga selezionata");
            }
        }

        private void esci(object sender, EventArgs e)
        {
            db.forceClose(); //libera tutte le risorse per passare il libero controllo del file db al form padre
            this.Close(); //chiudi finestra
        }
    }
}

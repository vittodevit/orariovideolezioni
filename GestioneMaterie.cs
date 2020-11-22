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
        GestoreDatabase db = new GestoreDatabase();
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
            refresh();
        }

        private void refresh()
        {
            tabellamaterie.DataSource = db.getListaMaterie();
            tabellamaterie.AutoResizeColumns();
        }

        private void aggmat_btn_Click(object sender, EventArgs e)
        {
            if(nomeMat.Text != "" && nomeProf.Text != "")
            {
                if(!db.aggRigaMateria(nomeMat.Text,nomeProf.Text))
                {
                    errore("Errore interno del database");
                }
                refresh();
            }
            else
            {
                errore("Compila tutti i campi!");
            }
        }

        private void remmat_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceRiga = tabellamaterie.CurrentCell.RowIndex;
                DataGridViewRow riga = tabellamaterie.Rows[indiceRiga];
                int id = Int32.Parse(riga.Cells[0].Value.ToString());
                if (!db.rimRigaMateria(id))
                {
                    errore("Errore interno del database");
                }
                refresh();
            }
            catch (Exception)
            {
                errore("Nessuna riga selezionata");
            }
        }
    }
}

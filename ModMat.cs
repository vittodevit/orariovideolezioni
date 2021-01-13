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
    public partial class ModMat : Form
    {
        //per la spiegazione del costruttore passare ad 'AggiungiRiga.cs'
        GestoreDatabase db = new GestoreDatabase("", true);
        Funzioni func = new Funzioni();
        int idmateria = 0;
        /* nella chiamata al costruttore si richiede l'id della materia sennò 
         * il form non può sapere quale riga modificare */
        public ModMat(int id)
        {
            idmateria = id;
            InitializeComponent();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            //operaz. db
            if (!db.aggiornaRigaMateria(idmateria, nomenuovo.Text))
            {
                MessageBox.Show("Errore interno del database!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.forceClose(); //libera le risorse per passarle al form padre
            this.Close(); //chiudi la finestra
        }

        private void esci_Click(object sender, EventArgs e)
        {
            db.forceClose(); //libera le risorse per passarle al form padre
            this.Close(); //chiudi la finestra
        }
    }
}

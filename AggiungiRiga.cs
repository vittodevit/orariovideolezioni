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
            this.Close();
        }
    }
}

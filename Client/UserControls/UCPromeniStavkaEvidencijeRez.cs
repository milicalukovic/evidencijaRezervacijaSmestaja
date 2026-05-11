using Client.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCPromeniStavkaEvidencijeRez : UserControl
    {
        public UCPromeniStavkaEvidencijeRez()
        {
            InitializeComponent();
        }

        private void btnPretraziKorisnik_Click(object sender, EventArgs e)
        {
            if (txtKorisnik.ReadOnly)
            {
                Koordinator.Instance.PromeniStavkaEvidencijeRezController.PretraziKorisnik();
            }
            else
            {
                Koordinator.Instance.PromeniStavkaEvidencijeRezController.DodajKorisnik();
            }

        }

        private void btnPromeniEvidencijaRez_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.PromeniStavkaEvidencijeRezController.ZapamtiPodatke();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.PromeniStavkaEvidencijeRezController.Odustani();
        }

        
    }
}

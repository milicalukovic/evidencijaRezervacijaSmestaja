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

namespace Client.Forms
{
    public partial class FrmStavkaEvidencije : Form
    {
        public FrmStavkaEvidencije()
        {
            InitializeComponent();
        }
        private void btnPretraziKorisnik_Click(object sender, EventArgs e)
        {
            if (txtKorisnik.ReadOnly)
            {
                Koordinator.Instance.StavkaEvidencijeFrmController.PretraziKorisnik();
            }
            else
            {
                Koordinator.Instance.StavkaEvidencijeFrmController.DodajKorisnik();
            }

        }

        private void btnPromeniEvidencijaRez_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.StavkaEvidencijeFrmController.ZapamtiPodatke();
        }

        private void FrmStavkaEvidencije_FormClosing(object sender, FormClosingEventArgs e)
        {
            Koordinator.Instance.StavkaEvidencijeFrmController.OsveziVrednosti();     
        }

        
    }
}

using Client.Session;
using Common.Domain;
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
    public partial class UCOsnovniPodaciEvidencijaRez : UserControl
    {
        public UCOsnovniPodaciEvidencijaRez()
        {
            InitializeComponent();
        }

        private void btnPromeniEvidencijaRez_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.OsnovniPodaciEvidencijaRezController.ZapamtiPodatke();
        }

        private void cmbSmestajnaJedinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            Koordinator.Instance.OsnovniPodaciEvidencijaRezController.PromeniCMBSmestajnaJedinica(CmbSmestajnaJedinica.SelectedItem as SmestajnaJedinica);
        }
    }
}

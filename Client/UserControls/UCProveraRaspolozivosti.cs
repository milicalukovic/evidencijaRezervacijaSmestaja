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
    public partial class UCProveraRaspolozivosti : UserControl
    {
        public UCProveraRaspolozivosti()
        {
            InitializeComponent();
        }

        private void btnProveri_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.ProveraRaspolozivostiController.Proveri();
        }

        private void checkBoxNaziv_CheckedChanged(object sender, EventArgs e)
        {
            Koordinator.Instance.ProveraRaspolozivostiController.PrikaziCmbSmestajnaJedinica();
        }

        private void checkBoxUsluga_CheckedChanged(object sender, EventArgs e)
        {

            Koordinator.Instance.ProveraRaspolozivostiController.PrikaziCmbVrstaUsluge();
        }

        private void checkBoxBroj_CheckedChanged(object sender, EventArgs e)
        {
            Koordinator.Instance.ProveraRaspolozivostiController.PrikaziNumBrojOsoba();
        }
    }
}

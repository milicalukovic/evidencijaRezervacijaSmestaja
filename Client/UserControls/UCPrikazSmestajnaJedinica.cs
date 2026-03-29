using Client.Session;
using Microsoft.IdentityModel.Tokens;
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
    public partial class UCPrikazSmestajnaJedinica : UserControl
    {
        public UCPrikazSmestajnaJedinica()
        {
            InitializeComponent();
        }

        private void btnKreirajSJ_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaUCController.KreirajSmestajnaJedinica();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaUCController.PrikaziCmbSJ();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaUCController.PrikaziCmbTip();
        }

        private void btnFilltrirajPrikazSJ_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaUCController.PrikaziSmestajneJedinice();
        }

        private void btnVratiPrikaz_Click(object sender, EventArgs e)
        {
            if (!Koordinator.Instance.ListaSmestajnaJedinica.IsNullOrEmpty())
            {
                Koordinator.Instance.SmestajnaJedinicaUCController.AzurirajTabelu();
            }
        }
        private void dgvSmestajnaJedinica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Koordinator.Instance.SmestajnaJedinicaUCController.IzabranaSJ(e.RowIndex);
            }
        }

        private void btnPretraziSJ_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaUCController.PretraziSmestajnaJedinica();
        }

        
    }
}

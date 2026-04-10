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
    public partial class UCPrikazEvidencijaRez : UserControl
    {
        public UCPrikazEvidencijaRez()
        {
            InitializeComponent();
        }

        private void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            if (!Koordinator.Instance.ListaEvidencijaRezervacija.IsNullOrEmpty())
            {
                Koordinator.Instance.PrikazEvidencijaRezController.AzurirajTabelu();
            }

        }

        private void btnUnesiKriterijumPretrage_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.PrikazEvidencijaRezController.UnesiKriterijumPretgrage();
        }

        private void dgvEvidencije_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Koordinator.Instance.PrikazEvidencijaRezController.PretraziEvidencijaRez(e.RowIndex);
            }
        }

        private void dgvEvidencije_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Kolona: {DgvEvidencije.Columns[e.ColumnIndex].Name}, red: {e.RowIndex}");
            e.ThrowException = false;
        }
    }
}

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
    public partial class UCStavkeEvidencijaRez : UserControl
    {
        public UCStavkeEvidencijaRez()
        {
            InitializeComponent();
        }

        private void btnDodajStavka_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriFrmStavkaEvidencije(new Common.Domain.StavkaEvidencije());
        }
        private void dgvStavke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Koordinator.Instance.StavkeEvidencijaRezUCController.IzabranaStavka(e.RowIndex);
            
        }

        private void btnIzmeniStavka_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.StavkeEvidencijaRezUCController.IzmeniStavkaEvidencije();
        }

        private void btnObrisiStavka_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.StavkeEvidencijaRezUCController.ObrisiStavkaEvidencije();
        }

        private void btnPromeniEvidencijaRez_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.StavkeEvidencijaRezUCController.PromeniEvidencijaRez();
        }

        //private void dgvStavke_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    MessageBox.Show($"Kolona: {DgvStavke.Columns[e.ColumnIndex].Name}, red: {e.RowIndex}");
        //    e.ThrowException = false;
        //}
    }
}

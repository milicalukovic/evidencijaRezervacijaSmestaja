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
    public partial class UCIzabranaEvidencijaRez : UserControl
    {
        public UCIzabranaEvidencijaRez()
        {
            InitializeComponent();
        }

        private void btnPromeniEvidencijaRez_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.IzabranaEvidencijaRezController.PromeniEvidencijaRez();
        }

        private void dgvStavke_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Kolona: {DgvStavke.Columns[e.ColumnIndex].Name}, red: {e.RowIndex}");
            e.ThrowException = false;
        }
    }
}

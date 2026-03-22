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
    public partial class FrmIzvorOcene : Form
    {
        public FrmIzvorOcene()
        {
            InitializeComponent();
        }

        private void FrmIzvorOcene_Load(object sender, EventArgs e)
        {

        }

        private void btnUbaciIzvorOcene_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.IzvorOceneController.UbaciIzvorOcene();
        }

    }
}

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
    public partial class FrmGlavna : Form
    {
        public FrmGlavna()
        {
            InitializeComponent();
            vlasnikMenuItem.Text = Koordinator.Instance.UlogovaniVlasnik.ToString();
        }

        private void odjava_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.GlavnaFrmController.OdjaviVlasnik();
        }

        private void ubaciIzvorOcene_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.GlavnaFrmController.UbaciIzvorOcene();
        }

        private void prikaziMenuItem_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.GlavnaFrmController.PrikaziSmestajneJedinice();
        }

        private void FrmGlavna_Load(object sender, EventArgs e)
        {

        }

        private void FrmGlavna_FormClosing(object sender, FormClosingEventArgs e)
        {
            Koordinator.Instance.GlavnaFrmController.OdjaviVlasnik();
        }
    }
}

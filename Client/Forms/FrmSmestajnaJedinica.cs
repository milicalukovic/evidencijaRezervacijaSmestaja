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
    public partial class FrmSmestajnaJedinica : Form
    {
        public FrmSmestajnaJedinica()
        {
            InitializeComponent();
        }

        private void btnKreirajSJ_Click(object sender, EventArgs e)
        {
            //zapamti sj koju smo kreirali
            Koordinator.Instance.SmestajnaJedinicaFrmController.PromeniSmestajnaJedinica();
        }

        private void btnPromeniSJ_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaFrmController.PromeniSmestajnaJedinica();
        }

        private void btnObrisiSJ_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.SmestajnaJedinicaFrmController.ObrisiSmestajnaJedinica();
        }

        private void FrmSmestajnaJedinica_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Koordinator.Instance.ModeKreirajSJ) //ako je u mode kreiraj i zatvori formu => obrisi kreiranu sj
            {
                Koordinator.Instance.SmestajnaJedinicaFrmController.ObrisiSmestajnaJedinica();
            }
            else                                    //ako je sacuvana vrednost IzabraneSJ => osvezi 
            {
                Koordinator.Instance.SmestajnaJedinicaUCController.IzabranaSJ(-1);
            }
        }

        
    }
}

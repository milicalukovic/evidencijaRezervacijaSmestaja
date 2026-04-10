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
    public partial class FrmPromeniEvidencijaRez : Form
    {
        public FrmPromeniEvidencijaRez()
        {
            InitializeComponent();
        }

        private bool dozvoliZatvaranje = false;
        private void FrmPromeniEvidencijaRez_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (dozvoliZatvaranje) return;

            if (Koordinator.Instance.IzmenjenaEvidencija!=null //ako se vec desilo promeni evidencija SO ne treba da se prikazuje
                && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult rezultat = MessageBox.Show(
                    "Niste sacuvali izmene. \nDa li zelite da zatvorite formu?",
                    "Upozorenje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (rezultat == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                try
                {
                    // obrisi evidenciju iz baze ako je već kreirana
                    Koordinator.Instance.PromeniEvidencijaRezFrmController.ObrisiEvidenciju();

                    dozvoliZatvaranje = true;
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Sistem ne može da obriše evidenciju iz baze.",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    e.Cancel = true;
                }
            }
        }

       
    }
}

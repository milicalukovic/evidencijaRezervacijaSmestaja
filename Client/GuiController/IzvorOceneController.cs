using Client.Forms;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class IzvorOceneController
    {
        private FrmIzvorOcene Frm;
        public IzvorOceneController(FrmIzvorOcene Frm)
        {
            this.Frm = Frm;
        }

        internal void OtvoriFormu()
        {
            Frm.Show();
        }

        internal void UbaciIzvorOcene()
        {
            if (!Validacija()) { 
                return;
            }
            IzvorOcene izvor = new IzvorOcene
            {
                Naziv = Frm.TxtNaziv.Text.Trim(),
            };
             
            Odgovor serverOdg = Communication.Instance.UbaciIzvorOcene(izvor);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                IzvorOcene novi = serverOdg.Result as IzvorOcene;
                MessageBox.Show(Frm, "Sistem je zapamtio izvor ocene " + novi.ToString() + ".", "USPESNO",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (serverOdg.ExceptionMessage.Contains("UNIQUE"))
                {
                    MessageBox.Show(Frm, "Sistem ne moze da zapamti izvor ocene. Izvor ocene vec postoji.", "GRESKA",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show(Frm, "Sistem ne moze da zapamti izvor ocene.", "GRESKA",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Frm.Close();
        }

        private bool Validacija()
        {
            if (string.IsNullOrEmpty(Frm.TxtNaziv.Text.Trim()))
            {
                MessageBox.Show(Frm, "Morate uneti naziv izvora ocene.", "GRESKA",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}

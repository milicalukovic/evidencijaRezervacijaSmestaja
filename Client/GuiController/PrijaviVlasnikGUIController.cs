using Client.Session;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class PrijaviVlasnikGUIController
    {
        private readonly FrmPrijaviVlasnik frmPrijaviVlasnik;
        public PrijaviVlasnikGUIController(FrmPrijaviVlasnik frmPrijaviVlasnik) { this.frmPrijaviVlasnik = frmPrijaviVlasnik; }

        public void PrijaviVlasnik()
        {
            if (!Validacija())
            {
                MessageBox.Show(frmPrijaviVlasnik, "Popunite sva polja!", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Communication.Instance.Connect();
                Debug.WriteLine("Konektovani na server");

                Vlasnik z = new Vlasnik
                {
                    KorisnickoIme= frmPrijaviVlasnik.TxtKorisnickoIme.Text,
                    Lozinka = frmPrijaviVlasnik.TxtLozinka.Text
                };

                Odgovor response = Communication.Instance.PrijaviVlasnik(z);
                if (response.ExceptionMessage == null) //postoji u bazi
                {

                    Koordinator.Instance.UlogovaniVlasnik = (Vlasnik)response.Result;
                    MessageBox.Show(frmPrijaviVlasnik, "Korisnicko ime i sifra su ispravni", "USPEŠNO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPrijaviVlasnik.DialogResult = DialogResult.OK;
                    frmPrijaviVlasnik.Close();
                   // Koordinator.Instance.OtvoriGlavnuFormu();

                }
                else //nema zaposlenog u bazi, desila se neka greska
                {
                    MessageBox.Show(frmPrijaviVlasnik, "Korisnicno ime i sifra nisu ispravni " + response.ExceptionMessage, "GREŠKA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SocketException e)
            {

                MessageBox.Show(frmPrijaviVlasnik, "Nije moguce uspostaviti konekciju sa serverom: " + e.Message,
                                         "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {

                MessageBox.Show(frmPrijaviVlasnik, "Ne moze da se otvori glavna forma i meni" + e.Message,
                                            "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private bool Validacija() //da li su popunjena polja + DODATI VALIDACIJU ZA PODATKE
        {
            bool signal = true;
            if (string.IsNullOrEmpty(frmPrijaviVlasnik.TxtKorisnickoIme.Text) ||
                string.IsNullOrEmpty(frmPrijaviVlasnik.TxtLozinka.Text))
            {
                signal = false;
            }

            return signal;

        }

        internal void OtvoriFormu()
        {
            frmPrijaviVlasnik.ShowDialog();
        }
    }
}

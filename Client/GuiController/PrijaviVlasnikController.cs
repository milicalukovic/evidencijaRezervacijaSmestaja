using Client.Session;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class PrijaviVlasnikController
    {
        private FrmPrijaviVlasnik frmPrijaviVlasnik;
        public PrijaviVlasnikController(FrmPrijaviVlasnik frmPrijaviVlasnik) { this.frmPrijaviVlasnik = frmPrijaviVlasnik; }

        public void PrijaviVlasnik()
        {
            if (!Validacija())
            {
                return;
            }

            try
            {
                
                Vlasnik vl = new Vlasnik
                {
                    KorisnickoIme= frmPrijaviVlasnik.TxtKorisnickoIme.Text.Trim(),
                    Lozinka = frmPrijaviVlasnik.TxtLozinka.Text.Trim()
                };

                frmPrijaviVlasnik.TxtKorisnickoIme.BackColor = Color.White;

                Odgovor response = Communication.Instance.PrijaviVlasnik(vl); //saljemo zahtev i primamo odgovor
                if (response.ExceptionMessage == null && response.Result!=null) //postoji u bazi
                {

                    Koordinator.Instance.UlogovaniVlasnik = (Vlasnik)response.Result;
                    MessageBox.Show(frmPrijaviVlasnik, "Korisnicko ime i sifra su ispravni!", "USPESNA PRIJAVA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmPrijaviVlasnik.DialogResult = DialogResult.OK;
                    frmPrijaviVlasnik.Close();
                    Koordinator.Instance.OtvoriGlavnuFrm(); //ucitava sledecu

                }
                else //nema zaposlenog u bazi, desila se neka greska
                {
                    MessageBox.Show(frmPrijaviVlasnik, "Korisnicno ime i sifra nisu ispravni! ", "GRESKA",
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

                MessageBox.Show(frmPrijaviVlasnik, "Ne moze da se otvori glavna forma i meni!",
                                            "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private bool Validacija() //da li su popunjena polja + DODATI VALIDACIJU ZA PODATKE
        {
            if (string.IsNullOrEmpty(frmPrijaviVlasnik.TxtKorisnickoIme.Text.Trim()) ||
               string.IsNullOrEmpty(frmPrijaviVlasnik.TxtLozinka.Text.Trim()))
            {
                MessageBox.Show(frmPrijaviVlasnik, "Popunite sva polja!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            bool validEmail = MailAddress.TryCreate(frmPrijaviVlasnik.TxtKorisnickoIme.Text.Trim(), out _);
            if (!validEmail)
            {
                MessageBox.Show(frmPrijaviVlasnik, "Korisničko ime nije validno!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmPrijaviVlasnik.TxtKorisnickoIme.BackColor = Color.Red;
                return false;
            }
            return true;

        }

        internal void OtvoriFormu()
        {
            frmPrijaviVlasnik.ShowDialog();
        }

        
    }
}

using Client.Forms;
using Client.Model;
using Client.Session;
using Common.Communication;
using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class StavkaEvidencijeFrmController
    {
        private FrmStavkaEvidencije FrmStavka;

        public StavkaEvidencijeFrmController(FrmStavkaEvidencije frmStavka)
        {
            this.FrmStavka = frmStavka;
        }

        internal void OtvoriFormu(StavkaEvidencije stavka)
        {

            FrmStavka.LblRezervacija.Text = $"Rezervacija {Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Naziv} ({Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Tip.Naziv})";

            PopuniCMBVrstaUsluge();
            Popuni_Txt_Cmb_Mesec();
            FrmStavka.TxtKorisnik.ReadOnly = true;
            FrmStavka.TxtBrTel.ReadOnly = true;
            FrmStavka.TxtEmail.ReadOnly = true;

            if(stavka.Equals(Koordinator.Instance.IzabranaStavka)) //popuni podatke izabrane
            {
                Koordinator.Instance.IzmenjenaStavka = Koordinator.Instance.IzabranaStavka;

                StavkaEvidencije izabrana = Koordinator.Instance.IzmenjenaStavka;
                FrmStavka.NumericDanDolaska.Value = izabrana.DanDolaska;
                FrmStavka.NumericDanOdlaska.Value = izabrana.DanOdlaska;
                FrmStavka.NumericBrOsoba.Value = izabrana.BrOsoba;
                FrmStavka.CmbVrstaUsluge.SelectedItem = izabrana.VrstaUsluge;
                FrmStavka.MaskedTxtBrLicneKarte.Text = izabrana.Korisnik.BrLicneKarte;
                FrmStavka.TxtKorisnik.Text = $"{izabrana.Korisnik.Ime} {izabrana.Korisnik.Prezime}";
                FrmStavka.TxtEmail.Text = izabrana.Korisnik.Email;
                FrmStavka.TxtBrTel.Text = izabrana.Korisnik.BrTel;
                FrmStavka.CheckBoxUplacenAvans.Checked = izabrana.UplacenAvans;

                //ne moze da menja korisnika
                FrmStavka.MaskedTxtBrLicneKarte.ReadOnly = true;
                FrmStavka.BtnPretraziKorisnik.Visible = false;
            }
            else
            {
                FrmStavka.BtnZapamtiPodatke.Enabled = false;
            }
            FrmStavka.Show();
        }

        private void Popuni_Txt_Cmb_Mesec()
        {
            DateOnly mesecEvidencije = Koordinator.Instance.IzmenjenaEvidencija.Mesec;

            FrmStavka.TxtMesecDolaska.ReadOnly = true;
            FrmStavka.TxtMesecDolaska.Text = $"{(NazivMeseca)mesecEvidencije.Month} {mesecEvidencije.Year}.";

            int tekuciMesec = mesecEvidencije.Month;
            int sledeciMesec = mesecEvidencije.AddMonths(1).Month; //za decembar bice jan sledece

            var meseci = new[]
            {
                new { Mesec = tekuciMesec, Prikaz = $"{(NazivMeseca)tekuciMesec} {mesecEvidencije.Year}." },
                new { Mesec = sledeciMesec, Prikaz = $"{(NazivMeseca)sledeciMesec} {mesecEvidencije.AddMonths(1).Year}." }
            }.ToList();

            FrmStavka.CmbMesecOdlaska.DataSource = meseci;
            FrmStavka.CmbMesecOdlaska.DisplayMember = "Prikaz";
            FrmStavka.CmbMesecOdlaska.ValueMember = "Mesec";
            FrmStavka.CmbMesecOdlaska.Visible = true;
        }

        private void PopuniCMBVrstaUsluge()
        {
            VrstaUsluge osnovna = Koordinator.Instance.IzmenjenaEvidencija.OsnovnaVrstaUsluge;

            var dozvoljeneUsluge = Enum.GetValues(typeof(VrstaUsluge))
                .Cast<VrstaUsluge>()
                .Where(v => v >= osnovna)
                .ToList();

            FrmStavka.CmbVrstaUsluge.DataSource = dozvoljeneUsluge;
            FrmStavka.CmbVrstaUsluge.Visible = true;

        }

        internal void PretraziKorisnik()
        {
            if (!FrmStavka.MaskedTxtBrLicneKarte.MaskCompleted)
            {
                MessageBox.Show("Morate uneti svih 9 cifara broja licne karte!",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool pronadjen = false;
            foreach (Korisnik k in Koordinator.Instance.ListaKorisnik)
            {
                if (k.BrLicneKarte.Equals(FrmStavka.MaskedTxtBrLicneKarte.Text))
                {
                    Koordinator.Instance.Korisnik = k;
                    FrmStavka.TxtKorisnik.Text = $"{k.Ime} {k.Prezime}";
                    FrmStavka.TxtEmail.Text = k.Email;
                    FrmStavka.TxtBrTel.Text = k.BrTel;
                    MessageBox.Show(FrmStavka, "Sistem je nasao korisnika.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pronadjen = true;
                    FrmStavka.BtnZapamtiPodatke.Enabled = true;
                    FrmStavka.BtnPretraziKorisnik.Enabled = false;
                    FrmStavka.MaskedTxtBrLicneKarte.Enabled = false;
                    break;
                }
            }
            if (!pronadjen)
            {
                DialogResult rezultat = MessageBox.Show(FrmStavka, "Sistem nije nasao korisnika.\nDa li zelite da kreirate novog korisnika?", "GRESKA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rezultat == DialogResult.No)
                {
                    return;
                }
                
                    //dodaj korisnika
                 FrmStavka.TxtKorisnik.ReadOnly = false;
                 FrmStavka.TxtBrTel.ReadOnly = false;
                 FrmStavka.TxtEmail.ReadOnly = false;
                 FrmStavka.BtnPretraziKorisnik.Text = "Dodaj";

            }
        }
        internal void DodajKorisnik()
        {
            if (!ValidacijaKorisnika())
            {
                return;
            }
            Korisnik noviKorisnik = new Korisnik
            {
                Ime = FrmStavka.TxtKorisnik.Text.Split(' ')[0],
                Prezime = FrmStavka.TxtKorisnik.Text.Split(' ')[1],
                BrLicneKarte = FrmStavka.MaskedTxtBrLicneKarte.Text,
                BrTel = string.IsNullOrWhiteSpace(FrmStavka.TxtBrTel.Text)
                        ? null
                        : FrmStavka.TxtBrTel.Text.Trim(),

                Email = string.IsNullOrWhiteSpace(FrmStavka.TxtEmail.Text)
                        ? null
                        : FrmStavka.TxtEmail.Text.Trim(),
            };

            Odgovor serverOdg = Communication.Instance.DodajKorisnik(noviKorisnik);
            if(serverOdg == null || serverOdg.ExceptionMessage != null || serverOdg.Result==null)
            {
                MessageBox.Show(
                        "Sistem ne može da kreira korisnika.",
                        "Greška",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show(
                        "Sistem je dodao korisnika. Mozete uneti ostale podatke o rezervaciji! ",
                        "USPESNO",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                noviKorisnik = serverOdg.Result as Korisnik;
                Koordinator.Instance.ListaKorisnik.Add(noviKorisnik);
                Koordinator.Instance.Korisnik = noviKorisnik;

                FrmStavka.TxtKorisnik.ReadOnly = true;
                FrmStavka.TxtBrTel.ReadOnly = true;
                FrmStavka.TxtEmail.ReadOnly = true;
                FrmStavka.BtnPretraziKorisnik.Enabled = false;
                FrmStavka.MaskedTxtBrLicneKarte.Enabled = false;
                FrmStavka.BtnZapamtiPodatke.Enabled = true;
            }
        }

        private bool ValidacijaKorisnika()
        {
            if (!FrmStavka.MaskedTxtBrLicneKarte.MaskCompleted)
            {
                MessageBox.Show(FrmStavka, "Morate uneti ispravan broj licne karte!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var delovi = FrmStavka.TxtKorisnik.Text
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (delovi.Length < 2)
            {
                MessageBox.Show(FrmStavka,"Morate uneti ime i prezime gosta!","GRESKA",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!string.IsNullOrEmpty(FrmStavka.TxtEmail.Text.Trim()))
            {
                bool validEmail = MailAddress.TryCreate(FrmStavka.TxtEmail.Text.Trim(), out _);
                if (!validEmail)
                {
                    MessageBox.Show(FrmStavka, "Email mora sadrzati @ i tacku!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            return true;
        }

        internal void ZapamtiPodatke()
        {
            if (!Validacija())
                return;
            if(!Koordinator.Instance.IzabranaStavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                Koordinator.Instance.KreiranaStavka = new StavkaEvidencije
                {
                    Rb = Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije.Count + 1,
                    Evidencija = Koordinator.Instance.IzmenjenaEvidencija,
                    Korisnik = Koordinator.Instance.Korisnik,
                    DanDolaska = (int)FrmStavka.NumericDanDolaska.Value,
                    DanOdlaska = (int)FrmStavka.NumericDanOdlaska.Value,
                    BrDana = (int)FrmStavka.NumericDanOdlaska.Value - (int)FrmStavka.NumericDanDolaska.Value,
                    BrOsoba = (decimal)FrmStavka.NumericBrOsoba.Value,
                    VrstaUsluge = (VrstaUsluge)FrmStavka.CmbVrstaUsluge.SelectedItem,
                    UplacenAvans = FrmStavka.CheckBoxUplacenAvans.Checked,
                };
                Koordinator.Instance.IzmenjenaStavka = Koordinator.Instance.KreiranaStavka;

            }
            else                                                
            {
                StavkaEvidencije izabrana = Koordinator.Instance.IzmenjenaStavka;
                izabrana.DanDolaska = (int)FrmStavka.NumericDanDolaska.Value;
                izabrana.DanOdlaska = (int)FrmStavka.NumericDanOdlaska.Value;
                izabrana.BrDana = izabrana.DanOdlaska - izabrana.DanDolaska;
                izabrana.BrOsoba = (decimal)FrmStavka.NumericBrOsoba.Value;
                izabrana.VrstaUsluge = (VrstaUsluge)FrmStavka.CmbVrstaUsluge.SelectedItem;
                izabrana.UplacenAvans = FrmStavka.CheckBoxUplacenAvans.Checked;

            }
            //otvori panel i on azurira listu stavki
            FrmStavka.PanelIznosi.Controls.Clear();
            Koordinator.Instance.InicijalizujUCIznosiStavkeEvidencije();   
            Koordinator.Instance.IznosiStavkeEvidencijeController.PopuniPodatke(); 
            FrmStavka.PanelIznosi.Controls.Add(Koordinator.Instance.UCIznosiStavkeEvidencije); 
        }

        private bool Validacija()
        {
            
            //KAPACITET
            if((decimal)FrmStavka.NumericBrOsoba.Value < Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Tip.MinKapacitet)
            {
                MessageBox.Show(FrmStavka, "Minimalan kapacitet za izabrani tip smestaja je " + Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Tip.MinKapacitet.ToString(),
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((decimal)FrmStavka.NumericBrOsoba.Value > Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Tip.MaxKapacitet)
            {
                MessageBox.Show(FrmStavka, "Maksimalan kapacitet za izabrani tip smestaja je " + Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Tip.MaxKapacitet.ToString(),
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //DATUMI
            //ukoliko rezervacija prelazi u sledeci mesec
            if((int)FrmStavka.CmbMesecOdlaska.SelectedValue 
                == Koordinator.Instance.IzmenjenaEvidencija.Mesec.AddMonths(1).Month)
            {
                //provera da li postoji ta evidencija
                EvidencijaRez evidencijaSledecegMeseca = new EvidencijaRez();

                evidencijaSledecegMeseca.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                evidencijaSledecegMeseca.SmestajnaJedinica = Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica;
                evidencijaSledecegMeseca.Mesec = Koordinator.Instance.IzmenjenaEvidencija.Mesec.AddMonths(1);

                evidencijaSledecegMeseca.Validacija = true;
                Debug.WriteLine("WHERE: " + evidencijaSledecegMeseca.WhereClause);

                //pretrazi obj
                Odgovor serverOdg = Communication.Instance.PretraziEvidencijaRez(evidencijaSledecegMeseca);

                evidencijaSledecegMeseca.Validacija = false;

                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null) //postoji
                {
                    evidencijaSledecegMeseca = (EvidencijaRez)serverOdg.Result;

                    //podela na dve stavke

                    //validacija njenih datuma

                    return true;
                }
                else
                {
                    DialogResult rezultat = MessageBox.Show(FrmStavka, "Evidencija smestajne jedinice za naredni mesec ne postoji. Morate je kreirati da biste uneli navedeni period boravka za rezervaciju.\nDa li zelite da kreirate tu evidenciju rezervacija?", "GRESKA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rezultat == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        //kreira evidenciju za sledeci mesec pa se vraca na ovu

                        // pravi jednu stavku u ovoj a jednuu u novoj evidenciji / deli na dva dela i proverava datume tek tako podeljenih stavki

                    }
                }
                
                
            }
            return proveraDatuma();
        }

        internal bool proveraDatuma()
        {
            //provera datuma kada je rezervacija u okviru jednog meseca ili je vec podeljena na dve stavke
            int noviDanDolaska = (int)FrmStavka.NumericDanDolaska.Value;
            int noviDanOdlaska = (int)FrmStavka.NumericDanOdlaska.Value;

            if (noviDanDolaska >= noviDanOdlaska)
            {
                MessageBox.Show(FrmStavka, "Dan dolaska mora biti pre dana odlaska!",
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //provera u zavisnosti od meseca da li je prekoracen broj dana tj dan odlaska veci od br dana tog meseca

            int godina = Koordinator.Instance.IzmenjenaEvidencija.Mesec.Year;
            int brMeseca = Koordinator.Instance.IzmenjenaEvidencija.Mesec.Month;
            int brojDanaUMesecu = DateTime.DaysInMonth(godina, brMeseca);


            if (noviDanDolaska < 1 || noviDanDolaska > brojDanaUMesecu)
            {
                MessageBox.Show(
                    FrmStavka,
                    $"Dan dolaska mora biti u opsegu 1-{brojDanaUMesecu} za mesec {(NazivMeseca)brMeseca}.",
                    "UPOZORENJE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (noviDanOdlaska < 1 || noviDanOdlaska > brojDanaUMesecu)
            {
                MessageBox.Show(
                    FrmStavka,
                    $"Dan odlaska mora biti u opsegu 1-{brojDanaUMesecu} za mesec {(NazivMeseca)brMeseca}.",
                    "UPOZORENJE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            foreach (StavkaEvidencije stavka in Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije)
            {
                    //nova => uporedjujemo datume svih stavki koje su vec u evidenciji rez
                    //azurira postojecu => ne racunamo stare datume te stavke
                if (Koordinator.Instance.IzmenjenaStavka.Equals(Koordinator.Instance.KreiranaStavka) 
                    || !stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
                {
                    int postojeciDolazak = stavka.DanDolaska;
                    int postojeciOdlazak = stavka.DanOdlaska;

                    bool preklapaSe = noviDanDolaska < postojeciOdlazak && //novi početak je pre kraja stare rezervacije
                                          noviDanOdlaska > postojeciDolazak;   //novi kraj je posle početka stare rezervacije
                                                                               //samo ako su oba true => true

                    if (preklapaSe)
                    {
                        MessageBox.Show(
                                $"Termin se preklapa sa postojećom rezervacijom (period : " +
                                $"{postojeciDolazak}-{postojeciOdlazak}. {(NazivMeseca)Koordinator.Instance.IzmenjenaEvidencija.Mesec.Month}).",
                                "Upozorenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                         return false;
                    }
                }
            }
            return true;
        }

        internal void ZatvoriFormu()
        {
            OsveziVrednosti();

            FrmStavka.Close();
        }

        internal void OsveziVrednosti()
        {
            if (Koordinator.Instance.IzmenjenaStavka.Equals(Koordinator.Instance.KreiranaStavka))
            { 
                Koordinator.Instance.KreiranaStavka = null;
                Koordinator.Instance.Korisnik = null;
            }
            else
            {
                Koordinator.Instance.IzabranaStavka = null;
            }
            Koordinator.Instance.IzmenjenaStavka = null;
        }
    }
}

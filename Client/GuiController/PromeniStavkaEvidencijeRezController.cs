using Client.Model;
using Client.Session;
using Client.UserControls;
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
    public class PromeniStavkaEvidencijeRezController
    {
        private UCPromeniStavkaEvidencijeRez UCStavka;

        public PromeniStavkaEvidencijeRezController(UCPromeniStavkaEvidencijeRez uCPromeniStavkaEvidencijeRez)
        {
            this.UCStavka = uCPromeniStavkaEvidencijeRez;
        }

        internal void PopuniPodatke()
        {
            UCStavka.LblRezervacija.Text = $"Rezervacija {Koordinator.Instance.Evidencija.SmestajnaJedinica.Naziv} ({Koordinator.Instance.Evidencija.SmestajnaJedinica.Tip.Naziv})";

            PopuniCMBVrstaUsluge();
            PodesiDateTimePickere();
            Popuni_Txt_Cmb_Mesec();
            UCStavka.TxtKorisnik.ReadOnly = true;
            UCStavka.TxtBrTel.ReadOnly = true;
            UCStavka.TxtEmail.ReadOnly = true;

            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka)) //popuni podatke izabrane
            {
                StavkaEvidencije izabrana = Koordinator.Instance.Stavka;
                DateTime mesec = new DateTime(
                    izabrana.Evidencija.Mesec.Year,
                    izabrana.Evidencija.Mesec.Month,
                    1
                );

                UCStavka.DtpDatumDolaska.Value = mesec.AddDays(izabrana.DanDolaska - 1);

                if (izabrana.BrDana > izabrana.DanOdlaska - izabrana.DanDolaska)
                {
                    UCStavka.DtpDatumOdlaska.Value = mesec.AddMonths(1);
                }
                else
                {
                    UCStavka.DtpDatumOdlaska.Value = mesec.AddDays(izabrana.DanOdlaska - 1);
                }


                UCStavka.NumericDanDolaska.Value = izabrana.DanDolaska;

                if (izabrana.BrDana > izabrana.DanOdlaska - izabrana.DanDolaska)
                {
                    UCStavka.NumericDanOdlaska.Value = 1;
                    UCStavka.CmbMesecOdlaska.SelectedIndex = 1;
                }
                else
                {
                    UCStavka.NumericDanOdlaska.Value = izabrana.DanOdlaska;
                    UCStavka.CmbMesecOdlaska.SelectedIndex = 0;
                }

                UCStavka.NumericBrOsoba.Value = izabrana.BrOsoba;
                UCStavka.CmbVrstaUsluge.SelectedItem = izabrana.VrstaUsluge;
                UCStavka.MaskedTxtBrLicneKarte.Text = izabrana.Korisnik.BrLicneKarte;
                UCStavka.TxtKorisnik.Text = $"{izabrana.Korisnik.Ime} {izabrana.Korisnik.Prezime}";
                UCStavka.TxtEmail.Text = izabrana.Korisnik.Email;
                UCStavka.TxtBrTel.Text = izabrana.Korisnik.BrTel;
                UCStavka.CheckBoxUplacenAvans.Checked = izabrana.UplacenAvans;

                //ne moze da menja korisnika
                UCStavka.MaskedTxtBrLicneKarte.ReadOnly = true;
                UCStavka.BtnPretraziKorisnik.Visible = false;
            }
            else
            {
                UCStavka.BtnZapamtiPodatke.Enabled = false;
            }
            UCStavka.Show();
        }

        private void PodesiDateTimePickere()
        {
            DateOnly mesecEvidencije = Koordinator.Instance.Evidencija.Mesec;

            DateTime pocetakTekucegMeseca =
                new DateTime(mesecEvidencije.Year, mesecEvidencije.Month, 1);

            DateTime krajSledecegMeseca =
                pocetakTekucegMeseca.AddMonths(2).AddDays(-1);

            UCStavka.DtpDatumDolaska.Format = DateTimePickerFormat.Custom;
            UCStavka.DtpDatumDolaska.CustomFormat = "dd.MM.yyyy.";
            UCStavka.DtpDatumDolaska.MinDate = pocetakTekucegMeseca;
            UCStavka.DtpDatumDolaska.MaxDate = krajSledecegMeseca;

            UCStavka.DtpDatumOdlaska.Format = DateTimePickerFormat.Custom;
            UCStavka.DtpDatumOdlaska.CustomFormat = "dd.MM.yyyy.";
            UCStavka.DtpDatumOdlaska.MinDate = pocetakTekucegMeseca;
            UCStavka.DtpDatumOdlaska.MaxDate = krajSledecegMeseca;

            UCStavka.DtpDatumDolaska.Value = pocetakTekucegMeseca;
            UCStavka.DtpDatumOdlaska.Value = pocetakTekucegMeseca;
        }
        private void Popuni_Txt_Cmb_Mesec()
        {
            DateOnly mesecEvidencije = Koordinator.Instance.Evidencija.Mesec;

            UCStavka.TxtMesecDolaska.ReadOnly = true;
            UCStavka.TxtMesecDolaska.Text = $"{(NazivMeseca)mesecEvidencije.Month} {mesecEvidencije.Year}.";

            int tekuciMesec = mesecEvidencije.Month;
            int sledeciMesec = mesecEvidencije.AddMonths(1).Month; //za decembar bice jan sledece

            var meseci = new[]
            {
                new { Mesec = tekuciMesec, Prikaz = $"{(NazivMeseca)tekuciMesec} {mesecEvidencije.Year}." },
                new { Mesec = sledeciMesec, Prikaz = $"{(NazivMeseca)sledeciMesec} {mesecEvidencije.AddMonths(1).Year}." }
            }.ToList();

            UCStavka.CmbMesecOdlaska.DataSource = meseci;
            UCStavka.CmbMesecOdlaska.DisplayMember = "Prikaz";
            UCStavka.CmbMesecOdlaska.ValueMember = "Mesec";
            UCStavka.CmbMesecOdlaska.Visible = true;
        }

        private void PopuniCMBVrstaUsluge()
        {
            VrstaUsluge osnovna = Koordinator.Instance.Evidencija.OsnovnaVrstaUsluge;

            var dozvoljeneUsluge = Enum.GetValues(typeof(VrstaUsluge))
                .Cast<VrstaUsluge>()
                .Where(v => v >= osnovna)
                .ToList();

            UCStavka.CmbVrstaUsluge.DataSource = dozvoljeneUsluge;
            UCStavka.CmbVrstaUsluge.Visible = true;

        }

        internal void PretraziKorisnik()
        {
            if (!UCStavka.MaskedTxtBrLicneKarte.MaskCompleted)
            {
                MessageBox.Show("Morate uneti svih 9 cifara broja licne karte!",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool pronadjen = false;
            foreach (Korisnik k in Koordinator.Instance.ListaKorisnik)
            {
                if (k.BrLicneKarte.Equals(UCStavka.MaskedTxtBrLicneKarte.Text))
                {
                    Koordinator.Instance.Korisnik = k;
                    UCStavka.TxtKorisnik.Text = $"{k.Ime} {k.Prezime}";
                    UCStavka.TxtEmail.Text = k.Email;
                    UCStavka.TxtBrTel.Text = k.BrTel;
                    MessageBox.Show(UCStavka, "Sistem je nasao korisnika.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pronadjen = true;
                    UCStavka.BtnZapamtiPodatke.Enabled = true;
                    UCStavka.BtnPretraziKorisnik.Enabled = false;
                    UCStavka.MaskedTxtBrLicneKarte.Enabled = false;
                    break;
                }
            }
            if (!pronadjen)
            {
                DialogResult rezultat = MessageBox.Show(UCStavka, "Sistem nije nasao korisnika.\nDa li zelite da kreirate novog korisnika?", "GRESKA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (rezultat == DialogResult.No)
                {
                    return;
                }

                //dodaj korisnika
                UCStavka.TxtKorisnik.ReadOnly = false;
                UCStavka.TxtBrTel.ReadOnly = false;
                UCStavka.TxtEmail.ReadOnly = false;
                UCStavka.BtnPretraziKorisnik.Text = "Dodaj";

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
                Ime = UCStavka.TxtKorisnik.Text.Split(' ')[0],
                Prezime = UCStavka.TxtKorisnik.Text.Split(' ')[1],
                BrLicneKarte = UCStavka.MaskedTxtBrLicneKarte.Text,
                BrTel = string.IsNullOrWhiteSpace(UCStavka.TxtBrTel.Text)
                        ? null
                        : UCStavka.TxtBrTel.Text.Trim(),

                Email = string.IsNullOrWhiteSpace(UCStavka.TxtEmail.Text)
                        ? null
                        : UCStavka.TxtEmail.Text.Trim(),
            };

            Odgovor serverOdg = Communication.Instance.DodajKorisnik(noviKorisnik);
            if (serverOdg == null || serverOdg.ExceptionMessage != null || serverOdg.Result == null)
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

                UCStavka.TxtKorisnik.ReadOnly = true;
                UCStavka.TxtBrTel.ReadOnly = true;
                UCStavka.TxtEmail.ReadOnly = true;
                UCStavka.BtnPretraziKorisnik.Enabled = false;
                UCStavka.MaskedTxtBrLicneKarte.Enabled = false;
                UCStavka.BtnZapamtiPodatke.Enabled = true;
            }
        }

        private bool ValidacijaKorisnika()
        {
            if (!UCStavka.MaskedTxtBrLicneKarte.MaskCompleted)
            {
                MessageBox.Show(UCStavka, "Morate uneti ispravan broj licne karte!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            var delovi = UCStavka.TxtKorisnik.Text
                            .Trim()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (delovi.Length < 2)
            {
                MessageBox.Show(UCStavka, "Morate uneti ime i prezime gosta!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!string.IsNullOrEmpty(UCStavka.TxtEmail.Text.Trim()))
            {
                bool validEmail = MailAddress.TryCreate(UCStavka.TxtEmail.Text.Trim(), out _);
                if (!validEmail)
                {
                    MessageBox.Show(UCStavka, "Email mora sadrzati @ i tacku!", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        internal void ZapamtiPodatke()
        {

            if (!Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                Koordinator.Instance.Stavka = new StavkaEvidencije
                {
                    Rb = Koordinator.Instance.Evidencija.StavkeEvidencije.Count,
                    Evidencija = Koordinator.Instance.Evidencija,
                    Korisnik = Koordinator.Instance.Korisnik,

                    DanDolaska = (int)UCStavka.DtpDatumDolaska.Value.Date.Day,
                    DanOdlaska = (int)UCStavka.DtpDatumOdlaska.Value.Date.Day,
                    BrDana = ((int)UCStavka.DtpDatumOdlaska.Value.Date.Day - (int)UCStavka.DtpDatumDolaska.Value.Date.Day),
                    //DanDolaska = (int)UCStavka.NumericDanDolaska.Value,
                    //DanOdlaska = (int)UCStavka.NumericDanOdlaska.Value,
                    //BrDana = (int)UCStavka.NumericDanOdlaska.Value - (int)UCStavka.NumericDanDolaska.Value,
                    BrOsoba = (decimal)UCStavka.NumericBrOsoba.Value,
                    VrstaUsluge = (VrstaUsluge)UCStavka.CmbVrstaUsluge.SelectedItem,
                    UplacenAvans = UCStavka.CheckBoxUplacenAvans.Checked,
                };


            }
            else
            {
                StavkaEvidencije izabrana = Koordinator.Instance.IzmenjenaStavka; //menjamo je
                izabrana.DanDolaska = (int)UCStavka.NumericDanDolaska.Value;
                izabrana.DanOdlaska = (int)UCStavka.NumericDanOdlaska.Value;
                izabrana.BrDana = izabrana.DanOdlaska - izabrana.DanDolaska;
                izabrana.BrOsoba = (decimal)UCStavka.NumericBrOsoba.Value;
                izabrana.VrstaUsluge = (VrstaUsluge)UCStavka.CmbVrstaUsluge.SelectedItem;
                izabrana.UplacenAvans = UCStavka.CheckBoxUplacenAvans.Checked;

            }
            if (!Validacija())
                return; //OSVEZII SVE VREDNOSTI STAVKI

            //otvori panel i on azurira listu stavki
            UCStavka.PanelIznosi.Controls.Clear();
            Koordinator.Instance.InicijalizujUCIznosiStavkeEvidencije();

            if (Koordinator.Instance.StavkaSledecegMeseca != null)
            {
                Koordinator.Instance.IznosiStavkeEvidencijeController.PopuniPodatkeZaDveStavke();
            }
            else
            {
                Koordinator.Instance.IznosiStavkeEvidencijeController.PopuniPodatke();
            }
            UCStavka.PanelIznosi.Controls.Add(Koordinator.Instance.UCIznosiStavkeEvidencije);
        }

        private bool Validacija()
        {

            //KAPACITET
            if ((decimal)UCStavka.NumericBrOsoba.Value < Koordinator.Instance.Evidencija.SmestajnaJedinica.Tip.MinKapacitet)
            {
                MessageBox.Show(UCStavka, "Minimalan kapacitet za izabrani tip smestaja je " + Koordinator.Instance.Evidencija.SmestajnaJedinica.Tip.MinKapacitet.ToString(),
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((decimal)UCStavka.NumericBrOsoba.Value > Koordinator.Instance.Evidencija.SmestajnaJedinica.Tip.MaxKapacitet)
            {
                MessageBox.Show(UCStavka, "Maksimalan kapacitet za izabrani tip smestaja je " + Koordinator.Instance.Evidencija.SmestajnaJedinica.Tip.MaxKapacitet.ToString(),
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //DATUMI
            //ukoliko rezervacija prelazi u sledeci mesec
            if ((int)UCStavka.DtpDatumOdlaska.Value.Month
                == Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month)
            {
                if ((int)UCStavka.NumericDanOdlaska.Value == 1) //samo do prvog u narednom mesecu
                {
                    return PodeliNaDveStavke();
                }
                //provera da li postoji ta evidencija
                EvidencijaRez evidencijaSledecegMeseca = new EvidencijaRez();

                evidencijaSledecegMeseca.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                evidencijaSledecegMeseca.SmestajnaJedinica = Koordinator.Instance.Evidencija.SmestajnaJedinica;
                evidencijaSledecegMeseca.Mesec = Koordinator.Instance.Evidencija.Mesec.AddMonths(1);

                evidencijaSledecegMeseca.Validacija = true;
                Debug.WriteLine("WHERE: " + evidencijaSledecegMeseca.WhereClause);

                //pretrazi obj
                Odgovor serverOdg = Communication.Instance.PretraziEvidencijaRez(evidencijaSledecegMeseca);

                evidencijaSledecegMeseca.Validacija = false;

                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null) //postoji
                {
                    //podela na dve stavke i validacija njihovih datuma
                    Koordinator.Instance.EvidencijaSledecegMeseca = (EvidencijaRez)serverOdg.Result;

                    return PodeliNaDveStavke();


                }
                else
                {
                    DialogResult rezultat = MessageBox.Show(UCStavka, "Evidencija smestajne jedinice za naredni mesec ne postoji. Morate je kreirati da biste uneli navedeni period boravka za rezervaciju.\nDa li zelite da kreirate tu evidenciju rezervacija?", "GRESKA", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (rezultat == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {

                        EvidencijaRez sledeca = new EvidencijaRez
                        {
                            Vlasnik = Koordinator.Instance.UlogovaniVlasnik,
                            SmestajnaJedinica = Koordinator.Instance.Evidencija.SmestajnaJedinica,
                            Mesec = Koordinator.Instance.Evidencija.Mesec.AddMonths(1),
                            SezonskiKoeficijentCene = Koordinator.Instance.Evidencija.SezonskiKoeficijentCene,
                            ProcenatAvansa = Koordinator.Instance.Evidencija.ProcenatAvansa,

                            OsnovnaCenaPoOsobi = Koordinator.Instance.Evidencija.SmestajnaJedinica.CenaPoOsobi,
                            PovecanjeCenePoUsluzi = Koordinator.Instance.Evidencija.SmestajnaJedinica.PovecanjeCenePoUsluzi,
                            OsnovnaVrstaUsluge = Koordinator.Instance.Evidencija.SmestajnaJedinica.OsnovnaVrstaUsluge
                        };

                        Odgovor odg = Communication.Instance.KreirajEvidencijaRez(sledeca);
                        if (odg.ExceptionMessage == null && odg.Result != null)
                        {
                            sledeca = odg.Result as EvidencijaRez;
                            Koordinator.Instance.EvidencijaSledecegMeseca = sledeca;
                            MessageBox.Show(UCStavka, "Sistem je kreirao evidenciju rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return PodeliNaDveStavke();
                        }
                        else
                        {
                            MessageBox.Show(UCStavka, "Sistem ne moze da kreira  evidenciju rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine(odg.ExceptionMessage);
                            return false;
                        }


                    }
                }


            }

            
            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                return proveraDatuma(Koordinator.Instance.IzmenjenaStavka);
            }
            else
            {
                return proveraDatuma(Koordinator.Instance.Stavka);
            }
        }

        private bool PodeliNaDveStavke() // pravi jednu stavku u tekucoj a jednu u sledecoj evidenciji 
                                         // deli na dva dela i proverava datume tek tako podeljenih stavki
        {

            StavkaEvidencije stavkaTekuciMesec;
            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                stavkaTekuciMesec = Koordinator.Instance.IzmenjenaStavka;
            }
            else
            {
                stavkaTekuciMesec = Koordinator.Instance.Stavka;
            }

            stavkaTekuciMesec.DanDolaska = (int)UCStavka.NumericDanDolaska.Value;
            stavkaTekuciMesec.DanOdlaska = DateTime.DaysInMonth(stavkaTekuciMesec.Evidencija.Mesec.Year, stavkaTekuciMesec.Evidencija.Mesec.Month);
            
            if(stavkaTekuciMesec.DanDolaska == stavkaTekuciMesec.DanOdlaska) //od poslednjeg dana u mesecu
            {
                stavkaTekuciMesec.BrDana = 1;
            }
            else
            {
                stavkaTekuciMesec.BrDana = 1 + stavkaTekuciMesec.DanOdlaska - stavkaTekuciMesec.DanDolaska;
                //racuna i 1 noc izmedju poslednjeg dana tekuceg meseca i prvog dana sl meseca
            }


            if (!proveraDatuma(stavkaTekuciMesec))
                return false;

            //ispravna provera => dan odlaska je 1. u narednom mesecu
            stavkaTekuciMesec.DanOdlaska = 1;

            if ((int)UCStavka.NumericDanOdlaska.Value != 1)  //ako nije do 1. u narednom mesecu => ne pravimo rezervaciju za sl
            {
                StavkaEvidencije stavkaSlMesec = new StavkaEvidencije
                {
                    Evidencija = Koordinator.Instance.EvidencijaSledecegMeseca,
                    Korisnik = stavkaTekuciMesec.Korisnik,
                    StatusStavke = StatusStavke.DODATA,
                    DanDolaska = 1,
                    DanOdlaska = (int)UCStavka.NumericDanOdlaska.Value,
                    BrDana = (int)UCStavka.NumericDanOdlaska.Value - 1,
                    BrOsoba = (decimal)UCStavka.NumericBrOsoba.Value,
                    VrstaUsluge = (VrstaUsluge)UCStavka.CmbVrstaUsluge.SelectedItem,
                    UplacenAvans = UCStavka.CheckBoxUplacenAvans.Checked,
                };


                if (!proveraDatuma(stavkaSlMesec))
                    return false;

                Koordinator.Instance.StavkaSledecegMeseca = stavkaSlMesec;
            }
            
            return true; 
        }

        internal bool proveraDatuma(StavkaEvidencije s)
        {
            //provera datuma kada je rezervacija u okviru jednog meseca ili je vec podeljena na dve stavke
            int noviDanDolaska = s.DanDolaska;
            int noviDanOdlaska = s.DanOdlaska;

            
            //provera u zavisnosti od meseca da li je prekoracen broj dana tj dan odlaska veci od br dana tog meseca

            int godina = s.Evidencija.Mesec.Year;
            int brMeseca = s.Evidencija.Mesec.Month;
            int brojDanaUMesecu = DateTime.DaysInMonth(godina, brMeseca);

            if (noviDanDolaska >= noviDanOdlaska &&
                (noviDanDolaska==brojDanaUMesecu && (int)UCStavka.CmbMesecOdlaska.SelectedValue    //izastavi slucaj kada je rez kreirana od posl dana meseca do sl meseca
                != Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month))
            {
                MessageBox.Show(UCStavka, "Dan dolaska mora biti pre dana odlaska!",
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (noviDanDolaska < 1 || noviDanDolaska > brojDanaUMesecu)
            {
                MessageBox.Show(
                    UCStavka,
                    $"Dan dolaska mora biti u opsegu 1-{brojDanaUMesecu} za mesec {(NazivMeseca)brMeseca}.",
                    "UPOZORENJE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (noviDanOdlaska < 1 || noviDanOdlaska > brojDanaUMesecu)
            {
                MessageBox.Show(
                    UCStavka,
                    $"Dan odlaska mora biti u opsegu 1-{brojDanaUMesecu} za mesec {(NazivMeseca)brMeseca}.",
                    "UPOZORENJE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            foreach (StavkaEvidencije stavka in s.Evidencija.StavkeEvidencije)
            {
                //nova => uporedjujemo datume svih stavki koje su vec u evidenciji rez
                //azurira izabranu => ne racunamo stare datume te stavke
                //evidencija sl meseca => uporedjuje datume svih vec postojecih stavki u toj evidenciji
                if (!Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka)
                    || !stavka.Equals(Koordinator.Instance.Stavka) || stavka.Evidencija.Equals(Koordinator.Instance.EvidencijaSledecegMeseca))
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
                                $"{postojeciDolazak}-{postojeciOdlazak}. {(NazivMeseca)s.Evidencija.Mesec.Month}).",
                                "Upozorenje",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                        return false;
                    }
                }
            }
            return true;
        }

        internal void OsveziVrednosti()
        {

            if(Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
                Koordinator.Instance.IzmenjenaStavka = null;

            Koordinator.Instance.Stavka = null;
            Koordinator.Instance.StavkaSledecegMeseca = null;

        }

        internal void Odustani()
        {
            //ako je vec kreirana evidencija
            if (Koordinator.Instance.EvidencijaSledecegMeseca != null)
            {
                Odgovor odg2 = Communication.Instance.ObrisiEvidencijaRez(Koordinator.Instance.EvidencijaSledecegMeseca);

                if (odg2.ExceptionMessage != null)
                    throw new Exception(odg2.ExceptionMessage);

                Koordinator.Instance.EvidencijaSledecegMeseca = null;
            }
            //ako je izabrana vrati je na prethodne vrednosti
            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                Koordinator.Instance.IzmenjenaStavka = null;
            }
            Koordinator.Instance.Stavka = null;
            Koordinator.Instance.StavkaSledecegMeseca = null;

            Koordinator.Instance.GlavnaFrmController.StavkeEvidencijeRez();
        }
    }

}

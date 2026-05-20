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
           
            UCStavka.TxtKorisnik.ReadOnly = true;
            UCStavka.TxtBrTel.ReadOnly = true;
            UCStavka.TxtEmail.ReadOnly = true;

            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka)) //popuni podatke izabrane
            {
                StavkaEvidencije izabrana = Koordinator.Instance.Stavka;

                UCStavka.DtpDatumDolaska.Value = izabrana.Dolazak.ToDateTime(TimeOnly.MinValue);
                UCStavka.DtpDatumOdlaska.Value = izabrana.Odlazak.ToDateTime(TimeOnly.MinValue);


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

            DateTime krajTekucegMeseca =
                pocetakTekucegMeseca.AddMonths(1).AddDays(-1);
            DateTime krajSledecegMeseca =
                pocetakTekucegMeseca.AddMonths(2).AddDays(-1);

            UCStavka.DtpDatumDolaska.Format = DateTimePickerFormat.Custom;
            UCStavka.DtpDatumDolaska.CustomFormat = "dd.MM.yyyy.";
            UCStavka.DtpDatumDolaska.MinDate = pocetakTekucegMeseca;
            UCStavka.DtpDatumDolaska.MaxDate = krajTekucegMeseca;

            UCStavka.DtpDatumOdlaska.Format = DateTimePickerFormat.Custom;
            UCStavka.DtpDatumOdlaska.CustomFormat = "dd.MM.yyyy.";
            UCStavka.DtpDatumOdlaska.MinDate = pocetakTekucegMeseca;
            UCStavka.DtpDatumOdlaska.MaxDate = krajSledecegMeseca;

            UCStavka.DtpDatumDolaska.Value = pocetakTekucegMeseca;
            UCStavka.DtpDatumOdlaska.Value = pocetakTekucegMeseca;
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
            DateOnly dolazak = DateOnly.FromDateTime(UCStavka.DtpDatumDolaska.Value.Date);
            DateOnly odlazak = DateOnly.FromDateTime(UCStavka.DtpDatumOdlaska.Value.Date);

            StavkaEvidencije stavka;

            if (!Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                //Koordinator.Instance.Stavka = new StavkaEvidencije
                stavka = new StavkaEvidencije
                {
                    Rb = Koordinator.Instance.Evidencija.StavkeEvidencije.Count,
                    Evidencija = Koordinator.Instance.Evidencija,
                    Korisnik = Koordinator.Instance.Korisnik,

                    Dolazak = dolazak,
                    Odlazak = odlazak,
                    BrDana = odlazak.DayNumber - dolazak.DayNumber,
                    BrOsoba = (decimal)UCStavka.NumericBrOsoba.Value,
                    VrstaUsluge = (VrstaUsluge)UCStavka.CmbVrstaUsluge.SelectedItem,
                    UplacenAvans = UCStavka.CheckBoxUplacenAvans.Checked,
                };


            }
            else
            {
                //StavkaEvidencije izabrana = Koordinator.Instance.IzmenjenaStavka; //menjamo je
                stavka = new StavkaEvidencije
                {
                    Rb = Koordinator.Instance.IzmenjenaStavka.Rb,
                    Evidencija = Koordinator.Instance.IzmenjenaStavka.Evidencija,
                    Korisnik = Koordinator.Instance.IzmenjenaStavka.Korisnik,

                    Dolazak = dolazak,
                    Odlazak = odlazak,
                    BrDana = odlazak.DayNumber - dolazak.DayNumber,

                    BrOsoba = (decimal)UCStavka.NumericBrOsoba.Value,
                    VrstaUsluge = (VrstaUsluge)UCStavka.CmbVrstaUsluge.SelectedItem,
                    UplacenAvans = UCStavka.CheckBoxUplacenAvans.Checked,
                };

            }
            if (!Validacija(stavka))
                return; //OSVEZII SVE VREDNOSTI STAVKI

            if(Koordinator.Instance.StavkaSledecegMeseca == null) //azuriraj iznose ako nema prelaska u sl mesec jer je to vec obradjeno za obe stavke
{
                stavka.Evidencija = Koordinator.Instance.Evidencija;
                stavka.IzracunajIznose();
            }

            Koordinator.Instance.Stavka = stavka;
            
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

        private bool Validacija(StavkaEvidencije stavka)
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
            if (stavka.Odlazak <= stavka.Dolazak)
            {
                MessageBox.Show(UCStavka, "Datum odlaska mora biti posle datuma dolaska!",
                    "UPOZORENJE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            

            //ukoliko rezervacija prelazi u sledeci mesec
            if (stavka.Odlazak.Month == Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month
                && stavka.Odlazak.Day != 1)    //ako je do prvog u narednom mesecu => pamtimo je samo u tekucem mesecu
            {                                                                       
                
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
                    //dodavanje stavke u obe evidencije i validacija njihovih datuma
                    Koordinator.Instance.EvidencijaSledecegMeseca = (EvidencijaRez)serverOdg.Result;

                    return DodajUObeEvidencije(stavka);
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
                            sledeca.Nova = true;
                            return DodajUObeEvidencije(stavka);
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

            //ako rez nije presla u naredni
            else
            {
                // ranije je prelazila, sada vise ne prelazi
                if (stavka.Equals(Koordinator.Instance.IzmenjenaStavka)
                    && Koordinator.Instance.IzmenjenaStavka.Odlazak.Month
                        == Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month
                    && Koordinator.Instance.IzmenjenaStavka.Odlazak.Day != 1)
                {
                    EvidencijaRez kriterijum = new EvidencijaRez
                    {
                        Vlasnik = Koordinator.Instance.UlogovaniVlasnik,
                        SmestajnaJedinica = Koordinator.Instance.Evidencija.SmestajnaJedinica,
                        Mesec = Koordinator.Instance.Evidencija.Mesec.AddMonths(1),
                        Validacija = true
                    };

                    Odgovor serverOdg = Communication.Instance.PretraziEvidencijaRez(kriterijum);

                    if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                    {
                        Koordinator.Instance.EvidencijaSledecegMeseca =
                            serverOdg.Result as EvidencijaRez;
                    }
                    else
                    {
                        MessageBox.Show(
                            UCStavka,
                            "Nije pronađena evidencija sledećeg meseca za brisanje stare rezervacije.",
                            "GREŠKA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return false;
                    }


                    // pronadji stavku u sledecoj evidenciji
                    foreach (StavkaEvidencije s in Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije)
                    {
                        bool istaStavka =
                            s.Dolazak == Koordinator.Instance.IzmenjenaStavka.Dolazak
                            && s.Odlazak == Koordinator.Instance.IzmenjenaStavka.Odlazak
                            && s.Korisnik.BrLicneKarte ==
                                Koordinator.Instance.IzmenjenaStavka.Korisnik.BrLicneKarte;

                        if (istaStavka)
                        {
                            s.StatusStavke = StatusStavke.OBRISANA;
                            Koordinator.Instance.StavkaSledecegMeseca = s;
                            break;
                        }
                    }
                }

                return proveraDatuma(stavka);
            }
            

        }

        private bool DodajUObeEvidencije(StavkaEvidencije stavka)     // pravi jednu stavku u tekucoj a jednu u sledecoj evidenciji 
                                                //obe evidencije imaju istu stavku 
        {

            if (stavka.Equals(Koordinator.Instance.IzmenjenaStavka) &&
                Koordinator.Instance.IzmenjenaStavka.Odlazak.Month
                    == Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month
                     && Koordinator.Instance.IzmenjenaStavka.Odlazak.Day != 1) //postoji kao stavka u narednom mesecu
            {
                
                foreach (StavkaEvidencije s in Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije)
                {
                    if (s.Dolazak == Koordinator.Instance.IzmenjenaStavka.Dolazak
                            && s.Odlazak == Koordinator.Instance.IzmenjenaStavka.Odlazak
                            && s.Korisnik.BrLicneKarte == Koordinator.Instance.IzmenjenaStavka.Korisnik.BrLicneKarte)
                    {
                        Koordinator.Instance.StavkaSledecegMeseca = s;
                        break;
                    }
                }
                if (Koordinator.Instance.StavkaSledecegMeseca.StatusStavke != StatusStavke.DODATA) //ako je lokalno dodata i jos nije sacuvana u bazi
                {
                    Koordinator.Instance.StavkaSledecegMeseca.StatusStavke =
                        StatusStavke.IZMENJENA;
                }

            }
           
            else //nova tekuca stavka ili izmenjena koja nije prelazila u naredni mesec a sada prelazi => stavka u sledecem mesecu je nova
            {
                Koordinator.Instance.StavkaSledecegMeseca = new StavkaEvidencije
                {
                    Evidencija = Koordinator.Instance.EvidencijaSledecegMeseca,
                    Korisnik = stavka.Korisnik,
                    Rb = Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije.Count,
                    StatusStavke = StatusStavke.DODATA,
                };
            }
            Koordinator.Instance.StavkaSledecegMeseca.Odlazak = stavka.Odlazak;
            Koordinator.Instance.StavkaSledecegMeseca.Dolazak = stavka.Dolazak;

            DateOnly prviDanSledecegMeseca = Koordinator.Instance.Evidencija.Mesec.AddMonths(1);

            // broj dana za tekuću evidenciju
            stavka.BrDana = prviDanSledecegMeseca.DayNumber - stavka.Dolazak.DayNumber;
            stavka.IzracunajIznose(); 

            // broj dana za sledeću evidenciju

            Koordinator.Instance.StavkaSledecegMeseca.BrDana =
                stavka.Odlazak.DayNumber - prviDanSledecegMeseca.DayNumber;

            Koordinator.Instance.StavkaSledecegMeseca.BrOsoba = stavka.BrOsoba;
            Koordinator.Instance.StavkaSledecegMeseca.VrstaUsluge = stavka.VrstaUsluge;
            Koordinator.Instance.StavkaSledecegMeseca.UplacenAvans = stavka.UplacenAvans;
            Koordinator.Instance.StavkaSledecegMeseca.IzracunajIznose();

            //provera i u tekucem i u sledecem mesecu
            if (!proveraDatuma(stavka))
                return false;

            if (!proveraDatuma(Koordinator.Instance.StavkaSledecegMeseca))
                return false;

            return true;

        }

        internal bool proveraDatuma(StavkaEvidencije s)
        {
            DateOnly noviDolazak = s.Dolazak;
            DateOnly noviOdlazak = s.Odlazak;

            foreach (StavkaEvidencije postojeca in s.Evidencija.StavkeEvidencije)
            {
                //nova => uporedjujemo datume svih stavki koje su vec u evidenciji rez
                //azurira izabranu => ne racunamo stare datume te stavke
                //evidencija sl meseca => uporedjuje datume svih vec postojecih stavki u toj evidenciji

                if (postojeca.StatusStavke == StatusStavke.OBRISANA)
                    continue;

                bool istaStavka =
                    postojeca.Rb == s.Rb
                    && postojeca.Evidencija.Id == s.Evidencija.Id;

                if (istaStavka)
                    continue;

                bool preklapaSe =
                    noviDolazak < postojeca.Odlazak && //novi početak je pre kraja stare rezervacije
                    noviOdlazak > postojeca.Dolazak;   //novi kraj je posle početka stare rezervacije
                                                       //samo ako su oba true => true

                if (preklapaSe)
                {
                    MessageBox.Show(
                        UCStavka,
                        $"Termin se preklapa sa postojećom rezervacijom " +
                        $"({postojeca.Dolazak:dd.MM.yyyy.} - {postojeca.Odlazak:dd.MM.yyyy.}).",
                        "UPOZORENJE",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
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
            //ako je vec kreirana nova evidencija
            if (Koordinator.Instance.EvidencijaSledecegMeseca != null
                    && Koordinator.Instance.EvidencijaSledecegMeseca.Nova)
            {
                EvidencijaRez zaBrisanje = new EvidencijaRez
                {
                    Id = Koordinator.Instance.EvidencijaSledecegMeseca.Id,
                    StavkeEvidencije = new List<StavkaEvidencije>()
                };

                Odgovor odg2 = Communication.Instance.ObrisiEvidencijaRez(zaBrisanje);

                if (odg2.ExceptionMessage != null)
                    throw new Exception(odg2.ExceptionMessage);
            }

            Koordinator.Instance.EvidencijaSledecegMeseca = null;
            
            //ako je izabrana vrati je na prethodne vrednosti
            if (Koordinator.Instance.Stavka != null && 
                Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                Koordinator.Instance.IzmenjenaStavka = null;
            }
            Koordinator.Instance.Stavka = null;
            Koordinator.Instance.StavkaSledecegMeseca = null;

            Koordinator.Instance.GlavnaFrmController.StavkeEvidencijeRez();
        }
    }

}

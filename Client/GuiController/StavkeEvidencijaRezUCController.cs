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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Forms;

namespace Client.GuiController
{
    public class StavkeEvidencijaRezUCController
    {
        private UCStavkeEvidencijaRez UCEvidencija;

        public StavkeEvidencijaRezUCController(UCStavkeEvidencijaRez UCStavkeEvidencijaRez)
        {
            this.UCEvidencija = UCStavkeEvidencijaRez;
            UCEvidencija.Dock = DockStyle.Fill;
        }

        internal void PopuniPodatke()
        {
            UCEvidencija.LblRezervacije.Text = $"Rezervacije {Koordinator.Instance.Evidencija.SmestajnaJedinica.Naziv}" +
                $" za period evidencije {(NazivMeseca)Koordinator.Instance.Evidencija.Mesec.Month} {Koordinator.Instance.Evidencija.Mesec.Year}. ";

            PopuniTabelu();
        }
        internal void PopuniTabelu()
        {

            UCEvidencija.DgvStavke.AutoGenerateColumns = false;        //ne pravi sam kolone
            UCEvidencija.DgvStavke.Columns.Clear();                     //reset
            UCEvidencija.DgvStavke.DataSource = null;

            // da ne bi svaki put kacili isti event
            UCEvidencija.DgvStavke.CellFormatting -= FormatirajTabelu;

            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dolazak",
                HeaderText = "Dolazak",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Width = 90
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "odlazak",
                HeaderText = "Odlazak",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                Width = 90
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ImePrezimeKorisnik",
                HeaderText = "Gost",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 190
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "vrstaUsluge",
                HeaderText = "Vrsta usluge",
                DataPropertyName = "VrstaUsluge",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 110
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "brojOsoba",
                HeaderText = "Broj usluga",
                DataPropertyName = "BrOsoba",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                MinimumWidth = 60,
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosAvansa",
                HeaderText = "Iznos avansa",
                DataPropertyName = "IznosAvansa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 100
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "uplacenAvans",
                DataPropertyName = "UplacenAvans",
                HeaderText = "Avans uplaćen"
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosRezervacije",
                HeaderText = "Iznos rezervacije",
                DataPropertyName = "IznosRezervacije",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 100
            });


            var sortirane = Koordinator.Instance.Evidencija.StavkeEvidencije
                            .Where(s => s.StatusStavke != StatusStavke.OBRISANA) //ne prikazuje ih u tabeli
                            .OrderBy(s => s.Dolazak)
                            .ThenBy(s => s.Odlazak)
                            .ToList();

            UCEvidencija.DgvStavke.DataSource = sortirane;

            UCEvidencija.DgvStavke.CellFormatting += FormatirajTabelu; //za vrednosti u tabeli koje nisu direktno iz klase SJ (iz obj TipSmestaja)


        }
        private void FormatirajTabelu(object? sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (UCEvidencija.DgvStavke.Rows[e.RowIndex].DataBoundItem is not StavkaEvidencije stavka)
                return;

            string columnName = UCEvidencija.DgvStavke.Columns[e.ColumnIndex].Name;

            bool zatvoreno = stavka.Korisnik?.Id == 60005;

            if (zatvoreno)
            {
                switch (columnName)
                {
                    case "ImePrezimeKorisnik":
                        e.Value = "Zatvoreno";
                        e.FormattingApplied = true;
                        return;

                    case "brojOsoba":
                    case "vrstaUsluge":
                    case "iznosAvansa":
                    case "uplacenAvans":
                    case "iznosRezervacije":
                        e.Value = "/";
                        e.FormattingApplied = true;
                        return;
                }
            }

            switch (columnName)
            {
                case "ImePrezimeKorisnik":
                    e.Value = $"{stavka.Korisnik?.Ime} {stavka.Korisnik?.Prezime}".Trim();
                    e.FormattingApplied = true;
                    break;

                case "iznosAvansa":
                    e.Value = stavka.IznosAvansa.ToString("N2") + " €";
                    e.FormattingApplied = true;
                    break;

                case "iznosRezervacije":
                    e.Value = stavka.IznosRezervacije.ToString("N2") + " €";
                    e.FormattingApplied = true;
                    break;

                case "dolazak":
                    e.Value = stavka.Dolazak.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                    break;

                case "odlazak":
                    e.Value = stavka.Odlazak.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                    break;
                case "uplacenAvans":
                    e.Value = stavka.UplacenAvans ? "Da" : "Ne";
                    e.FormattingApplied = true;
                    break;
            }
        }
        public void AzurirajTabelu()
        {
            var sortirane = Koordinator.Instance.Evidencija.StavkeEvidencije
                            .Where(s => s.StatusStavke != StatusStavke.OBRISANA) //ne prikazuje ih u tabeli
                            .OrderBy(s => s.Dolazak)
                            .ThenBy(s => s.Odlazak)
                            .ToList();

            UCEvidencija.DgvStavke.DataSource = null;
            UCEvidencija.DgvStavke.DataSource = sortirane;
        }

        internal void DodajStavkaEvidencije()
        {
            Koordinator.Instance.IzmenjenaStavka = null;

            Koordinator.Instance.Stavka = new StavkaEvidencije
            {
                Evidencija = Koordinator.Instance.Evidencija,
                //nova dobija rb najveceg postojeceg rb vezanog za tu evidenciju + 1 ili 0 ukoliko je to prva stavka 
                Rb = Koordinator.Instance.Evidencija.StavkeEvidencije.Any()? Koordinator.Instance.Evidencija.StavkeEvidencije.Max(s => s.Rb) + 1: 0,
                StatusStavke = StatusStavke.DODATA,
            };
            // Koordinator.Instance.OtvoriFrmStavkaEvidencije();
            Koordinator.Instance.GlavnaFrmController.PromeniStavkaEvidencijeRez();

        }
        internal void IzabranaStavka(int rowIndex)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Koordinator.Instance.Stavka = UCEvidencija.DgvStavke.Rows[rowIndex].DataBoundItem as StavkaEvidencije;

                //ako izabrana stavka pocinje u prethodnom mesecu ne moze se menjati ovde
                DateOnly mesecEvidencije = Koordinator.Instance.Evidencija.Mesec;
                StavkaEvidencije izabrana = Koordinator.Instance.Stavka;

                bool stavkaPocelaUPrethodnomMesecu =
                    izabrana.Dolazak.Year != mesecEvidencije.Year ||
                    izabrana.Dolazak.Month != mesecEvidencije.Month;

                if (stavkaPocelaUPrethodnomMesecu)
                {
                    MessageBox.Show(
                        UCEvidencija,
                        $"Ova rezervacija počinje {izabrana.Dolazak:dd.MM.yyyy.} " +
                        $"i pripada evidenciji za {izabrana.Dolazak:MM/yyyy}. " +
                        "Izmenu možete izvršiti samo preko evidencije meseca u kome rezervacija počinje.",
                        "Izmena nije dozvoljena",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Koordinator.Instance.Stavka = null;
                    return;
                }


                Koordinator.Instance.IzmenjenaStavka = new StavkaEvidencije //pamti podakte o izmeni
                {
                    Evidencija = Koordinator.Instance.Stavka.Evidencija,
                    Rb = Koordinator.Instance.Stavka.Rb,
                    Korisnik = Koordinator.Instance.Stavka.Korisnik,

                    Dolazak = Koordinator.Instance.Stavka.Dolazak,
                    Odlazak = Koordinator.Instance.Stavka.Odlazak,
                    BrDana = Koordinator.Instance.Stavka.BrDana,
                    BrOsoba = Koordinator.Instance.Stavka.BrOsoba,
                    VrstaUsluge = Koordinator.Instance.Stavka.VrstaUsluge,
                    UplacenAvans = Koordinator.Instance.Stavka.UplacenAvans
                };
            }
        }

        internal void ObrisiStavkaEvidencije()
        {
            if (Koordinator.Instance.IzmenjenaStavka == null)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Koordinator.Instance.Stavka.StatusStavke == StatusStavke.DODATA) //ako je nova i nije ni dodata u bazu
            {
                Koordinator.Instance.Evidencija.StavkeEvidencije.Remove(Koordinator.Instance.Stavka);
            }
            else
            {
                Koordinator.Instance.Stavka.StatusStavke = StatusStavke.OBRISANA;

                // ako rezervacija prelazi u sledeći mesec,
                // pronađi i njenu stavku u narednoj evidenciji
                if (Koordinator.Instance.Stavka.Odlazak.Month ==
                        Koordinator.Instance.Evidencija.Mesec.AddMonths(1).Month
                    && Koordinator.Instance.Stavka.Odlazak.Day != 1)
                {
                    Debug.WriteLine("REZERVACIJA PRELAZI U SLEDECI MESEC");
                    Debug.WriteLine($"Dolazak: {Koordinator.Instance.Stavka.Dolazak}");
                    Debug.WriteLine($"Odlazak: {Koordinator.Instance.Stavka.Odlazak}");
                    // ako sledeća evidencija nije učitana, učitaj je
                    if (Koordinator.Instance.EvidencijaSledecegMeseca == null)
                    {
                        EvidencijaRez kriterijum = new EvidencijaRez
                        {
                            Vlasnik = Koordinator.Instance.UlogovaniVlasnik,
                            SmestajnaJedinica = Koordinator.Instance.Evidencija.SmestajnaJedinica,
                            Mesec = Koordinator.Instance.Evidencija.Mesec.AddMonths(1),
                            Validacija = true
                        };

                        Odgovor odg = Communication.Instance.PretraziEvidencijaRez(kriterijum);

                        if (odg.ExceptionMessage == null && odg.Result != null)
                        {
                            Koordinator.Instance.EvidencijaSledecegMeseca =
                                (EvidencijaRez)odg.Result;
                            Debug.WriteLine("UCITANA NAREDNA EVIDENCIJA");
                            Debug.WriteLine($"Id evidencije: {Koordinator.Instance.EvidencijaSledecegMeseca.Id}");
                            Debug.WriteLine($"Broj stavki: {Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije.Count}");
                        }
                    }

                    // pronađi odgovarajuću stavku u sledećem mesecu
                    if (Koordinator.Instance.EvidencijaSledecegMeseca != null)
                    {
                        foreach (var s in Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije)
                        {
                            Debug.WriteLine(
                                $"PROVERAVAM: " +
                                $"{s.Dolazak:dd.MM.yyyy} - {s.Odlazak:dd.MM.yyyy} " +
                                $"Korisnik={s.Korisnik.Id}");
                            bool istaStavka =
                                s.Dolazak == Koordinator.Instance.Stavka.Dolazak
                                && s.Odlazak == Koordinator.Instance.Stavka.Odlazak
                                && s.Korisnik.Id == Koordinator.Instance.Stavka.Korisnik.Id;

                            if (istaStavka)
                            {
                                Debug.WriteLine("PRONASAO STAVKU ZA BRISANJE");
                                Debug.WriteLine($"istaStavka = {istaStavka}");
                                if (s.StatusStavke == StatusStavke.DODATA)
                                {
                                    Koordinator.Instance.EvidencijaSledecegMeseca
                                        .StavkeEvidencije.Remove(s);
                                }
                                else
                                {
                                    s.StatusStavke = StatusStavke.OBRISANA;
                                }

                                break;
                            }
                        }
                    }
                }
            }
            Koordinator.Instance.IzmenjenaStavka = null;
            Koordinator.Instance.Stavka = null;

            AzurirajTabelu();
        }

        internal void IzmeniStavkaEvidencije()
        {
            if (Koordinator.Instance.IzmenjenaStavka == null)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // zatvorene stavke se ne mogu menjati
            if (Koordinator.Instance.IzmenjenaStavka?.Korisnik?.Id == 60005)
            {
                MessageBox.Show(UCEvidencija, "Ova stavka je označena kao zatvorena i ne može se menjati.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Koordinator.Instance.Stavka = Koordinator.Instance.IzabranaStavka;
            //Koordinator.Instance.OtvoriFrmStavkaEvidencije();
            Koordinator.Instance.GlavnaFrmController.PromeniStavkaEvidencijeRez();
        }

        internal void PromeniEvidencijaRez(EvidencijaRez evidencija)
        {
            Koordinator.Instance.IzmenjenaStavka = null;
            //sada svaka stavka evidencije u sebi cuva i evidenciju (koristilo se za obracune iznosa dok se ne posalje u bazu)
            //kada je saljemo ka serveru preko JSON-a, ucitavace evidenciju pa njenu stavku pa u okviru stavke opet evidenciju i njene stavke i nastaje ciklicna referenca, javlja se greska
            //zato pre nego sto posaljemo serveru postavimo samo idEvidencije i praznu listu stavki u evidenciji
            foreach (var s in evidencija.StavkeEvidencije)
            {
                s.Evidencija = new EvidencijaRez
                {
                    Id = evidencija.Id,
                    StavkeEvidencije = new List<StavkaEvidencije>()
                }; //server ce u SO dodeliti pravu vrednost za evidenciju a ovde prekidamo ciklicnu referencu i zadrzavamo id
            }
            Odgovor serverOdg = Communication.Instance.PromeniEvidencijaRez(evidencija);
            if (serverOdg == null || serverOdg.ExceptionMessage != null)
            {
                MessageBox.Show(UCEvidencija, "Sistem ne može da zapamti evidenciju/e rezervacija.", "GREŠKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!evidencija.Equals(Koordinator.Instance.EvidencijaSledecegMeseca) &&
                    Koordinator.Instance.Evidencija.Nova) //ako je kreirana a nije uspesno zapamcena obrisi je
                {

                    Odgovor odg = Communication.Instance.ObrisiEvidencijaRez(evidencija);

                    if (odg.ExceptionMessage != null)
                        throw new Exception(odg.ExceptionMessage);

                    //obrisi i sledecu ako je kreirana u ovoj operaciji
                    if (Koordinator.Instance.EvidencijaSledecegMeseca != null
                        && Koordinator.Instance.EvidencijaSledecegMeseca.Nova)
                    {
                        EvidencijaRez zaBrisanje = new EvidencijaRez
                        {
                            Id = Koordinator.Instance.EvidencijaSledecegMeseca.Id,
                            StavkeEvidencije = new List<StavkaEvidencije>()
                        };

                        Odgovor odg2 =
                            Communication.Instance.ObrisiEvidencijaRez(zaBrisanje);

                        if (odg2.ExceptionMessage != null)
                            throw new Exception(odg2.ExceptionMessage);


                    }

                    Koordinator.Instance.EvidencijaSledecegMeseca = null;
                
                }
            }
            else
            {
                Koordinator.Instance.PrikazEvidencijaRezController.AzurirajTabelu();

                if (!evidencija.Equals(Koordinator.Instance.EvidencijaSledecegMeseca) &&
                    !Koordinator.Instance.Evidencija.Nova)
                    Koordinator.Instance.IzabranaEvidencijaRezController.AzurirajTabelu();

                if (!evidencija.Equals(Koordinator.Instance.EvidencijaSledecegMeseca) &&
                    Koordinator.Instance.EvidencijaSledecegMeseca != null)
                {
                    Debug.WriteLine("SALJEM NAREDNU EVIDENCIJU");
                    Debug.WriteLine($"Id = {Koordinator.Instance.EvidencijaSledecegMeseca.Id}");

                    foreach (var s in Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije)
                    {
                        Debug.WriteLine(
                            $"Rb={s.Rb} " +
                            $"Status={s.StatusStavke} " +
                            $"{s.Dolazak}-{s.Odlazak}");
                    }
                    PromeniEvidencijaRez(Koordinator.Instance.EvidencijaSledecegMeseca);

                    
                }
                else
                {
                    Debug.WriteLine(evidencija.Id);
                    Debug.WriteLine(Koordinator.Instance.EvidencijaSledecegMeseca?.Id);
                    
                    if (evidencija.Equals(Koordinator.Instance.EvidencijaSledecegMeseca) ||
                        Koordinator.Instance.EvidencijaSledecegMeseca==null)
                    {
                        string poruka = KreirajPorukuZaGosteBezEmaila(evidencija);
                        Debug.WriteLine(poruka);
                        using (var frm = new FrmLongMessage("USPEŠNO", poruka))
                        {
                            var owner = UCEvidencija.FindForm();
                            if (owner != null)
                                frm.ShowDialog(owner);
                            else
                                frm.ShowDialog();
                        }

                        Koordinator.Instance.Evidencija = null;
                        Koordinator.Instance.EvidencijaSledecegMeseca = null;
                    }
                    
                    Koordinator.Instance.GlavnaFrmController.PrikaziEvidencije(true);
                }

            }
           
        }
        private string KreirajPorukuZaGosteBezEmaila(EvidencijaRez evidencija)
        {
            String poruka = "Sistem je zapamtio evidenciju/e rezervacija. ";

            var stavkeBezEmaila = evidencija.StavkeEvidencije
                .Where(s =>
                    string.IsNullOrWhiteSpace(s.Korisnik?.Email)
                    &&
                    (
                        s.StatusStavke == StatusStavke.DODATA ||
                        s.StatusStavke == StatusStavke.IZMENJENA ||
                        s.StatusStavke == StatusStavke.OBRISANA
                    ))
                .ToList();

            foreach (var s in stavkeBezEmaila)
            {
                if (s?.Korisnik?.Id == 60005)
                {
                    continue; //ne prikazuje se za zatvorene stavke
                }
                string obavestenje = s.StatusStavke switch
                {
                    StatusStavke.DODATA => "potvrdi rezervacije",
                    StatusStavke.IZMENJENA => "izmeni rezervacije",
                    StatusStavke.OBRISANA => "otkazivanju rezervacije",
                    _ => "rezervaciji"
                };

                string ime = s.Korisnik?.Ime ?? "<Ime>";
                string prezime = s.Korisnik?.Prezime ?? string.Empty;
                string brTel = s.Korisnik?.BrTel ?? "n/a";

                poruka += Environment.NewLine + $"- Korisnik {ime} {prezime} nema unetu email adresu. " +
                    $"Obavestite ga na broj telefona {brTel} o {obavestenje}.";
            }

            return poruka;
        }

        internal bool ZaboraviIzmene() //ako ne sacuva u bazi evidenciju
        {
            DialogResult rezultat = MessageBox.Show(
                "Niste sačuvali evidenciju.\nDa li želite da zatvorite formu?",
                "Upozorenje",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (rezultat == DialogResult.No)
                return false;

            try
            {
                if (Koordinator.Instance.Evidencija != null &&
                    Koordinator.Instance.Evidencija.Nova)
                {
                    EvidencijaRez zaBrisanje = new EvidencijaRez
                    {
                        Id = Koordinator.Instance.Evidencija.Id,
                        StavkeEvidencije = new List<StavkaEvidencije>()
                    };

                    Odgovor odg = Communication.Instance.ObrisiEvidencijaRez(zaBrisanje);

                    if (odg.ExceptionMessage != null)
                        throw new Exception(odg.ExceptionMessage);
                }

                if (Koordinator.Instance.EvidencijaSledecegMeseca != null &&
                    Koordinator.Instance.EvidencijaSledecegMeseca.Nova)
                {
                    EvidencijaRez zaBrisanjeSl = new EvidencijaRez
                    {
                        Id = Koordinator.Instance.EvidencijaSledecegMeseca.Id,
                        StavkeEvidencije = new List<StavkaEvidencije>()
                    };

                    Odgovor odg2 = Communication.Instance.ObrisiEvidencijaRez(zaBrisanjeSl);

                    if (odg2.ExceptionMessage != null)
                        throw new Exception(odg2.ExceptionMessage);
                }

                Koordinator.Instance.Evidencija = null;
                Koordinator.Instance.EvidencijaSledecegMeseca = null;
                Koordinator.Instance.Stavka = null;
                Koordinator.Instance.IzmenjenaStavka = null;
                Koordinator.Instance.StavkaSledecegMeseca = null;

                return true;
            }
            catch
            {
                MessageBox.Show(
                    "Sistem ne može da obriše evidenciju iz baze.",
                    "Greška",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }
    }
}

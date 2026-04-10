using Client.Model;
using Client.Session;
using Client.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class StavkeEvidencijaRezUCController
    {
        private UCStavkeEvidencijaRez UCEvidencija;

        public StavkeEvidencijaRezUCController(UCStavkeEvidencijaRez UCStavkeEvidencijaRez)
        {
            this.UCEvidencija = UCStavkeEvidencijaRez;
        }

        internal void PopuniPodatke()
        {
            UCEvidencija.LblRezervacije.Text = $"Rezervacije {Koordinator.Instance.IzmenjenaEvidencija.SmestajnaJedinica.Naziv}" +
                $" \n za period evidencije {(NazivMeseca)Koordinator.Instance.IzmenjenaEvidencija.Mesec.Month} {Koordinator.Instance.IzmenjenaEvidencija.Mesec.Year}. ";

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
                HeaderText = "Dan dolaska",
                DataPropertyName = "DanDolaska",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 90
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "odlazak",
                HeaderText = "Dan odlaska",
                DataPropertyName = "DanOdlaska",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
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
                HeaderText = "Broj osoba",
                DataPropertyName = "BrOsoba",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                MinimumWidth = 60,
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
                Name = "iznosAvansa",
                HeaderText = "Iznos avansa",
                DataPropertyName = "IznosAvansa",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 100
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "UplacenAvans",
                HeaderText = "Avans uplacen"
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosRezervacije",
                HeaderText = "Iznos rezervacije",
                DataPropertyName = "IznosRezervacije",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 100
            });

            var sortirane = Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije
                            .OrderBy(s => s.DanDolaska)
                            .ThenBy(s => s.DanOdlaska)
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
                    e.Value = stavka.DanDolaska.ToString() + ".";
                    e.FormattingApplied = true;
                    break;

                case "odlazak":
                    e.Value = stavka.DanOdlaska.ToString() + ".";
                    e.FormattingApplied = true;
                    break;
            }
        }
        public void AzurirajTabelu()
        {
            var sortirane = Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije
                        .OrderBy(s => s.DanDolaska)
                        .ThenBy(s => s.DanOdlaska)
                        .ToList();

            UCEvidencija.DgvStavke.DataSource = null;
            UCEvidencija.DgvStavke.DataSource = sortirane;
        }

        internal void IzabranaStavka(int rowIndex)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Koordinator.Instance.IzabranaStavka = UCEvidencija.DgvStavke.Rows[rowIndex].DataBoundItem as StavkaEvidencije;
            }
        }

        internal void ObrisiStavkaEvidencije()
        {
            if (Koordinator.Instance.IzabranaStavka == null)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije.Remove(Koordinator.Instance.IzabranaStavka);
            AzurirajTabelu();
        }

        internal void IzmeniStavkaEvidencije()
        {
            if (Koordinator.Instance.IzabranaStavka == null)
            {
                MessageBox.Show(UCEvidencija, "Morate izabrati rezervaciju.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Koordinator.Instance.OtvoriFrmStavkaEvidencije(Koordinator.Instance.IzabranaStavka);
        }

        internal void PromeniEvidencijaRez()
        {
            //sada svaka stavka evidencije u sebi cuva i evidenciju (koristilo se za obracune iznosa dok se ne posalje u bazu)
            //kada je saljemo ka serveru preko JSON-a, ucitavace evidenciju pa njenu stavku pa u okviru stavke opet evidenciju i njene stavke i nastaje ciklicna referenca, javlja se greska
            //zato pre nego sto posaljemo serveru postavimo samo idEvidencije i praznu listu stavki u evidenciji
            foreach (var s in Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije)
            {
                s.Evidencija = new EvidencijaRez
                {
                    Id = Koordinator.Instance.IzmenjenaEvidencija.Id,
                    StavkeEvidencije = new List<StavkaEvidencije>()
                }; //server ce u SO dodeliti pravu vrednost za evidenciju a ovde prekinamo ciklicnu referencu i zadrzavamo id
            }
            Odgovor serverOdg = Communication.Instance.PromeniEvidencijaRez(Koordinator.Instance.IzmenjenaEvidencija);
            if(serverOdg == null || serverOdg.ExceptionMessage != null )
            {
                MessageBox.Show(UCEvidencija, "Sistem ne moze da zapamti evidenciju rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.KreiranaEvidencija)) //ako je kreirana a nije uspesno zapamcena obrisi je
                {
                    Koordinator.Instance.PromeniEvidencijaRezFrmController.ObrisiEvidenciju();
                }
            }
            else
            {
                Koordinator.Instance.PrikazEvidencijaRezController.AzurirajTabelu();

                if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.IzabranaEvidencija))
                    Koordinator.Instance.IzabranaEvidencijaRezController.AzurirajTabelu();

                MessageBox.Show(UCEvidencija, "Sistem je zapamtio evidenciju rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.KreiranaEvidencija))
                Koordinator.Instance.KreiranaEvidencija = null;
            else
                Koordinator.Instance.IzabranaEvidencija = null;

            Koordinator.Instance.IzmenjenaEvidencija = null;
            Koordinator.Instance.PromeniEvidencijaRezFrmController.ZatvoriFormu();
        }
    }
}

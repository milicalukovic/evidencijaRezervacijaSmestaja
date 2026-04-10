using Client.Model;
using Client.Session;
using Client.UserControls;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class IzabranaEvidencijaRezController
    {
        private UCIzabranaEvidencijaRez UCEvidencija;

        public IzabranaEvidencijaRezController(UCIzabranaEvidencijaRez UCIzabranaEvidencijaRez)
        {
            this.UCEvidencija = UCIzabranaEvidencijaRez;
        }

        internal void PopuniPodatke()
        {
            EvidencijaRez izabrana = Koordinator.Instance.IzabranaEvidencija;

            UCEvidencija.TxtSmestajnaJedinica.Text = izabrana.SmestajnaJedinica.Naziv;
            UCEvidencija.TxtMesec.Text = $"{(NazivMeseca)izabrana.Mesec.Month} {izabrana.Mesec.Year}.";
            UCEvidencija.TxtUkupanIznos.Text = izabrana.UkupanIznos.ToString("N2");

            UCEvidencija.TxtSmestajnaJedinica.ReadOnly = true;
            UCEvidencija.TxtMesec.ReadOnly = true;
            UCEvidencija.TxtUkupanIznos.ReadOnly = true;

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
                DataPropertyName = "DanDolaska",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 100
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "odlazak",
                HeaderText = "Odlazak",
                DataPropertyName = "DanOdlaska",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 100
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
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 115
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "uplacenAvans",
                HeaderText = "Avans uplacen",
                DataPropertyName = "UplacenAvans",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            }); 
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosRezervacije",
                HeaderText = "Iznos rezervacije",
                DataPropertyName = "IznosRezervacije",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 115
            });

            var sortirane = Koordinator.Instance.IzabranaEvidencija.StavkeEvidencije
                            .OrderBy(s => s.DanDolaska)
                            .ThenBy(s=> s.DanOdlaska)
                            .ToList();
          
            UCEvidencija.DgvStavke.DataSource = sortirane;
            UCEvidencija.DgvStavke.AutoResizeColumns();

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
                   
                case "iznosRezervacije":
                    if (e.Value != null)
                    {
                        e.Value = ((decimal)e.Value).ToString("N2")+" €";
                        e.FormattingApplied = true;
                    }
                    break;

                case "uplacenAvans":
                    e.Value = stavka.UplacenAvans ? "Da" : "Ne";
                    e.FormattingApplied = true;
                    break;

                case "dolazak":
                    e.Value = stavka.DanDolaska.ToString() + "/"+ Koordinator.Instance.IzabranaEvidencija.Mesec.ToString("MM/yyyy", CultureInfo.InvariantCulture); ;
                    e.FormattingApplied = true;
                    break;

                case "odlazak":
                    e.Value = stavka.DanOdlaska.ToString() + "/"+ Koordinator.Instance.IzabranaEvidencija.Mesec.ToString("MM/yyyy", CultureInfo.InvariantCulture); ;
                    e.FormattingApplied = true;
                    break;

            }
        }

        internal void PromeniEvidencijaRez()
        {
            Koordinator.Instance.OtvoriFrmPromeniEvidencijaRez(Koordinator.Instance.IzabranaEvidencija);
        }

        internal void AzurirajTabelu()
        {
            var sortirane = Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije
                        .OrderBy(s => s.DanDolaska)
                        .ThenBy(s => s.DanOdlaska)
                        .ToList();

            UCEvidencija.DgvStavke.DataSource = null;
            UCEvidencija.DgvStavke.DataSource = sortirane;
        }
    }
}

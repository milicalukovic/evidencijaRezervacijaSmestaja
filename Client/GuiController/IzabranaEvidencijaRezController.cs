using Client.Forms;
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
            EvidencijaRez izabrana = Koordinator.Instance.Evidencija;

            UCEvidencija.TxtSmestajnaJedinica.Text = izabrana.SmestajnaJedinica.Naziv;
            UCEvidencija.TxtMesec.Text = $"{(NazivMeseca)izabrana.Mesec.Month} {izabrana.Mesec.Year}.";
            UCEvidencija.TxtUkupanIznos.Text = izabrana.UkupanIznos.ToString("N2") + " €";

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

            UCEvidencija.DgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UCEvidencija.DgvStavke.AllowUserToResizeColumns = true;
            UCEvidencija.DgvStavke.RowHeadersWidth = 25;

            // da ne bi svaki put kacili isti event
            UCEvidencija.DgvStavke.CellFormatting -= FormatirajTabelu;

            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "dolazak",
                HeaderText = "Dolazak",
                DataPropertyName = "Dolazak",
                FillWeight = 95,
                MinimumWidth = 95
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "odlazak",
                HeaderText = "Odlazak",
                DataPropertyName = "Odlazak",
                FillWeight = 95,
                MinimumWidth = 95
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ImePrezimeKorisnik",
                HeaderText = "Gost",
                FillWeight = 170,
                MinimumWidth = 160
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Broj osoba",
                DataPropertyName = "BrOsoba",
                FillWeight = 75,
                MinimumWidth = 70
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "vrstaUsluge",
                HeaderText = "Vrsta usluge",
                DataPropertyName = "VrstaUsluge",
                FillWeight = 160,
                MinimumWidth = 150
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosAvansa",
                HeaderText = "Iznos avansa",
                DataPropertyName = "IznosAvansa",
                FillWeight = 110,
                MinimumWidth = 110
            });
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "uplacenAvans",
                HeaderText = "Avans uplacen",
                DataPropertyName = "UplacenAvans",
                FillWeight = 90,
                MinimumWidth = 90
            }); 
            UCEvidencija.DgvStavke.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "iznosRezervacije",
                HeaderText = "Iznos rezervacije",
                DataPropertyName = "IznosRezervacije",
                FillWeight = 140,
                MinimumWidth = 135
            });

            var sortirane = Koordinator.Instance.Evidencija.StavkeEvidencije
                            .OrderBy(s => s.Dolazak)
                            .ThenBy(s=> s.Odlazak)
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
                    e.Value = stavka.Dolazak.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                    break;

                case "odlazak":
                    e.Value = stavka.Odlazak.ToString("dd.MM.yyyy");
                    e.FormattingApplied = true;
                    break;

            }
        }

        internal void PromeniEvidencijaRez()
        {
            //Koordinator.Instance.OtvoriFrmPromeniEvidencijaRez(Koordinator.Instance.Evidencija);
            Koordinator.Instance.GlavnaFrmController.PromeniEvidencijaRez(Koordinator.Instance.Evidencija);
        }

        internal void AzurirajTabelu()
        {
            var sortirane = Koordinator.Instance.Evidencija.StavkeEvidencije
                        .OrderBy(s => s.Dolazak)
                        .ThenBy(s => s.Odlazak)
                        .ToList();

            UCEvidencija.DgvStavke.DataSource = null;
            UCEvidencija.DgvStavke.DataSource = sortirane;
        }
    }
}

using Client.Forms;
using Client.Model;
using Client.Session;
using Client.UserControls;
using Common.Communication;
using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class PrikazEvidencijaRezController
    {
        private UCPrikazEvidencijaRez UCPrikaz;

        public PrikazEvidencijaRezController(UCPrikazEvidencijaRez UCPrikazEvidencijaRez)
        {
            this.UCPrikaz = UCPrikazEvidencijaRez;
        }

        internal void PopuniPodatke()
        {
            PopuniTabelu();
        }
        internal void PopuniTabelu()
        {

            UCPrikaz.DgvEvidencije.AutoGenerateColumns = false;        //ne pravi sam kolone
            UCPrikaz.DgvEvidencije.Columns.Clear();                     //reset
            UCPrikaz.DgvEvidencije.DataSource = null;

            // da ne bi svaki put kacili isti event
            UCPrikaz.DgvEvidencije.CellFormatting -= FormatirajTabelu;

            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "mesec",
                HeaderText = "Period evidencije",                                            //naslov
                DataPropertyName = "Mesec",                                      //vrednost uzima iz tog atributa objekta
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,              //zauzme sav preostali prostor
            });
            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nazivSmestaj",
                HeaderText = "Smestajna jedinica",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, //zauzme tacno mesta koliko joj je potrebno
            });
            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "osnovnaVrstaUsluge",
                HeaderText = "Osnovna usluga",
                DataPropertyName = "OsnovnaVrstaUsluge",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });
            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cena osnovne usluge po osoobi",
                Name = "cenaOsnovneUsluge",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });
            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Broj rezervacija",
                Name = "brojRezervacija",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, 
            });
            UCPrikaz.DgvEvidencije.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ukupanIznos",
                HeaderText = "Ukupan iznos",
                DataPropertyName = "UkupanIznos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });

            
            UCPrikaz.DgvEvidencije.DataSource = AzurirajEvidencijeRezervacija() ?? new List<EvidencijaRez>();

            UCPrikaz.DgvEvidencije.CellFormatting += FormatirajTabelu; //za vrednosti u tabeli koje nisu direktno iz klase SJ (iz obj TipSmestaja)


        }
        private void FormatirajTabelu(object? sender, DataGridViewCellFormattingEventArgs e)  //prilagodi podatke modela 
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (UCPrikaz.DgvEvidencije.Rows[e.RowIndex].DataBoundItem is not EvidencijaRez evidencija)
                return;

            string columnName = UCPrikaz.DgvEvidencije.Columns[e.ColumnIndex].Name;

            switch (columnName)
            {
                case "mesec":
                    e.Value = $"{(NazivMeseca)evidencija.Mesec.Month} {evidencija.Mesec.Year}.";
                    e.FormattingApplied = true;
                    break;

                case "nazivSmestaj":
                    e.Value = evidencija.SmestajnaJedinica?.Naziv ?? "";
                    e.FormattingApplied = true;
                    break;

                case "osnovnaVrstaUsluge":
                    e.Value = evidencija.OsnovnaVrstaUsluge.ToString();
                    e.FormattingApplied = true;
                    break;

                case "cenaOsnovneUsluge":
                    decimal cenaOsnovneUsluge = evidencija.OsnovnaCenaPoOsobi * evidencija.SezonskiKoeficijentCene;
                    e.Value = cenaOsnovneUsluge.ToString("0.00", CultureInfo.InvariantCulture) + " €";
                    e.FormattingApplied = true;
                    break;

                case "brojRezervacija":
                    e.Value = (evidencija.StavkeEvidencije?.Count ?? 0).ToString();
                    e.FormattingApplied = true;
                    break;

                case "ukupanIznos":
                    decimal ukupanIznos = evidencija.UkupanIznos;
                    e.Value = ukupanIznos.ToString("0.00", CultureInfo.InvariantCulture) + " €";
                    e.FormattingApplied = true;
                    break;
            }

        }
        private List<EvidencijaRez> AzurirajEvidencijeRezervacija()
        {
            List<EvidencijaRez> lista = new List<EvidencijaRez>();
            EvidencijaRez evidencija = new EvidencijaRez();
            evidencija.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;

            Odgovor serverOdg = Communication.Instance.VratiListuEvidencijaRez(evidencija);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                lista = (List<EvidencijaRez>)serverOdg.Result;
                Koordinator.Instance.ListaEvidencijaRezervacija = lista;
            }
            return lista;
        }
        internal void AzurirajTabelu()
        {
            UCPrikaz.DgvEvidencije.DataSource = null;
            UCPrikaz.DgvEvidencije.DataSource = AzurirajEvidencijeRezervacija();

        }

        internal void UnesiKriterijumPretgrage()
        {
            if (Koordinator.Instance.ListaEvidencijaRezervacija.IsNullOrEmpty())
            {
                MessageBox.Show(UCPrikaz, "Jos uvek nemate kreirane evidencije rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Koordinator.Instance.OtvoriFrmKriterijumPretrageEvidencijaRez();
        }
        internal void PretraziEvidencijeRezPoKriterijumima(List<EvidencijaRez> lista)
        {
            UCPrikaz.DgvEvidencije.DataSource = null;
            UCPrikaz.DgvEvidencije.DataSource = lista;
            MessageBox.Show(UCPrikaz, "Sistem je nasao evidencije rezervacija po zadatim kriterijumima.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void PretraziEvidencijaRez(int rowIndex) //postavi kao izabranu
        {
            if (rowIndex < 0)
            {
                MessageBox.Show(UCPrikaz, "Morate izabrati evidenciju rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Koordinator.Instance.IzabranaEvidencija = UCPrikaz.DgvEvidencije.Rows[rowIndex].DataBoundItem as EvidencijaRez;

                EvidencijaRez izabrana = Koordinator.Instance.IzabranaEvidencija;
                Debug.WriteLine("WHERE: " + izabrana.WhereClause);

                if (izabrana != null)
                { 
                    Odgovor serverOdg = Communication.Instance.PretraziEvidencijaRez(izabrana);
                    if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                    {
                        MessageBox.Show(UCPrikaz, "Sistem je nasao evidenciju rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Koordinator.Instance.GlavnaFrmController.IzabranaEvidencijaRez();
                    }
                    else
                    {
                        MessageBox.Show(UCPrikaz, "Sistem ne moze da nadje evidenciju rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Koordinator.Instance.IzabranaEvidencija = null;
                    }
                }
            }
        }
    }
}

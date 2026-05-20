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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Client.GuiController
{
    public class OsnovniPodaciEvidencijaRezController
    {
        private UCOsnovniPodaciEvidencijaRez UCEvidencija;

        public OsnovniPodaciEvidencijaRezController(UCOsnovniPodaciEvidencijaRez UCOsnovniPodaciEvidencijaRez)
        {
            this.UCEvidencija = UCOsnovniPodaciEvidencijaRez;
        }

        internal void PopuniPodatke(EvidencijaRez e)
        {
            PopuniSmestajnaJedinica();
            Popuni_Txt_Cmb_Mesec();

            if (!e.Nova) //izmena
            {
                //postavi vrednosti izabrane evidencije
                UCEvidencija.CmbMesec.SelectedItem = (NazivMeseca)e.Mesec.Month;
                UCEvidencija.NumericGodina.Value = e.Mesec.Year;
                UCEvidencija.NumericProcenatAvansa.Value = e.ProcenatAvansa;
                UCEvidencija.NumericSezonskiKoefCene.Value = e.SezonskiKoeficijentCene;

                UCEvidencija.CmbMesec.Enabled = false;
                UCEvidencija.NumericGodina.ReadOnly = true;
                UCEvidencija.NumericGodina.Enabled = false;
                UCEvidencija.CmbSmestajnaJedinica.Enabled = false;

                UCEvidencija.CmbSmestajnaJedinica.SelectedItem = e.SmestajnaJedinica;
                //ucita vrednosti u trenutku kreiranja evidencije
                UCEvidencija.TxtOsnovnaVrstaUsluge.Text = e.OsnovnaVrstaUsluge.ToString();
                UCEvidencija.TxtOsnovnaCenaPoOsobi.Text = e.OsnovnaCenaPoOsobi.ToString();
                UCEvidencija.TxtPovecanjeCenePoUsluzi.Text = e.PovecanjeCenePoUsluzi.ToString();
                UCEvidencija.TxtTipSmestaja.Text = e.SmestajnaJedinica.Tip.Naziv;
                UCEvidencija.TxtMinKapacitet.Text = e.SmestajnaJedinica.Tip.MinKapacitet.ToString();
                UCEvidencija.TxtMaxKapacitet.Text = e.SmestajnaJedinica.Tip.MaxKapacitet.ToString();
            }
            else                                             //nova - ucita joj trenutne sj
            {
                //Koordinator.Instance.Evidencija = Koordinator.Instance.KreiranaEvidencija;
                PromeniCMBSmestajnaJedinica(Koordinator.Instance.ListaSmestajnaJedinica.FirstOrDefault());
            }

        }
        private void PopuniSmestajnaJedinica()
        {
            //cmb
            UCEvidencija.CmbSmestajnaJedinica.DataSource = Koordinator.Instance.ListaSmestajnaJedinica;
            UCEvidencija.CmbSmestajnaJedinica.DisplayMember = "Naziv";
            UCEvidencija.CmbSmestajnaJedinica.Visible = true;

            //smestajna jedinica
            
            UCEvidencija.TxtOsnovnaVrstaUsluge.ReadOnly = true;
            UCEvidencija.TxtOsnovnaCenaPoOsobi.ReadOnly = true;
            UCEvidencija.TxtPovecanjeCenePoUsluzi.ReadOnly = true;
            UCEvidencija.TxtTipSmestaja.ReadOnly = true;
            UCEvidencija.TxtMinKapacitet.ReadOnly = true;
            UCEvidencija.TxtMaxKapacitet.ReadOnly = true;
            
        }

        internal void PromeniCMBSmestajnaJedinica(SmestajnaJedinica sj)
        {

            UCEvidencija.CmbSmestajnaJedinica.SelectedItem = sj;

            UCEvidencija.TxtOsnovnaVrstaUsluge.Text = sj.OsnovnaVrstaUsluge.ToString();
            UCEvidencija.TxtOsnovnaCenaPoOsobi.Text = sj.CenaPoOsobi.ToString();
            UCEvidencija.TxtPovecanjeCenePoUsluzi.Text = sj.PovecanjeCenePoUsluzi.ToString();
            UCEvidencija.TxtTipSmestaja.Text = sj.Tip.Naziv;
            UCEvidencija.TxtMinKapacitet.Text = sj.Tip.MinKapacitet.ToString();
            UCEvidencija.TxtMaxKapacitet.Text = sj.Tip.MaxKapacitet.ToString();
            
        }

        private void Popuni_Txt_Cmb_Mesec()
        {

            UCEvidencija.CmbMesec.DataSource = Enum.GetValues(typeof(NazivMeseca));

            UCEvidencija.CmbMesec.Format += (s, ev) =>
            {
                ev.Value = ev.ListItem.ToString();
            };
            
        }
        internal void ZapamtiPodatke()
        {
            if (!Validacija())
                return;

            EvidencijaRez izmenjena = Koordinator.Instance.Evidencija;

            if (izmenjena.Nova) //promeni novu kreiranu
            {
                
                izmenjena.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                izmenjena.SmestajnaJedinica = UCEvidencija.CmbSmestajnaJedinica.SelectedItem as SmestajnaJedinica;
                izmenjena.OsnovnaCenaPoOsobi = izmenjena.SmestajnaJedinica.CenaPoOsobi;
                izmenjena.OsnovnaVrstaUsluge = izmenjena.SmestajnaJedinica.OsnovnaVrstaUsluge;
                izmenjena.PovecanjeCenePoUsluzi = izmenjena.SmestajnaJedinica.PovecanjeCenePoUsluzi;
                int mesec = (int)(NazivMeseca)UCEvidencija.CmbMesec.SelectedItem;
                int godina = (int)UCEvidencija.NumericGodina.Value;
                izmenjena.Mesec = new DateOnly(godina, mesec, 1);
                izmenjena.StavkeEvidencije = new List<StavkaEvidencije>();

                izmenjena.ProcenatAvansa = (decimal)UCEvidencija.NumericProcenatAvansa.Value;
                izmenjena.SezonskiKoeficijentCene = (decimal)UCEvidencija.NumericSezonskiKoefCene.Value;

            } else//izmena
            {
                
                izmenjena.ProcenatAvansa = (decimal)UCEvidencija.NumericProcenatAvansa.Value;
                izmenjena.SezonskiKoeficijentCene = (decimal)UCEvidencija.NumericSezonskiKoefCene.Value;

                //azurira iznose postojecih stavki
                foreach (StavkaEvidencije s in izmenjena.StavkeEvidencije)
                {
                    s.Evidencija = izmenjena;
                    s.IzracunajIznose();

                    if (s.StatusStavke != StatusStavke.DODATA)
                    {
                        s.StatusStavke = StatusStavke.IZMENJENA; //ako je vec postojala u bazi mora se izmeniti
                    }
                }

            }
            //otvori stavke
            //Koordinator.Instance.PromeniEvidencijaRezFrmController.StavkeEvidencijeRez();
            Koordinator.Instance.GlavnaFrmController.StavkeEvidencijeRez();
        }
        private bool Validacija()
        {
            if (//UCEvidencija.NumericMesec.Value == 0 ||
                UCEvidencija.NumericProcenatAvansa.Value == 0
                )
            {
                MessageBox.Show(UCEvidencija, "Morate popuniti sve podatke.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //ako vec postoji evidencija za tu smestajnu jedinicu, mesec i vlasnika
            if (Koordinator.Instance.Evidencija.Nova)
            {
                EvidencijaRez evidencija = new EvidencijaRez();

                evidencija.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                evidencija.SmestajnaJedinica = UCEvidencija.CmbSmestajnaJedinica.SelectedItem as SmestajnaJedinica;
                int mesec = (int)(NazivMeseca)UCEvidencija.CmbMesec.SelectedItem;
                int godina = (int)UCEvidencija.NumericGodina.Value;
                evidencija.Mesec = new DateOnly(godina, mesec, 1); //za bazu

                evidencija.Validacija = true;
                Debug.WriteLine("WHERE: " + evidencija.WhereClause);

                //pretrazi obj
                Odgovor serverOdg = Communication.Instance.PretraziEvidencijaRez(evidencija);

                evidencija.Validacija = false;

                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    MessageBox.Show(UCEvidencija, "Vec postoji evidencija rezervacija smestajne jedinice za izabrani period. Pokusaj ponovo!", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        internal bool ZaboraviIzmene()
        {
            DialogResult rezultat = MessageBox.Show(
                    "Niste sacuvali izmene. \nDa li zelite da zatvorite formu?",
                    "Upozorenje",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (rezultat == DialogResult.No)
            {
                
                return false;
            }

            try
            {
                // obrisi evidenciju iz baze ako je već kreirana
                if (Koordinator.Instance.Evidencija.Nova)
                {

                    EvidencijaRez zaBrisanje = new EvidencijaRez
                    {
                        Id = Koordinator.Instance.Evidencija.Id,
                        StavkeEvidencije = new List<StavkaEvidencije>()
                    };

                    Odgovor odg =
                        Communication.Instance.ObrisiEvidencijaRez(zaBrisanje);

                    if (odg.ExceptionMessage != null)
                        throw new Exception(odg.ExceptionMessage);

                }
                Koordinator.Instance.Evidencija = null;
                Koordinator.Instance.Stavka = null;
                Koordinator.Instance.IzmenjenaStavka = null;
                Koordinator.Instance.StavkaSledecegMeseca = null;
                Koordinator.Instance.EvidencijaSledecegMeseca = null;

                return true;

                
            }
            catch (Exception)
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

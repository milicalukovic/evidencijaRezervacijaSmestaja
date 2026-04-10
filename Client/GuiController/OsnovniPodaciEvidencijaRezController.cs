using Client.Session;
using Client.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            if (Koordinator.Instance.IzabranaEvidencija.Equals(e)) //izmena
            {
                //postavi vrednosti izabrane evidencije
                Koordinator.Instance.IzmenjenaEvidencija = Koordinator.Instance.IzabranaEvidencija;
                UCEvidencija.NumericMesec.Value = e.Mesec.Month;
                UCEvidencija.NumericGodina.Value = e.Mesec.Year;
                UCEvidencija.NumericProcenatAvansa.Value = e.ProcenatAvansa;
                UCEvidencija.NumericSezonskiKoefCene.Value = e.SezonskiKoeficijentCene;
                
                UCEvidencija.NumericMesec.ReadOnly = true;
                UCEvidencija.NumericGodina.ReadOnly = true;
                UCEvidencija.CmbSmestajnaJedinica.Enabled = true;

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
                Koordinator.Instance.IzmenjenaEvidencija = Koordinator.Instance.KreiranaEvidencija;
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

        internal void ZapamtiPodatke()
        {
            if (!Validacija())
                return;

            
            if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.KreiranaEvidencija)) //promeni novu kreiranu
            {
                EvidencijaRez izmenjena = Koordinator.Instance.IzmenjenaEvidencija;
                izmenjena.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                izmenjena.SmestajnaJedinica = UCEvidencija.CmbSmestajnaJedinica.SelectedItem as SmestajnaJedinica;
                izmenjena.OsnovnaCenaPoOsobi = izmenjena.SmestajnaJedinica.CenaPoOsobi;
                izmenjena.OsnovnaVrstaUsluge = izmenjena.SmestajnaJedinica.OsnovnaVrstaUsluge;
                izmenjena.PovecanjeCenePoUsluzi = izmenjena.SmestajnaJedinica.PovecanjeCenePoUsluzi;
                int mesec = (int)UCEvidencija.NumericMesec.Value;
                int godina = (int)UCEvidencija.NumericGodina.Value;
                izmenjena.Mesec = new DateOnly(godina, mesec, 1);
                izmenjena.StavkeEvidencije = new List<StavkaEvidencije>();

                izmenjena.ProcenatAvansa = (decimal)UCEvidencija.NumericProcenatAvansa.Value;
                izmenjena.SezonskiKoeficijentCene = (decimal)UCEvidencija.NumericSezonskiKoefCene.Value;

                //otvori stavke
                Koordinator.Instance.PromeniEvidencijaRezFrmController.StavkeEvidencijeRez();
            }
            if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.IzabranaEvidencija)) //izmena
            {
                EvidencijaRez izmenjena = Koordinator.Instance.IzmenjenaEvidencija;
                izmenjena.ProcenatAvansa = (decimal)UCEvidencija.NumericProcenatAvansa.Value;
                izmenjena.SezonskiKoeficijentCene = (decimal)UCEvidencija.NumericSezonskiKoefCene.Value;

                //otvori stavke
                Koordinator.Instance.PromeniEvidencijaRezFrmController.StavkeEvidencijeRez();
            }

        }
        private bool Validacija()
        {
            if (UCEvidencija.NumericMesec.Value == 0 
                || UCEvidencija.NumericProcenatAvansa.Value == 0
                )
            {
                MessageBox.Show(UCEvidencija, "Morate popuniti sve podatke.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //ako vec postoji evidencija za tu smestajnu jedinicu, mesec i vlasnika
            if (Koordinator.Instance.IzmenjenaEvidencija.Equals(Koordinator.Instance.KreiranaEvidencija))
            {
                EvidencijaRez evidencija = new EvidencijaRez();

                evidencija.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
                evidencija.SmestajnaJedinica = UCEvidencija.CmbSmestajnaJedinica.SelectedItem as SmestajnaJedinica;
                int mesec = (int)UCEvidencija.NumericMesec.Value;
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
    }
}

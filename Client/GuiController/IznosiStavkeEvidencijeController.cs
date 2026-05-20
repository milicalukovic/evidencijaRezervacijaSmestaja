using Client.Session;
using Client.UserControls;
using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class IznosiStavkeEvidencijeController
    {
        private UCIznosiStavkeEvidencije UCStavke;
        public IznosiStavkeEvidencijeController(UCIznosiStavkeEvidencije UCIznosiStavkeEvidencije)
        {
            this.UCStavke = UCIznosiStavkeEvidencije;
        }

        internal void PopuniPodatke()
        {
            StavkaEvidencije stavka = Koordinator.Instance.Stavka;
            
            UCStavke.TxtBrDana.ReadOnly = true;
            UCStavke.TxtIznosAvansa.ReadOnly = true;
            UCStavke.TxtIznosRezervacije.ReadOnly = true;
            UCStavke.TxtIznosUsluge.ReadOnly = true;

            UCStavke.TxtBrDana.Text = stavka.BrDana.ToString();
            UCStavke.TxtIznosAvansa.Text = stavka.IznosAvansa.ToString("N2") + " €";
            UCStavke.TxtIznosRezervacije.Text = stavka.IznosRezervacije.ToString("N2") + " €"; 
            UCStavke.TxtIznosUsluge.Text = stavka.IznosUsluge.ToString("N2") + " €";

        }

        //kada rezervacija obuhvata dva meseca
        internal void PopuniPodatkeZaDveStavke()
        {
            StavkaEvidencije tekuca = Koordinator.Instance.Stavka;
            StavkaEvidencije sledeca = Koordinator.Instance.StavkaSledecegMeseca;

            UCStavke.TxtBrDana.ReadOnly = true;
            UCStavke.TxtIznosAvansa.ReadOnly = true;
            UCStavke.TxtIznosRezervacije.ReadOnly = true;
            UCStavke.TxtIznosUsluge.ReadOnly = true;

            UCStavke.TxtBrDana.Text = (tekuca.BrDana + sledeca.BrDana).ToString();
            UCStavke.TxtIznosRezervacije.Text = (tekuca.IznosRezervacije + sledeca.IznosRezervacije).ToString("N2") + " €";
            UCStavke.TxtIznosAvansa.Text = (tekuca.IznosAvansa + sledeca.IznosAvansa).ToString("N2") + " €";
            UCStavke.TxtIznosUsluge.Text = $"Tekući: {tekuca.IznosUsluge:N2} € | Sledeći: {sledeca.IznosUsluge:N2} €"; //razlikuje se u zavisnosti od evidencije
        }

        internal void SacuvajStavku()
        {
            
            
            if (!Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                //nova => doda stavku u listu u izmenjenoj evidenciji
                Koordinator.Instance.Stavka.StatusStavke = StatusStavke.DODATA;
                Koordinator.Instance.Evidencija.StavkeEvidencije.Add(Koordinator.Instance.Stavka);
                
                if (Koordinator.Instance.StavkaSledecegMeseca != null)
                {
                    Koordinator.Instance.StavkaSledecegMeseca.StatusStavke = StatusStavke.DODATA;
                    Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije.Add(Koordinator.Instance.StavkaSledecegMeseca);
                    Koordinator.Instance.StavkaSledecegMeseca = null;
                }
            }
            else
            {
                //izvlacimo izabranu stavku iz liste
                int indeks = Koordinator.Instance.Evidencija.StavkeEvidencije
                            .FindIndex(s => s.Rb == Koordinator.Instance.Stavka.Rb
                                        && s.Evidencija.Id == Koordinator.Instance.Stavka.Evidencija.Id);

                if (indeks != -1)
                {
                    var stariStatus = Koordinator.Instance.Evidencija.StavkeEvidencije[indeks].StatusStavke;

                    Koordinator.Instance.Stavka.StatusStavke =
                        stariStatus == StatusStavke.DODATA
                            ? StatusStavke.DODATA     //nova lokalna stavka ostaje dodata jer u bazi jos ubek ne postoji 
                            : StatusStavke.IZMENJENA;

                    Koordinator.Instance.Evidencija.StavkeEvidencije[indeks] = Koordinator.Instance.Stavka;

                }
                if (Koordinator.Instance.StavkaSledecegMeseca != null )
                {
                    if (Koordinator.Instance.StavkaSledecegMeseca.StatusStavke == StatusStavke.DODATA)
                    {
                        Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije.Add(Koordinator.Instance.StavkaSledecegMeseca);
                        Koordinator.Instance.StavkaSledecegMeseca = null;
                    }
                    else
                    {
                        int indeksSl = Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije
                                    .FindIndex(s => s.Rb == Koordinator.Instance.StavkaSledecegMeseca.Rb
                                        && s.Evidencija.Id == Koordinator.Instance.StavkaSledecegMeseca.Evidencija.Id);

                        if (indeksSl != -1) //zastita za obrisanu
                        {
                            var stariStatusSl = Koordinator.Instance.EvidencijaSledecegMeseca
                                                     .StavkeEvidencije[indeksSl].StatusStavke;

                            Koordinator.Instance.StavkaSledecegMeseca.StatusStavke =
                                stariStatusSl == StatusStavke.DODATA
                                    ? StatusStavke.DODATA
                                    : Koordinator.Instance.StavkaSledecegMeseca.StatusStavke;

                            Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije[indeksSl] =
                                Koordinator.Instance.StavkaSledecegMeseca;

                        }
                        Koordinator.Instance.StavkaSledecegMeseca = null;
                    }
                }
            }
            //osvezi tabelu
            Koordinator.Instance.StavkeEvidencijaRezUCController.AzurirajTabelu();
            MessageBox.Show(UCStavke, "Sacuvana rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Koordinator.Instance.PromeniStavkaEvidencijeRezController.OsveziVrednosti();
            Koordinator.Instance.GlavnaFrmController.StavkeEvidencijeRez();
        }
    }
}

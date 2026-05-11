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
            StavkaEvidencije stavka;
            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                stavka = Koordinator.Instance.IzmenjenaStavka;
            }
            else
            {
                stavka = Koordinator.Instance.Stavka;
            }
            UCStavke.TxtBrDana.ReadOnly = true;
            UCStavke.TxtIznosAvansa.ReadOnly = true;
            UCStavke.TxtIznosRezervacije.ReadOnly = true;
            UCStavke.TxtIznosUsluge.ReadOnly = true;

            UCStavke.TxtBrDana.Text = stavka.BrDana.ToString();
            UCStavke.TxtIznosAvansa.Text = stavka.IznosAvansa.ToString("N2");
            UCStavke.TxtIznosRezervacije.Text = stavka.IznosRezervacije.ToString("N2");
            UCStavke.TxtIznosUsluge.Text = stavka.IznosUsluge.ToString("N2");
            
        }

        //kada rezervacija obuhvata dva meseca
        internal void PopuniPodatkeZaDveStavke()
        {
            StavkaEvidencije tekuca;
            if (Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                tekuca = Koordinator.Instance.IzmenjenaStavka;
            }
            else
            {
                tekuca = Koordinator.Instance.Stavka;
            }

            StavkaEvidencije sledeca = Koordinator.Instance.StavkaSledecegMeseca;

            UCStavke.TxtBrDana.ReadOnly = true;
            UCStavke.TxtIznosAvansa.ReadOnly = true;
            UCStavke.TxtIznosRezervacije.ReadOnly = true;
            UCStavke.TxtIznosUsluge.ReadOnly = true;

            UCStavke.TxtBrDana.Text = (tekuca.BrDana + sledeca.BrDana).ToString();
            UCStavke.TxtIznosAvansa.Text = (tekuca.IznosAvansa + sledeca.IznosAvansa).ToString("N2");
            UCStavke.TxtIznosRezervacije.Text = (tekuca.IznosRezervacije + sledeca.IznosRezervacije).ToString("N2");
            UCStavke.TxtIznosUsluge.Text = (tekuca.IznosUsluge + sledeca.IznosUsluge).ToString("N2");
        }

        internal void SacuvajStavku()
        {
            
            if (Koordinator.Instance.StavkaSledecegMeseca!=null)
            {
                Koordinator.Instance.StavkaSledecegMeseca.StatusStavke = StatusStavke.DODATA;
                Koordinator.Instance.EvidencijaSledecegMeseca.StavkeEvidencije.Add(Koordinator.Instance.StavkaSledecegMeseca);
                Koordinator.Instance.StavkaSledecegMeseca = null;
            }
            if (!Koordinator.Instance.Stavka.Equals(Koordinator.Instance.IzmenjenaStavka))
            {
                //nova => doda stavku u listu u izmenjenoj evidenciji
                Koordinator.Instance.Stavka.StatusStavke = StatusStavke.DODATA;
                Koordinator.Instance.Evidencija.StavkeEvidencije.Add(Koordinator.Instance.Stavka);

            }
            else
            {
                //izvlacimo izabranu stavku iz liste
                int indeks = Koordinator.Instance.Evidencija.StavkeEvidencije
                            .FindIndex(s => s.Rb == Koordinator.Instance.Stavka.Rb
                                        && s.Evidencija.Id == Koordinator.Instance.Stavka.Evidencija.Id);

                if (indeks != -1)
                {
                    Koordinator.Instance.IzmenjenaStavka.StatusStavke = StatusStavke.IZMENJENA;
                    Koordinator.Instance.Evidencija.StavkeEvidencije[indeks] = Koordinator.Instance.IzmenjenaStavka;
                    Koordinator.Instance.Stavka = Koordinator.Instance.IzmenjenaStavka;
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

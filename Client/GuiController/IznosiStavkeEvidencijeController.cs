using Client.Session;
using Client.UserControls;
using Common.Domain;
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
            StavkaEvidencije stavka = Koordinator.Instance.IzmenjenaStavka;
            UCStavke.TxtBrDana.ReadOnly = true;
            UCStavke.TxtIznosAvansa.ReadOnly = true;
            UCStavke.TxtIznosRezervacije.ReadOnly = true;
            UCStavke.TxtIznosUsluge.ReadOnly = true;

            UCStavke.TxtBrDana.Text = stavka.BrDana.ToString();
            UCStavke.TxtIznosAvansa.Text = stavka.IznosAvansa.ToString("N2");
            UCStavke.TxtIznosRezervacije.Text = stavka.IznosRezervacije.ToString("N2");
            UCStavke.TxtIznosUsluge.Text = stavka.IznosUsluge.ToString("N2");
            
        }

        internal void SacuvajStavku()
        {
            if (Koordinator.Instance.IzmenjenaStavka.Equals(Koordinator.Instance.KreiranaStavka))
            {
                //nova => doda stavku u listu u izmenjenoj evidenciji
                Koordinator.Instance.IzmenjenaEvidencija.StavkeEvidencije.Add(Koordinator.Instance.IzmenjenaStavka);

            }
            //osvezi tabelu
            Koordinator.Instance.StavkeEvidencijaRezUCController.AzurirajTabelu();
            MessageBox.Show(UCStavke, "Sacuvana rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Koordinator.Instance.StavkaEvidencijeFrmController.ZatvoriFormu();
        }
    }
}

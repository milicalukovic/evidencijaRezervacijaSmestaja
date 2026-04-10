using Client.Forms;
using Client.Session;
using Common.Communication;
using Common.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class GlavnaFrmController
    {
        private FrmGlavna frmGlavna;

        public GlavnaFrmController(FrmGlavna frmGlavna)
        {
            this.frmGlavna = frmGlavna;
            UcitajTipSmestaja();
            UcitajSmestajneJedinice();
            UcitajKorisnike();
        }
        internal void PrikaziSmestajneJedinice()
        {
            frmGlavna.GlavnaPanel.Controls.Clear();
            Koordinator.Instance.InicijalizujUCPrikazSJ();    //INICIJALIZACIJA
            Koordinator.Instance.SmestajnaJedinicaUCController.PopuniPodatke(); //POPUNJAVAMO PODATKE
            frmGlavna.GlavnaPanel.Controls.Add(Koordinator.Instance.UCPrikazSmestajnaJedinica); // PRIKAZUJEMO UC
        }
        internal void UbaciIzvorOcene()
        {
            Koordinator.Instance.OtvoriFrmIzvorOcene();
        }
        internal void OdjaviVlasnik()
        {
            Communication.Instance.OdjaviVlasnik(Koordinator.Instance.UlogovaniVlasnik);
            Koordinator.Instance.UlogovaniVlasnik = null;
        }

        internal void PrikaziEvidencije()
        {
            frmGlavna.GlavnaPanel.Controls.Clear();
            Koordinator.Instance.InicijalizujUCPrikazEvidencija();
            Koordinator.Instance.PrikazEvidencijaRezController.PopuniPodatke();
            frmGlavna.GlavnaPanel.Controls.Add(Koordinator.Instance.UCPrikazEvidencijaRez);
        }

        internal void PretraziEvidencije()
        {
            if (Koordinator.Instance.ListaEvidencijaRezervacija.IsNullOrEmpty())
            {
                MessageBox.Show(frmGlavna, "Jos uvek nemate kreirane evidencije rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Koordinator.Instance.OtvoriFrmKriterijumPretrageEvidencijaRez();
        }
        internal void IzabranaEvidencijaRez()
        {
            frmGlavna.GlavnaPanel.Controls.Clear();
            Koordinator.Instance.InicijalizujUCIzabranaEvidencijaRez();
            Koordinator.Instance.IzabranaEvidencijaRezController.PopuniPodatke();
            frmGlavna.GlavnaPanel.Controls.Add(Koordinator.Instance.UCIzabranaEvidencijaRez);
        }
        internal void KreirajEvidencijaRez()
        {
            //UcitajVlasnike();   nije neophodno ucitavati
            //UcitajSmestajneJedinice(); //ucitano u konstruktoru 
            //UcitajKorisnike();

            if (Koordinator.Instance.ListaSmestajnaJedinica.IsNullOrEmpty())
            {
                MessageBox.Show(frmGlavna, "Morate dodati bar jednu smestajnu jedinicu kako biste napravili njenu mesecnu evidenciju.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            EvidencijaRez kreirana = new EvidencijaRez();
            kreirana.Vlasnik = Koordinator.Instance.UlogovaniVlasnik;
            kreirana.SmestajnaJedinica = Koordinator.Instance.ListaSmestajnaJedinica.FirstOrDefault();

            Odgovor serverOdg = Communication.Instance.KreirajEvidencijaRez(kreirana);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                EvidencijaRez nova = serverOdg.Result as EvidencijaRez;
                Koordinator.Instance.KreiranaEvidencija = nova;
                MessageBox.Show(frmGlavna, "Sistem je kreirao evidenciju rezervacija.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Koordinator.Instance.OtvoriFrmPromeniEvidencijaRez(nova);
            }
            else
            {
                MessageBox.Show(frmGlavna, "Sistem ne moze da kreira  evidenciju rezervacija.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajKorisnike()
        {
            Korisnik korisnik = new Korisnik();

            Odgovor serverOdg = Communication.Instance.VratiListuSviKorisnik(korisnik);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                List<Korisnik> lista = (List<Korisnik>)serverOdg.Result;
                Koordinator.Instance.ListaKorisnik = lista;
            }
        }
        private void UcitajTipSmestaja()
        {
            TipSmestaja tip = new TipSmestaja();

            Odgovor serverOdg = Communication.Instance.VratiListuSviTipSmestaja(tip);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                List<TipSmestaja> lista = (List<TipSmestaja>)serverOdg.Result;
                Koordinator.Instance.ListaTipSmestaja = lista;
            }
        }
        private void UcitajSmestajneJedinice()
        {
            //if (Koordinator.Instance.ListaSmestajnaJedinica.IsNullOrEmpty())
            
                List<SmestajnaJedinica> lista = new List<SmestajnaJedinica>();
                SmestajnaJedinica sj = new SmestajnaJedinica();
                sj.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;

                Odgovor serverOdg = Communication.Instance.VratiListuSviSmestajnaJedinica(sj);
                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    lista = (List<SmestajnaJedinica>)serverOdg.Result;
                    Koordinator.Instance.ListaSmestajnaJedinica = lista;
                }
            
        }
    }
}

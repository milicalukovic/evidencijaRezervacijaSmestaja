using Client.Forms;
using Client.GuiController;
using Client.UserControls;
using Common.Domain;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Session
{
    public class Koordinator
    {
        private static Koordinator instance;
        private Koordinator() { }
        public static Koordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Koordinator();
                }
                return instance;
            }
        }
        internal void OtvoriFormu(Form form)
        {
            form.ShowDialog();
        }

        public Vlasnik UlogovaniVlasnik { get; set; }
        public FrmPrijaviVlasnik FrmPrijaviVlasnik { get; set; }
        public PrijaviVlasnikController PrijaviVlasnikController { get; set; }    
        internal void OtvoriFrmPrijaviVlasnik()
        {
            FrmPrijaviVlasnik = new FrmPrijaviVlasnik();
            PrijaviVlasnikController = new PrijaviVlasnikController(FrmPrijaviVlasnik);
            PrijaviVlasnikController.OtvoriFormu();
        }

        public FrmGlavna FrmGlavna { get; set; }
        public GlavnaFrmController GlavnaFrmController { get; set; }
        internal void OtvoriGlavnuFrm() //prijaviGui je poziva
        {
            FrmGlavna = new FrmGlavna();
            GlavnaFrmController = new GlavnaFrmController(FrmGlavna);
            //GlavnaFrmController.OtvoriFormu();  preko App run se inicijalizuje
        }

        public FrmIzvorOcene FrmIzvorOcene { get; set; }
        public IzvorOceneController IzvorOceneController { get; set; }
        internal void OtvoriFrmIzvorOcene()
        {
            FrmIzvorOcene = new FrmIzvorOcene();
            IzvorOceneController = new IzvorOceneController(FrmIzvorOcene);
            IzvorOceneController.OtvoriFormu();
        }

        public List<TipSmestaja> ListaTipSmestaja { get; set; } = new List<TipSmestaja>();
        public List<SmestajnaJedinica> ListaSmestajnaJedinica { get; set; } = new List<SmestajnaJedinica> ();
        public UCPrikazSmestajnaJedinica UCPrikazSmestajnaJedinica { get; set; }
        public SmestajnaJedinicaUCController SmestajnaJedinicaUCController { get; set; }
        internal void InicijalizujUCPrikazSJ()
        {
            UCPrikazSmestajnaJedinica = new UCPrikazSmestajnaJedinica();
            SmestajnaJedinicaUCController = new SmestajnaJedinicaUCController(UCPrikazSmestajnaJedinica);
        }

        public SmestajnaJedinica KreiranaSJ { get; set; }
        public SmestajnaJedinica IzabranaSJ { get; set; }
        public Boolean ModeKreirajSJ { get; set; }
        public FrmSmestajnaJedinica FrmSmestajnaJedinica { get; set; }
        public SmestajnaJedinicaFrmController SmestajnaJedinicaFrmController { get; set; }
        internal void OtvoriFrmSmestajnaJedinica()
        {
            FrmSmestajnaJedinica = new FrmSmestajnaJedinica();
            SmestajnaJedinicaFrmController = new SmestajnaJedinicaFrmController(FrmSmestajnaJedinica);
            SmestajnaJedinicaFrmController.OtvoriFormu();
        }

        public List<EvidencijaRez> ListaEvidencijaRezervacija { get; set; } = new List<EvidencijaRez>();
        public UCPrikazEvidencijaRez UCPrikazEvidencijaRez { get; set; }
        public PrikazEvidencijaRezController PrikazEvidencijaRezController { get; set; }
        internal void InicijalizujUCPrikazEvidencija()
        {
            UCPrikazEvidencijaRez = new UCPrikazEvidencijaRez();
            PrikazEvidencijaRezController = new PrikazEvidencijaRezController(UCPrikazEvidencijaRez);
        }

        public FrmKriterijumPretrageEvidencijaRez FrmKriterijumPretrageEvidencijaRez { get; set; }
        public KriterijumPretrageController KriterijumPretrageController { get; set; }
        internal void OtvoriFrmKriterijumPretrageEvidencijaRez()
        {
            FrmKriterijumPretrageEvidencijaRez = new FrmKriterijumPretrageEvidencijaRez();
            KriterijumPretrageController = new KriterijumPretrageController(FrmKriterijumPretrageEvidencijaRez);
            KriterijumPretrageController.OtvoriFormu();
        }

        public EvidencijaRez IzabranaEvidencija { get; set; }
        public UCIzabranaEvidencijaRez UCIzabranaEvidencijaRez { get; set; }
        public IzabranaEvidencijaRezController IzabranaEvidencijaRezController { get; set; }
        internal void InicijalizujUCIzabranaEvidencijaRez()
        {
            UCIzabranaEvidencijaRez = new UCIzabranaEvidencijaRez();
            IzabranaEvidencijaRezController = new IzabranaEvidencijaRezController(UCIzabranaEvidencijaRez);
        }

        public EvidencijaRez KreiranaEvidencija { get; set; }
        public List<Korisnik> ListaKorisnik { get; set; } = new List<Korisnik>();
        public FrmPromeniEvidencijaRez FrmPromeniEvidencijaRez { get; set; }
        public PromeniEvidencijaRezFrmController PromeniEvidencijaRezFrmController { get; set; }
        internal void OtvoriFrmPromeniEvidencijaRez(EvidencijaRez e)
        {
            FrmPromeniEvidencijaRez = new FrmPromeniEvidencijaRez();
            PromeniEvidencijaRezFrmController = new PromeniEvidencijaRezFrmController(FrmPromeniEvidencijaRez);
            PromeniEvidencijaRezFrmController.OtvoriFormu(e);
        }

        public EvidencijaRez IzmenjenaEvidencija { get; set; }
        public UCOsnovniPodaciEvidencijaRez UCOsnovniPodaciEvidencijaRez { get; set; }
        public OsnovniPodaciEvidencijaRezController OsnovniPodaciEvidencijaRezController { get; set; }
        internal void InicijalizujUCOsnovniPodaciEvidencijaRez()
        {
            UCOsnovniPodaciEvidencijaRez = new UCOsnovniPodaciEvidencijaRez();
            OsnovniPodaciEvidencijaRezController = new OsnovniPodaciEvidencijaRezController(UCOsnovniPodaciEvidencijaRez);
        }

        public StavkaEvidencije IzabranaStavka { get; set; }
        public UCStavkeEvidencijaRez UCStavkeEvidencijaRez { get; set; }
        public StavkeEvidencijaRezUCController StavkeEvidencijaRezUCController { get; set; }
        internal void InicijalizujUCStavkeEvidencijaRez()
        {
            UCStavkeEvidencijaRez = new UCStavkeEvidencijaRez();
            StavkeEvidencijaRezUCController = new StavkeEvidencijaRezUCController(UCStavkeEvidencijaRez);
        }

        public StavkaEvidencije IzmenjenaStavka { get; set; }
        public FrmStavkaEvidencije FrmStavka { get; set; }
        public StavkaEvidencijeFrmController StavkaEvidencijeFrmController { get; set; }
        internal void OtvoriFrmStavkaEvidencije(StavkaEvidencije stavka)
        {
            FrmStavka = new FrmStavkaEvidencije();
            StavkaEvidencijeFrmController = new StavkaEvidencijeFrmController(FrmStavka);
            StavkaEvidencijeFrmController.OtvoriFormu(stavka);
        }

        public StavkaEvidencije KreiranaStavka { get; set; }
        public Korisnik Korisnik { get; set; }
        public UCIznosiStavkeEvidencije UCIznosiStavkeEvidencije {  get; set; }
        public IznosiStavkeEvidencijeController IznosiStavkeEvidencijeController { get; set; }
        internal void InicijalizujUCIznosiStavkeEvidencije()
        {
            UCIznosiStavkeEvidencije = new UCIznosiStavkeEvidencije();
            IznosiStavkeEvidencijeController = new IznosiStavkeEvidencijeController(UCIznosiStavkeEvidencije);
        }
    }
}
